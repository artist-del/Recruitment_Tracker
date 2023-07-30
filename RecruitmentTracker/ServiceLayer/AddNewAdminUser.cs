using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.DataAccessLayer;

namespace RecruitmentTracker.ServiceLayer
{
    public class AddNewAdminUser
    {
        public bool AddNewAdmin(string FullName, string Email, string Username, string Password)
        {
            return new ApplicantInfoBusiness(new DLApplicantInfo()).AddNewAdmin(FullName, Email, Username, Password);
        }
    }
}
