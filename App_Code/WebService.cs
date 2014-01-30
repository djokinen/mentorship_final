using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WebService : System.Web.Services.WebService
{
	[WebMethod]
	public int ConnectWithMentor(Guid userIdMentor, string message)
	{
		int value = ConnectionStatus.None.GetHashCode();
		MembershipUser userMentee = Membership.GetUser();
		if (userMentee != null)
		{
			MembershipUser userMentor = Membership.GetUser(userIdMentor);
			if (userMentor != null)
			{
				cree_MenteeMentor menteeMentor = new DataAccess().SetMenteeMentor((Guid)userMentee.ProviderUserKey, (Guid)userMentor.ProviderUserKey, ConnectionStatus.Pending.GetHashCode());
				if (menteeMentor != null)
				{
					value = menteeMentor.ConnectionStatus.GetHashCode();
					bool sent = Global.SendConnectEmailToMentor(userMentor, message);
				}
			}
		}
		return value;
	}

	[WebMethod]
	public int ConnectWithMentee(Guid userIdMentee, int connectionStatusId)
	{
		MembershipUser userMentor = Membership.GetUser();
		if (userMentor != null)
		{
			MembershipUser userMentee = Membership.GetUser(userIdMentee);
			if (userMentee != null)
			{
				cree_MenteeMentor menteeMentor = new DataAccess().SetMenteeMentor((Guid)userMentee.ProviderUserKey, (Guid)userMentor.ProviderUserKey, connectionStatusId);
				if (menteeMentor != null)
				{
					if (connectionStatusId == ConnectionStatus.Accepted.GetHashCode())
					{
						bool sent = Global.SendConnectEmailToMentee(userMentee);
					}
					return menteeMentor.ConnectionStatus.GetHashCode();
				}
			}
		}
		return ConnectionStatus.None.GetHashCode();
	}

	[WebMethod]
	public bool UpdateUser(Guid userId, bool isApproved)
	{
		// check if current user is an admin
		bool isAdmin = Roles.IsUserInRole(Membership.GetUser().UserName, RoleType.Admin.ToString());
		if (isAdmin)
		{
			MembershipUser membershipUser = Membership.GetUser(userId);
			if (membershipUser != null)
			{
				membershipUser.IsApproved = isApproved;
				Membership.UpdateUser(membershipUser);

				if (isApproved)
				{
					Global.SendRegistrationApprovedEmail(membershipUser);
				}
				return true;
			}
		}
		return false;
	}
}