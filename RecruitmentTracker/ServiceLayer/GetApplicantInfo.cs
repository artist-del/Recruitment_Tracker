using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.DataAccessLayer;
using RecruitmentTracker.Models;

namespace RecruitmentTracker.ServiceLayer
{
    public class GetApplicantInfo
    {
        public ApplicantInfo ApplicantInfo(int id)
        {
            return new ApplicantInfoBusiness(new DLApplicantInfo()).GetApplicantInfo(id);
        }
    }
}
