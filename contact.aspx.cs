using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : BasePage
{
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		buttonOk.Click += buttonOk_Click;
	}

	void buttonOk_Click(object sender, EventArgs e)
	{
		bool success = Global.SendContactEmail(
			textName.Text.Trim(),
			textEmail.Text.Trim().ToLower(),
			textMessage.Text.Trim());

		success_wrapper.Visible = success;
		contact_form.Visible = !success;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		emailAddressValidator.ValidationExpression = Global.EmailRegEx;
	}
}