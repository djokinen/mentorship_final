using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class BasePage : System.Web.UI.Page
{
	protected Guid CurrentUserId
	{
		get
		{
			return (Guid)Membership.GetUser().ProviderUserKey;
		}
	}
}