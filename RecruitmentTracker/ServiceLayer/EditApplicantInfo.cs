using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.DataAccessLayer;

namespace RecruitmentTracker.ServiceLayer
{
    public class EditApplicantInfo
    {
        public bool UpdateApplicantInfo(int Id, string ApplicantFullName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName)
        {
            return new ApplicantInfoBusiness(new DLApplicantInfo()).UpdateApplicantInfo(Id, ApplicantFullName, ApplicantPosition, ApplicantStatus, ApplicantStatusDetail, ApplicantInterview, ApplicantExpSalary, ApplicantRecSalary, ApplicantCurSalary, ApplicantComment, ApplicantMiddleName, ApplicantLastName);
        }
    }
}
