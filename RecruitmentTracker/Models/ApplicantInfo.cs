using System.ComponentModel.DataAnnotations;

namespace RecruitmentTracker.Models
{
    public class ApplicantInfo
    {
        [Key]
        public int ApplicantId { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantPosition { get; set; }
        public string ApplicantStatus { get; set; }
        public string ApplicantStatusDetail { get; set; }
        public string ApplicantInterview { get; set; }
        public string ApplicantExpSalary { get; set; }
        public string ApplicantRecSalary { get; set; }
        public string ApplicantCurSalary { get; set; }
        public string ApplicantComment { get; set; }
        public string ApplicantMiddleName { get; set; }
        public string ApplicantLastName { get; set; }
    }
}
