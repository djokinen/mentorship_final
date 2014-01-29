using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class BaseMasterPage : System.Web.UI.MasterPage
{
	protected Guid CurrentUserId
	{
		get
		{
			return (Guid)Membership.GetUser().ProviderUserKey;
		}
	}
}