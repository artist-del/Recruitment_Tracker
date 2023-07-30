using RecruitmentTracker.Models;

namespace RecruitmentTracker.BusinessLayer
{
    public interface IApplicantInfo
    {
        public bool Save(string ApplicantFirstName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName);

        public ApplicantInfo GetApplicantInfo(int id);

        public bool RemoveApplicantInfo(int id);

        public bool UpdateApplicantInfo(int Id, string ApplicantFullName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName);

        public bool CheckLogin(string email, string password);

        public bool AddNewAdmin(string FullName, string Email, string Username, string Password);
    }
}
