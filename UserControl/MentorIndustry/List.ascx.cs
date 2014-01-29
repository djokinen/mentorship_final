using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_MentorIndustry_List : BaseUserControl
{
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
		// buttonUpdate.Click += buttonUpdate_Click;
	}

	// void buttonUpdate_Click(object sender, EventArgs e) { this.Save(); }

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		/* if (!IsPostBack) { this.DataBind(); } */
	}

	public override void DataBind()
	{
		base.DataBind();

		// available industries
		repeaterAvailable.DataSource = new DataAccess().GetIndustryListAvailable(base.CurrentUserId);
		repeaterAvailable.DataBind();

		// selected industries
		List<cree_Industry> industryList = new DataAccess().GetIndustryListByMentor(base.CurrentUserId);
		groupMembers.Value = string.Join(",", industryList.Select(n => n.ID));
		repeaterSelected.DataSource = industryList;
		repeaterSelected.DataBind();
	}

	public void Save()
	{
		new DataAccess().SetMentorIndustryList(base.CurrentUserId, groupMembers.Value.Trim());
		this.DataBind();
	}
}