using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_MenteeMentor_List : BaseUserControl
{
	struct MentorSimple
	{
		public string Bio;
		public string Name;
		public Guid UserId;
		public string Company;
		public string Industries;
		public int ConnectionStatusId;
	}

	public override void DataBind()
	{
		base.DataBind();

		StringBuilder text = new StringBuilder();
		string[] userNames = Roles.GetUsersInRole(RoleType.Mentor.ToString());
		MembershipUserCollection membershipUserCollection = new MembershipUserCollection();
		int count = 0;

		for (int i = 0; i < userNames.Count(); i++)
		{
			MembershipUser membershipUser = Membership.GetUser(userNames[i]);
			if (membershipUser != null)
			{
				cree_MenteeMentor menteeMentor = new DataAccess().GetMenteeMentor((Guid)membershipUser.ProviderUserKey);
				// default value
				int connectionStatusId = ConnectionStatus.None.GetHashCode();
				if (menteeMentor != null) { connectionStatusId = menteeMentor.ConnectionStatus; }

				ProfileCommon profileCommon = Profile.GetProfile(userNames[i]);
				if (profileCommon != null)
				{
					List<cree_Industry> industryList = new DataAccess().GetIndustryListByMentor((Guid)membershipUser.ProviderUserKey);

					MentorSimple mentor = new MentorSimple();
					mentor.Name = profileCommon.FullName;
					mentor.Bio = profileCommon.Mentor.Bio;
					mentor.Company = profileCommon.Mentor.CompanyName;
					mentor.UserId = (Guid)membershipUser.ProviderUserKey;
					mentor.ConnectionStatusId = connectionStatusId;
					mentor.Industries = String.Join(", ", industryList.Select(n => n.Name));


					// output 1st record as selected
					if (count == 0)
					{
						StringBuilder mentorDetail = new StringBuilder();
						mentorDetail.AppendFormat("<div id=\"mentor-detail\" data-userid=\"{0}\" data-connectionstatusid=\"{1}\">", membershipUser.ProviderUserKey, connectionStatusId);
						mentorDetail.AppendFormat("<div class=\"title\">{0}</div>", profileCommon.FullName);

						mentorDetail.AppendFormat("<div class=\"status\">{0}</div>", _getStatusMessage(connectionStatusId));

						mentorDetail.AppendFormat("<div class=\"subtitle\"><em>{0}</em></div>", profileCommon.Mentor.CompanyName);
						mentorDetail.AppendFormat("<div><strong>{0}</strong></div>", String.Join(", ", industryList.Select(n => n.Name)));
						mentorDetail.AppendFormat("<div id=\"mentor-bio\">{0}</div>", profileCommon.Mentor.Bio);

						mentorDetail.Append("<Fieldset id=\"cxn-request-form\" style='display:none;'>");
						mentorDetail.AppendFormat("<legend>{0}</legend>", "Request Connection");
						// mentorDetail.AppendFormat("<textarea rows='3' placeholder='Personal message to mentor'>{0}</textarea>", profileCommon.Mentor.Bio);
						mentorDetail.Append("<textarea rows='3' placeholder='Personal message to mentor'></textarea>");
						mentorDetail.Append("<a class=\"btn accept\" href=\"javascript://\" id=\"cxn-send-button\">Send</a>");
						mentorDetail.Append("<a class=\"btn reject\" href=\"javascript://\" id=\"cxn-cancel-button\">Cancel</a>");
						mentorDetail.Append("</fieldset>");

						mentorDetail.Append(_getButtonHtml(connectionStatusId, profileCommon.FullName));

						mentorDetail.Append("</div>");
						count++;
						literalMentorDetail.Text = mentorDetail.ToString();
					}

					/*
					 * 0 = cst
					 * 1 = connection status type id
					 * 2 = industry list by id
					 * 3 = active item or not
					 * sample: class="cst1 mix 2 3 8 active
					 */
					text.AppendFormat("<li class=\"{0}{1} mix {2}{3}\">",
						Resources.Key.ConnectionStatusId,
						connectionStatusId,
						String.Join(" ", industryList.Select(n => n.ID)),
						i == 0 ? " active" : string.Empty);

					text.AppendFormat("<a data-userid=\'{0}\' data-user=\'{1}\' src=\'#\'>{2}</a>",
						membershipUser.ProviderUserKey,
						Server.HtmlEncode(JsonConvert.SerializeObject(mentor, Formatting.None)),
						profileCommon.FullName);
					text.Append("</li>");
				}
			}
		}
		literalMentorList.Text = text.ToString();

		repeaterFilter.DataSource = new DataAccess().GetIndustryListAvailable(base.CurrentUserId);
		repeaterFilter.DataBind();
	}


	private string _getButtonHtml(int connectionStatusId, string mentorName)
	{
		string style = connectionStatusId == ConnectionStatus.None.GetHashCode() ? string.Empty : " style=\"display:none;\"";
		return string.Format("<a id=\"cnx-request-button\" class=\"btn accept connect\" {0}>Connect with {1}</a>", style, mentorName);
	}

	private string _getStatusMessage(int connectionStatusId)
	{
		if (connectionStatusId == ConnectionStatus.Pending.GetHashCode())
		{
			return "Awaiting approval from mentor";
		}
		else if (connectionStatusId == ConnectionStatus.Accepted.GetHashCode())
		{
			return "You are connected with this mentor";
		}
		else
		{
			return "Connection available";
		}
	}
}