using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSFCRegistration.Models
{
    [Table("StudentProgramme")]
    public class StudentProgramme
    {
        public StudentProgramme()
        {

        }
        
        [Key]
        public string STUDENT_ID { get; set; }
        public string SCHOOL { get; set; }
        public string PROGRAMME_CODE { get; set; }
        public string PROGRAMME_TITLE { get; set; }
        public string STAGE { get; set; }
        public string LAST_NAME { get; set; }
        public string FIRST_NAME { get; set; }
        public string EMAIL_GROUP { get; set; }

    }
}
