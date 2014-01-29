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
	/// <summary>Initial email sent to a mentor to request a connection with them</summary>
	/// <param name="membershipUserMentor"></param>
	/// <param name="message"></param>
	/// <returns></returns>
	public static bool SendConnectEmailToMentor(MembershipUser membershipUserMentor, string message)
	{
		bool value = false;
		if (membershipUserMentor != null)
		{
			MembershipUser membershipUserMentee = Membership.GetUser();
			string baseUrl = Global.GetBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();
			// from
			// mailMessage.From = new MailAddress(Resources.Key.NoReplyEmail);
			mailMessage.From = new MailAddress(membershipUserMentee.Email);
			// bcc
			mailMessage.Bcc.Add(Resources.Key.EmailAccountInfo);
			// to
			mailMessage.To.Add(membershipUserMentor.Email);

			mailMessage.IsBodyHtml = true;
			mailMessage.Subject = "Cree Youth Mentorship: Connection Request";

			StringBuilder body = new StringBuilder();

			body.Append("<p>Someone wants you to be their mentor. See their personal message to you here:</p>");
			if (string.IsNullOrWhiteSpace(message)) { body.Append("<blockquote>No custom message sent</blockquote>"); }
			else { body.AppendFormat("<blockquote>{0}</blockquote>", message); }

			body.AppendFormat("<p>To accept this connection, click the following link to update your account connections:</p>", baseUrl);
			body.AppendFormat("<ul><li>{0}{1}</li></ul>", baseUrl, Resources.Key.ProfileUrl);
			body.AppendFormat("<p>If you have any questions, please contact us at {0}.</p>", baseUrl, Resources.Key.EmailAccountInfo);
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

	/// <summary>Email to the mentee from the mentor declining or accepting the mentoring request</summary>
	/// <param name="membershipUserMentee"></param>
	/// <returns></returns>
	public static bool SendConnectEmailToMentee(MembershipUser membershipUserMentee)
	{
		bool value = false;
		if (membershipUserMentee != null)
		{
			MembershipUser membershipUserMentor = Membership.GetUser();
			ProfileCommon profileCommonMentor = (ProfileCommon)ProfileCommon.Create(membershipUserMentor.UserName);

			string baseUrl = Global.GetBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();
			
			// from
			mailMessage.From = new MailAddress(membershipUserMentor.Email, profileCommonMentor.FullName);
			
			// bcc
			mailMessage.Bcc.Add(Resources.Key.EmailAccountInfo);
			
			// to
			mailMessage.To.Add(membershipUserMentee.Email);

			mailMessage.IsBodyHtml = true;
			mailMessage.Subject = "Cree Youth Mentorship: Connection Accepted";

			StringBuilder body = new StringBuilder();

			body.AppendFormat("<p>Your connection has been accepted by {0}</p>", profileCommonMentor.FullName);
			body.AppendFormat("<p>If you have any questions, please contact us at {0}.</p>", baseUrl, Resources.Key.EmailAccountInfo);
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
		bool value = false;
		if (membershipUser != null)
		{
			string baseUrl = Global.GetBaseUrl();
			// mail message
			MailMessage mailMessage = new MailMessage();
			// from
			mailMessage.From = new MailAddress(Resources.Key.EmailAccountInfo);
			// to
			mailMessage.To.Add(membershipUser.Email);

			// subject
			mailMessage.Subject = "Cree Youth Mentorship: Registration Confirmation";

			mailMessage.IsBodyHtml = true;
			StringBuilder body = new StringBuilder();
			body.AppendFormat("<p>Thank you for registering as a {0}!</p>", roleType.ToString());
			body.Append("<p>Your registration profile is now being reviewed and you will receive a confirmation email within 48hrs.</p>");
			body.AppendFormat("<p>If you have any questions, please contact us at {0}.</p>", baseUrl, Resources.Key.EmailAccountInfo);
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
	public static string GetBaseUrl()
	{
		return string.Format("{0}://{1}{2}",
			HttpContext.Current.Request.Url.Scheme,
			HttpContext.Current.Request.Url.Authority,
			HttpContext.Current.Request.ApplicationPath).TrimEnd('/');
	}
}