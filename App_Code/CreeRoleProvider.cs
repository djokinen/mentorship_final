using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class CreeRoleProvider : SqlRoleProvider
{
	public override void CreateRole(string roleName)
	{
		base.CreateRole(roleName);
	}
}