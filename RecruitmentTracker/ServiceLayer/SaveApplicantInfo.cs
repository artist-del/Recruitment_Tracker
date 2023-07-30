using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.Data;
using RecruitmentTracker.DataAccessLayer;
using RecruitmentTracker.Models;

namespace RecruitmentTracker.ServiceLayer
{
    public class SaveApplicantInfo
    {
       public bool SaveApplicantInfoService(string ApplicantFirstName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName)
        {
           return new ApplicantInfoBusiness(new DLApplicantInfo()).Save(ApplicantFirstName, ApplicantPosition, ApplicantStatus, ApplicantStatusDetail, ApplicantInterview, ApplicantExpSalary, ApplicantRecSalary, ApplicantCurSalary, ApplicantComment, ApplicantMiddleName, ApplicantLastName);
        }
    }
}
