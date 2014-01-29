using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class membership_admin_default : BasePage
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		_load();
	}

	private void _load()
	{
		gridViewAll.DataSource = Membership.GetAllUsers();
		gridViewAll.DataBind();

		foreach (string role in Roles.GetAllRoles())
		{
			string[] userNames = Roles.GetUsersInRole(role);
			MembershipUserCollection membershipUserCollection = new MembershipUserCollection();
			foreach (string userName in userNames) { membershipUserCollection.Add(Membership.GetUser(userName)); }

			if (membershipUserCollection.Count > 0)
			{
				Literal literal = new Literal();
				literal.Text = string.Format("<h3>{0}</h3>", role);
				placeHolder.Controls.Add(literal);

				GridView gridView = new GridView();
				gridView.DataSource = membershipUserCollection;
				gridView.DataBind();
				placeHolder.Controls.Add(gridView);
			}
		}
	}
}