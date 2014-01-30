using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Membership_Create : BaseUserControl
{
	private bool _isMentee { get { return radioList.SelectedValue == "mentee"; } }

	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		buttonCreateUser.Click += buttonCreateUser_Click;
		buttonUpdateProfile_mentee.Click += buttonUpdateProfile_Click;
		buttonUpdateProfile_mentor.Click += buttonUpdateProfile_Click;
	}

	void buttonCreateUser_Click(object sender, EventArgs e) { _showStep(((LinkButton)sender).CommandArgument); }

	void buttonUpdateProfile_Click(object sender, EventArgs e) { _showStep(((LinkButton)sender).CommandArgument); }

	private void _showStep(string commandArgument)
	{
		string status = string.Empty;
		panelStep1_create.Visible = false;
		panelStep2_mentee.Visible = false;
		panelStep2_mentor.Visible = false;
		panelStep3_confirm.Visible = false;

		switch (commandArgument)
		{
			case "create":
				if (_createMember(out status))
				{
					if (this._isMentee) { panelStep2_mentee.Visible = true; }
					else { panelStep2_mentor.Visible = true; }
				}
				else
				{
					panelStep1_create.Visible = true;
					ErrorMessage.Text = status;
				}
				break;
			case "update":
				if (_updateMember(out status)) { panelStep3_confirm.Visible = true; }
				else
				{
					if (this._isMentee) { panelStep2_mentee.Visible = true; }
					else { panelStep2_mentor.Visible = true; }
					ErrorMessage.Text = status;
				}
				break;

			case "complete":
				break;
		}
	}

	private bool _createMember(out string status)
	{
		MembershipCreateStatus membershipCreateStatus;
		MembershipUser membershipUser = Membership.CreateUser(UserName.Text, Password.Text, UserName.Text, null, null, false, out membershipCreateStatus);
		if (membershipUser != null)
		{
			RoleType roleType = this._isMentee ? RoleType.Mentee : RoleType.Mentor;
			Roles.AddUserToRole(membershipUser.UserName, roleType.ToString());
			// add user to role
			//if (this._isMentee) { Roles.AddUserToRole(membershipUser.UserName, RoleType.Mentee.ToString()); }
			//else { Roles.AddUserToRole(membershipUser.UserName, RoleType.Mentor.ToString()); }

			// add user profile information
			ProfileCommon profileCommon = (ProfileCommon)ProfileCommon.Create(membershipUser.UserName);
			profileCommon.FullName = FullName.Text.Trim();
			profileCommon.Save();

			Global.SendRegistrationEmail(membershipUser, roleType);
		}
		status = membershipCreateStatus.ToString();
		return status == "Success";
	}

	private bool _updateMember(out string status)
	{
		bool value = false;
		status = "Success";

		string username = UserName.Text;

		MembershipUser membershipUser = Membership.GetUser(username);
		if (membershipUser != null)
		{
			ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(username);
			if (profileCommon != null)
			{
				if (this._isMentee)
				{
					profileCommon.Phone = MenteePhone.Text.Trim();
					profileCommon.Mentee.Community = MenteeCommunity.Text.Trim();
					DateTime dob;
					if (DateTime.TryParse(MenteeDob.Text.Trim(), out dob))
					{
						profileCommon.Mentee.Dob = MenteeDob.Text.Trim();
					}
					else
					{
						profileCommon.Mentee.Dob = string.Empty;
					}

					profileCommon.Mentee.Occupation = MenteeOccupation.Text.Trim();
				}
				else
				{
					profileCommon.Phone = MentorPhone.Text.Trim();
					profileCommon.Mentor.Bio = MentorBio.Text.Trim();
					profileCommon.Mentor.CompanyName = MentorCompanyName.Text.Trim();
					// profileCommon.Mentor.Industry = MentorIndustry.Text.Trim();
				}
				profileCommon.Save();
				value = true;
			}
			else
			{
				status = "Null reference exception with profileCommon";
			}
		}
		else { status = "Null reference exception with membershipUser"; }
		return value;
	}
}