using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.DataAccessLayer;

namespace RecruitmentTracker.ServiceLayer
{
    public class CheckLog
    {
        public bool CheckLogin(string email, string password)
        {
            return new ApplicantInfoBusiness(new DLApplicantInfo()).CheckLogin(email, password);
        }
    }
}
