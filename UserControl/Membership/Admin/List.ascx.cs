using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Membership_Admin_List : BaseUserControl
{
	public override void DataBind()
	{
		base.DataBind();
		StringBuilder text = new StringBuilder();
		MembershipUserCollection membershipUserCollection = Membership.GetAllUsers();

		if (membershipUserCollection.Count == 0)
		{
			text.Append("<li><strong>There are no users in the system.</strong></li>");
		}
		else
		{
			foreach (MembershipUser membershipUser in membershipUserCollection)
			{
				ProfileCommon profileCommon = Global.GetProfile(membershipUser.UserName);
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
				text.AppendFormat("<strong>Name</strong>: <label>{0}</label>", profileCommon.FullName);
				text.AppendFormat("<div><strong>Email</strong>: <a href=\"mailto://{0}\">{0}</a></div>", membershipUser.Email);
				text.AppendFormat("<div><strong>Role Type</strong>: {0}</div>", string.Join(", ", Roles.GetRolesForUser(membershipUser.UserName)));

				text.AppendFormat("</div>");
				text.AppendFormat("</li>");
			}
		}
		literal.Text = text.ToString();
	}
}