using System.ComponentModel.DataAnnotations;

namespace NhsLesson07.Models
{
    public class NhsEmployee
    {      
        public int NhsId { get; set; }   
        public string NhsName { get; set; }       
        public DateTime NhsBirthDay { get; set; }
        public string NhsEmail { get; set; }
        public string NhsPhone { get; set; }
        public decimal NhsSalary { get; set; }
        public bool NhsStatus { get; set; }
    }
}
