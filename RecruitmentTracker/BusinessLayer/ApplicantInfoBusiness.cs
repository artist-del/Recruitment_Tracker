using RecruitmentTracker.DataAccessLayer;
using RecruitmentTracker.Models;
using System;
using System.Text.RegularExpressions;

namespace RecruitmentTracker.BusinessLayer
{
    public class ApplicantInfoBusiness
    {
        private readonly IApplicantInfo _applicantInfo;

        public ApplicantInfoBusiness(IApplicantInfo applicantInfo)
        {
            this._applicantInfo = applicantInfo;
        }

        public bool Save(string ApplicantFirstName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName)
        {
            return this._applicantInfo.Save(ApplicantFirstName, ApplicantPosition, ApplicantStatus, ApplicantStatusDetail, ApplicantInterview, ApplicantExpSalary, ApplicantRecSalary, ApplicantCurSalary, ApplicantComment, ApplicantMiddleName, ApplicantLastName);
        }

        public ApplicantInfo GetApplicantInfo(int id)
        {
            return this._applicantInfo.GetApplicantInfo(id);
        }

        public bool UpdateApplicantInfo(int Id, string ApplicantFullName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName)
        {
            return this._applicantInfo.UpdateApplicantInfo(Id, ApplicantFullName, ApplicantPosition, ApplicantStatus, ApplicantStatusDetail, ApplicantInterview, ApplicantExpSalary, ApplicantRecSalary, ApplicantCurSalary, ApplicantComment, ApplicantMiddleName, ApplicantLastName);
        }

        public bool RemoveApplicantInfo(int id)
        {
            return this._applicantInfo.RemoveApplicantInfo(id);
        }

        public bool CheckLogin(string email, string password)
        {
            return this._applicantInfo.CheckLogin(email, password);
        }

        public bool AddNewAdmin(string FullName, string Email, string Username, string Password)
        {
            if (string.IsNullOrEmpty(FullName))
            {
                return false;
            }
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Username))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                return false;
            }

            return this._applicantInfo.AddNewAdmin(FullName, Email, Username, Password);
        }
    }
}
