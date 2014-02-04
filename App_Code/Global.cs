using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for Global
/// </summary>
public static class Global
{
	public static readonly string EmailRegEx = @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$";

	/// <summary>Initial email sent to a mentor to request a connection with them</summary>
	/// <param name="membershipUserMentor"></param>
	/// <param name="message"></param>
	/// <returns></returns>
	public static bool SendConnectEmailToMentor(MembershipUser membershipUserMentor, string message)
	{
		/*
		 * from: noreply
		 * to: mentor
		 */

		bool value = false;
		if (membershipUserMentor != null)
		{
			MembershipUser membershipUserMentee = Membership.GetUser();
			string baseUrl = Global._getBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();
			// from
			// mailMessage.From = new MailAddress(Resources.Key.NoReplyEmail);
			mailMessage.From = new MailAddress(Resources.Key.EmailAccountNoReply);

			// bcc
			// mailMessage.Bcc.Add(Resources.Key.EmailAccountInfo);

			// to
			mailMessage.To.Add(membershipUserMentor.Email);

			mailMessage.IsBodyHtml = true;
			mailMessage.Subject = "Cree Youth Mentorship: Connection Request";

			StringBuilder body = new StringBuilder();
			string url = string.Format("{0}{1}", _getBaseUrl(), Resources.Key.ProfileUrl);

			ProfileCommon profileCommon = GetProfile(membershipUserMentee.UserName);
			body.AppendFormat("<p>{0} wants you to be his/her mentor. See his/her personal message to you here:</p>", profileCommon.FullName);
			if (string.IsNullOrWhiteSpace(message)) { body.Append("<blockquote>No custom message sent</blockquote>"); }
			else { body.AppendFormat("<blockquote>{0}</blockquote>", message); }

			body.AppendFormat("<p>To accept this connection, click the following link to update your account connections:</p>", baseUrl);
			body.AppendFormat("<ul><li><a href=\"{0}\">{0}</a></li></ul>", url);
			body.AppendFormat(_getEmailFooter(baseUrl));
			mailMessage.Body = body.ToString();
			try
			{
				new SmtpClient().Send(mailMessage);
				value = true;
			}
			catch (SmtpFailedRecipientException) { value = false; }
		}
		return value;
	}

	/// <summary>Email to the mentee from the mentor accepting the mentoring request</summary>
	/// <param name="membershipUserMentee"></param>
	/// <returns></returns>
	public static bool SendConnectEmailToMentee(MembershipUser membershipUserMentee)
	{
		/*
		 * from: mentor
		 * to: mentee
		 */
		bool value = false;
		if (membershipUserMentee != null)
		{
			MembershipUser membershipUserMentor = Membership.GetUser();
			ProfileCommon profileCommonMentor = GetProfile(membershipUserMentor.UserName);

			string baseUrl = Global._getBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();

			// from
			mailMessage.From = new MailAddress(membershipUserMentor.Email, profileCommonMentor.FullName);

			// bcc
			// mailMessage.Bcc.Add(Resources.Key.EmailAccountAdmin);

			// to
			mailMessage.To.Add(membershipUserMentee.Email);

			mailMessage.IsBodyHtml = true;
			mailMessage.Subject = "Cree Youth Mentorship: Connection Accepted";

			StringBuilder body = new StringBuilder();

			body.AppendFormat("<p>Your connection has been accepted by {0}</p>", profileCommonMentor.FullName);
			body.AppendFormat("<p>You can now communicate with your mentor using the following email address:</p>");
			body.AppendFormat("<ul><li>{0}</li></ul>", membershipUserMentor.Email);
			body.AppendFormat(_getEmailFooter(baseUrl));
			mailMessage.Body = body.ToString();
			try
			{
				new SmtpClient().Send(mailMessage);
				value = true;
			}
			catch (SmtpFailedRecipientException) { value = false; }
		}
		return value;
	}

	public static bool SendRegistrationEmail(MembershipUser membershipUser, RoleType roleType)
	{
		/*
		 * from: noreply
		 * to: registrant
		 * bcc: admin
		 */

		bool value = false;
		if (membershipUser != null)
		{
			string baseUrl = Global._getBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();
			// from
			mailMessage.From = new MailAddress(Resources.Key.EmailAccountNoReply);

			// to
			mailMessage.To.Add(membershipUser.Email);

			// bcc
			mailMessage.Bcc.Add(Resources.Key.EmailAccountAdmin);

			// subject
			mailMessage.Subject = "Cree Youth Mentorship: Registration Confirmation";

			mailMessage.IsBodyHtml = true;
			StringBuilder body = new StringBuilder();
			body.AppendFormat("<p>Thank you for registering as a {0}!</p>", roleType.ToString());
			body.Append("<p>Your registration profile is now being reviewed and you will receive a confirmation email within 48hrs.</p>");
			body.AppendFormat(_getEmailFooter(baseUrl));
			mailMessage.Body = body.ToString();
			try
			{
				new SmtpClient().Send(mailMessage);
				value = true;
			}
			catch (SmtpFailedRecipientException) { value = false; }
		}
		return value;
	}

	public static bool SendRegistrationApprovedEmail(MembershipUser membershipUser)
	{
		/*
		 * from: noreply
		 * to: member
		 * bcc: admin
		 */

		bool value = false;
		if (membershipUser != null)
		{
			string baseUrl = Global._getBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();
			// from
			mailMessage.From = new MailAddress(Resources.Key.EmailAccountNoReply);

			// to
			mailMessage.To.Add(membershipUser.Email);

			// bcc
			mailMessage.Bcc.Add(Resources.Key.EmailAccountAdmin);

			// subject
			mailMessage.Subject = "Cree Youth Mentorship: Registration Approved";

			mailMessage.IsBodyHtml = true;
			string url = string.Format("{0}{1}", _getBaseUrl(), Resources.Key.ProfileUrl);
			StringBuilder body = new StringBuilder();
			body.Append("<p>Your account has been reviewed and approved!</p>");
			body.Append("<p>To get started, log in to your profile using the following link:</p>");
			body.AppendFormat("<ul><li><a href=\"{0}\">{0}</a></li></ul>", url);
			body.AppendFormat(_getEmailFooter(baseUrl));
			mailMessage.Body = body.ToString();
			try
			{
				new SmtpClient().Send(mailMessage);
				value = true;
			}
			catch (SmtpFailedRecipientException) { value = false; }
		}
		return value;
	}

	/// <returns>http://www.mydomainname.com</returns>
	private static string _getBaseUrl()
	{
		return string.Format("{0}://{1}{2}",
			HttpContext.Current.Request.Url.Scheme,
			HttpContext.Current.Request.Url.Authority,
			HttpContext.Current.Request.ApplicationPath).TrimEnd('/');
	}

	public static ProfileCommon GetProfile(string username) { return (ProfileCommon)ProfileCommon.Create(username); }

	private static string _getEmailFooter(string baseUrl)
	{
		return string.Format("<p>If you have any questions, please contact us at <a href=\"mailto://{0}\">{0}</a>.</p>", Resources.Key.EmailAccountAdmin);
	}
}