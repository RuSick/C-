using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Human
    {
        public int Id { get; set; }
        public string FI { get; set; }
        public string PhoneNumber { get; set; }
        public string Job { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
