using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.DataAccessLayer;

namespace RecruitmentTracker.ServiceLayer
{
    public class DelApplicantInfo
    {
        public bool RemoveApplicantInfo(int id)
        {
            return new ApplicantInfoBusiness(new DLApplicantInfo()).RemoveApplicantInfo(id);
        }
    }
}
