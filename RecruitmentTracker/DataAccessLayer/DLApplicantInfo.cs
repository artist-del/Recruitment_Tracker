using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RecruitmentTracker.BusinessLayer;
using RecruitmentTracker.Data;
using RecruitmentTracker.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace RecruitmentTracker.DataAccessLayer
{
    public class DLApplicantInfo:BaseDataAccess, IApplicantInfo
    {

        public bool Save(string ApplicantFirstName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName)
        {
            try
            {
                using (var _context = new MyDbContext(this.builder.Options))
                {
                    var fullName = new SqlParameter("@fullName", SqlDbType.VarChar) { Value = ApplicantFirstName };
                    var position = new SqlParameter("@position", SqlDbType.VarChar) { Value =  ApplicantPosition};
                    var status = new SqlParameter("@status", SqlDbType.VarChar) { Value = ApplicantStatus };
                    var statusDetail = new SqlParameter("@statusDetail", SqlDbType.VarChar) { Value = ApplicantStatusDetail };
                    var interview = new SqlParameter("@interview", SqlDbType.VarChar) { Value = ApplicantInterview };
                    var expSalary = new SqlParameter("@expSalary", SqlDbType.VarChar) { Value = ApplicantExpSalary };
                    var recSalary = new SqlParameter("@recSalary", SqlDbType.VarChar) { Value = ApplicantRecSalary };
                    var curSalary = new SqlParameter("@curSalary", SqlDbType.VarChar) { Value = ApplicantCurSalary };
                    var comment = new SqlParameter("@comment", SqlDbType.VarChar) { Value = ApplicantComment };
                    var middleName = new SqlParameter("@middleName", SqlDbType.VarChar) { Value = ApplicantMiddleName };
                    var lastName = new SqlParameter("@lastName", SqlDbType.VarChar) { Value = ApplicantLastName };

                    _context.Database.ExecuteSqlRaw("EXECUTE pr_SaveApplicantInfo @fullName, @position, @status, @statusDetail, @interview, @expSalary, @recSalary, @curSalary, @comment", fullName, position, status, statusDetail, interview, expSalary, recSalary, curSalary, comment, middleName, lastName);
                }
                return true;

            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public ApplicantInfo GetApplicantInfo(int id)
        {
            using (var _context = new MyDbContext(this.builder.Options))
            {

                var list = _context.ApplicantInfo.FromSqlRaw("EXEC pr_GetApplicantInfo @Id={0}", id).ToList();

                return list.FirstOrDefault();
            }
        }

        public bool UpdateApplicantInfo(int Id, string ApplicantFullName, string ApplicantPosition, string ApplicantStatus, string ApplicantStatusDetail, string ApplicantInterview, string ApplicantExpSalary, string ApplicantRecSalary, string ApplicantCurSalary, string ApplicantComment, string ApplicantMiddleName, string ApplicantLastName)
        {
            try
            {
                using(var _context = new MyDbContext(this.builder.Options))
                {
                    _context.Database.ExecuteSqlRaw("EXECUTE pr_UpdateApplicantInfo @Id={0}, @FullName={1}, @Position={2}, @Status={3}, @StatusDetail={4}, @Interview={5}, @ExpSalary={6}, @RecSalary={7}, @CurSalary={8}, @Comment={9}, @middleName={10}, @lastName={11}",
                                                                                        Id,
                                                                                        ApplicantFullName,
                                                                                        ApplicantPosition,
                                                                                        ApplicantStatus,
                                                                                        ApplicantStatusDetail,
                                                                                        ApplicantInterview,
                                                                                        ApplicantExpSalary,
                                                                                        ApplicantRecSalary,
                                                                                        ApplicantCurSalary,
                                                                                        ApplicantComment,
                                                                                        ApplicantMiddleName,
                                                                                        ApplicantLastName);
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool RemoveApplicantInfo(int id)
        {
            try
            {

                using(var _context = new MyDbContext(this.builder.Options))
                {
                    _context.Database.ExecuteSqlRaw("EXECUTE pr_RemoveApplicantInfo @Id={0}", id);
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool CheckLogin(string email, string password)
        {
            try
            {
                string query = "EXEC pr_CheckLogin @Email={0}, @Password={1}, @is_valid={2} OUT";
                bool IsValid;

                using (var _context = new MyDbContext(this.builder.Options))
                {
                    SqlParameter[] parameter =
                    {
                        new SqlParameter("@Email", email),
                        new SqlParameter("@Password", password),
                        new SqlParameter("@is_valid", SqlDbType.Bit){Direction = ParameterDirection.Output}
                    };

                    _context.Database.ExecuteSqlRaw(query, parameter);

                    IsValid = (bool)parameter[2].Value;
                }
                return IsValid;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool AddNewAdmin(string FullName, string Email, string Username, string Password)
        {
            try
            {
                string query = "EXEC pr_AddNewAdmin @FullName ={0}, @Email ={1}, @Username={2}, @Password={3}";
                using(var _context = new MyDbContext(this.builder.Options))
                {
                    _context.Database.ExecuteSqlRaw(query, FullName, Email, Username, Password);
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
