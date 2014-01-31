using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		button.Click += button_Click;
	}

	void button_Click(object sender, EventArgs e)
	{
		return;
		MembershipUser m = Membership.GetUser();
		if (Roles.IsUserInRole(RoleType.Admin.ToString()))
		{
			Global.SendConnectEmailToMentee(m);
			Global.SendConnectEmailToMentor(m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla sed lacus vitae quam malesuada rhoncus id a diam. Sed nisi turpis, sodales euismod lobortis sed, rutrum et ligula. Mauris ut eros ipsum, tristique convallis libero. Nullam pharetra, nibh vel vestibulum pellentesque, velit lacus ultricies nibh, vitae porta turpis sapien ac orci. Pellentesque pellentesque elementum massa a euismod. Etiam elit dolor, accumsan non sagittis eget, viverra in est. Praesent interdum aliquet odio, nec adipiscing dui adipiscing sit amet. Nulla facilisi. Fusce nec sem nibh. In nec turpis mauris, vitae pulvinar enim. Curabitur accumsan purus sed dui malesuada faucibus. Quisque rhoncus facilisis ante quis ultrices.");
			Global.SendRegistrationEmail(m, RoleType.Mentee);
			Global.SendRegistrationApprovedEmail(m);
		}
	}
}