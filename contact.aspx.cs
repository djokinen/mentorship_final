using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : BasePage
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		emailAddressValidator.ValidationExpression = Global.EmailRegEx;
	}
}