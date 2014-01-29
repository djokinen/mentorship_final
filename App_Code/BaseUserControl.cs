using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class BaseUserControl : System.Web.UI.UserControl
{
	protected Guid CurrentUserId
	{
		get
		{
			return (Guid)Membership.GetUser().ProviderUserKey;
		}
	}

	public bool IsEditMode
	{
		get
		{
			if (ViewState[Resources.Key.IsEditMode] != null) { return (bool)ViewState[Resources.Key.IsEditMode]; }
			else { return false; }
		}
		set { ViewState[Resources.Key.IsEditMode] = value; }
	}

	protected bool IsMentee
	{
		get
		{
			return Roles.IsUserInRole(RoleType.Mentee.ToString());
		}
	}

	public string CurrentUserName
	{
		get
		{
			// HACK: FIX THIS
			return Membership.GetUser().UserName;
			//if (ViewState[Resources.Key.UserName] != null)
			//{
			//	return (string)ViewState[Resources.Key.UserName];
			//}
			//else { return string.Empty; }
		}
		set { ViewState[Resources.Key.UserName] = value; }
	}
}