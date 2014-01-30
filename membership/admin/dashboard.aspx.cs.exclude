using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class membership_admin_dashboard : BasePage
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (!IsPostBack) { this.DataBind(); }
	}

	public override void DataBind()
	{
		base.DataBind();
		StringBuilder text = new StringBuilder();
		MembershipUserCollection membershipUserCollection = Membership.GetAllUsers();
		// List<cree_MenteeMentor> menteeMentorList = (from t in new DataAccess().GetMenteeMentor() where t.ConnectionStatus != 0 select t).ToList();

		if (membershipUserCollection.Count == 0)
		{
			text.Append("<li><strong>You have no pending connections</strong></li>");
		}
		else
		{
			// for (int i = 0; i < menteeMentorList.Count; i++)
			foreach (MembershipUser membershipUser in membershipUserCollection)
			{
				ProfileCommon profileCommon = (ProfileCommon)ProfileCommon.Create(membershipUser.UserName);
				// text.AppendFormat("<li data-userid=\"{0}\">", membershipUser.UserIdMentee);
				text.AppendFormat("<li data-userid=\"{0}\">", membershipUser.ProviderUserKey);
				// command buttons
				text.AppendFormat("<div class=\"right\">");
				if (membershipUser.IsApproved)
				{
					text.AppendFormat("<a class=\"btn reject\" href=\"javascript://\">{0}</a>", "disable");
				}
				else
				{
					text.AppendFormat("<a class=\"btn accept\" href=\"javascript://\">{0}</a>", "enable");
				}
				text.AppendFormat("</div>");

				// mentee details
				text.AppendFormat("<div>");
				text.AppendFormat("<label>{0}</label>", profileCommon.FullName);
				text.AppendFormat("<div><a href=\"mailto://{0}\">{0}</a></div>", membershipUser.Email);
				text.AppendFormat("</div>");
				text.AppendFormat("</li>");
			}
		}
		literal.Text = text.ToString();
	}
}