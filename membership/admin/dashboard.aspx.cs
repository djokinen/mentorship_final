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
	}

	public override void DataBind()
	{
		base.DataBind();
		StringBuilder text = new StringBuilder();
		List<cree_MenteeMentor> menteeMentorList = (from t in new DataAccess().GetMenteeMentor()
																  where t.ConnectionStatus != 0
																  select t).ToList();

		if (menteeMentorList.Count == 0)
		{
			text.Append("<li><strong>You have no pending connections</strong></li>");
		}
		else
		{
			for (int i = 0; i < menteeMentorList.Count; i++)
			{
				text.AppendFormat("<li data-userid=\"{0}\">", menteeMentorList[i].UserIdMentee);
				// command buttons
				text.AppendFormat("<div class=\"right\">");
				if (menteeMentorList[i].ConnectionStatus == ConnectionStatus.Accepted.GetHashCode())
				{
					text.AppendFormat("<a class=\"btn reject\" href=\"javascript://\">{0}</a>", "disconnect");
				}
				else
				{
					text.AppendFormat("<a class=\"btn accept\" href=\"javascript://\">{0}</a>", "connect");
				}
				text.AppendFormat("</div>");

				// mentee details
				MembershipUser membershipUser = Membership.GetUser(menteeMentorList[i].UserIdMentee);
				text.AppendFormat("<div>");
				text.AppendFormat("<label>{0}</label>", membershipUser.UserName);
				text.AppendFormat("<p>{0}</p>", membershipUser.Email);
				text.AppendFormat("</div>");
				text.AppendFormat("</li>");
			}
		}
		literal.Text = text.ToString();
	}
}