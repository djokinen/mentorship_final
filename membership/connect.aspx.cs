using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class membership_connect : BasePage
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (!IsPostBack) { menteeMentorConnect.DataBind(); }
	}
}