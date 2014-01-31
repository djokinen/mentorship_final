using System;

public partial class membership_admin_default : BasePage
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (!IsPostBack) { adminList.DataBind(); }
	}
}