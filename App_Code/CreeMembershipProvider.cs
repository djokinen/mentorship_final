using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

public class CreeMembershipProvider : SqlMembershipProvider
{
	public override bool ChangePassword(string username, string oldPassword, string newPassword)
	{
		return base.ChangePassword(username, oldPassword, newPassword);
	}

	public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
	{
		// use email as username
		return base.CreateUser(username, password, username, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
	}

	public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
	{
		return base.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
	}

	public override bool DeleteUser(string username, bool deleteAllRelatedData)
	{
		return base.DeleteUser(username, deleteAllRelatedData);
	}

	public override bool ValidateUser(string username, string password)
	{
		return base.ValidateUser(username, password);
	}
}