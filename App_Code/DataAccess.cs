using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Security;

public class DataAccess
{
	#region cree_Industry

	public cree_Industry GetIndustry(int id)
	{
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			return context.cree_Industries.Where(n => n.Enabled).SingleOrDefault(n => n.ID == id);
		}
	}

	public List<cree_Industry> GetIndustryList()
	{
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			return context.cree_Industries.Where(n => n.Enabled).ToList();
		}
	}

	public List<cree_Industry> GetIndustryListByMentor(Guid userIdMentor)
	{
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			return (from t in context.cree_MentorIndustries
					  where t.UserIdMentor == userIdMentor
					  orderby t.cree_Industry.Name
					  select t.cree_Industry).ToList();
		}
	}

	public List<cree_Industry> GetIndustryListAvailable(Guid userIdMentor)
	{
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			IEnumerable<cree_Industry> mentorIndustries = from t in context.cree_MentorIndustries
																		 where t.UserIdMentor == userIdMentor
																		 select t.cree_Industry;

			return context.cree_Industries.Except(mentorIndustries).OrderBy(n => n.Name).ToList();
		}
	}

	#endregion

	#region cree_MentorIndustry

	public void SetMentorIndustryList(Guid userIdMentor, string industryIdsAsCsv)
	{
		int[] industryIds;

		if (string.IsNullOrWhiteSpace(industryIdsAsCsv)) { industryIds = null; }
		else { industryIds = industryIdsAsCsv.Split(',').Select(n => Convert.ToInt32(n)).ToArray(); }

		this.SetMentorIndustryList(userIdMentor, industryIds);
	}

	public void SetMentorIndustryList(Guid userIdMentor, int[] industryIds)
	{
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			var mentorIndustries = context.cree_MentorIndustries.Where(n => n.UserIdMentor == userIdMentor);
			context.cree_MentorIndustries.DeleteAllOnSubmit(mentorIndustries);
			context.SubmitChanges();

			if (industryIds != null)
			{
				cree_MentorIndustry mentorIndustry;
				for (int i = 0; i < industryIds.Count(); i++)
				{
					mentorIndustry = new cree_MentorIndustry();
					mentorIndustry.IndustryId = industryIds[i];
					mentorIndustry.UserIdMentor = userIdMentor;
					mentorIndustry.CreatedDate = DateTime.Now;
					context.cree_MentorIndustries.InsertOnSubmit(mentorIndustry);
				}
				context.SubmitChanges();
			}
		}
	}

	#endregion

	#region cree_MenteeMentor

	/// <summary>Try and get the mentor for the logged in user</summary>
	public cree_MenteeMentor GetMenteeMentor(Guid userIdMentor)
	{
		Guid userIdMentee = (Guid)Membership.GetUser().ProviderUserKey;
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			return (from t in context.cree_MenteeMentors
					  where t.UserIdMentee == userIdMentee && t.UserIdMentor == userIdMentor
					  select t).SingleOrDefault();
		}
	}

	/// <summary>Get all mentees connected to the logged in user</summary>
	/// <returns></returns>
	public List<cree_MenteeMentor> GetMenteeMentor()
	{
		Guid userIdMentor = (Guid)Membership.GetUser().ProviderUserKey;
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			return (from t in context.cree_MenteeMentors
					  where t.UserIdMentor == userIdMentor
					  orderby t.ConnectionStatus descending
					  select t).ToList();
		}
	}

	public cree_MenteeMentor SetMenteeMentor(Guid userIdMentee, Guid userIdMentor, int connectionStatusId)
	{
		using (DataClassesDataContext context = new DataClassesDataContext())
		{
			var menteeMentor = context.cree_MenteeMentors.Where(n => n.UserIdMentee == userIdMentee && n.UserIdMentor == userIdMentor).SingleOrDefault();

			if (menteeMentor == null)
			{
				// insert
				menteeMentor = new cree_MenteeMentor();
				menteeMentor.UserIdMentee = userIdMentee;
				menteeMentor.UserIdMentor = userIdMentor;
				menteeMentor.ConnectionStatus = connectionStatusId;
				menteeMentor.CreatedDate = DateTime.Now;
				menteeMentor.ModifiedDate = menteeMentor.CreatedDate;
				context.cree_MenteeMentors.InsertOnSubmit(menteeMentor);
				context.SubmitChanges();
			}
			else
			{
				// update
				menteeMentor.ConnectionStatus = connectionStatusId;
				menteeMentor.ModifiedDate = DateTime.Now;
				context.SubmitChanges();
			}
			return menteeMentor;
		}
	}

	#endregion
}