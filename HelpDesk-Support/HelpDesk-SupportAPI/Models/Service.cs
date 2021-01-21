using System;
using System.Collections.Generic;

#nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class Service
    {
        public Service()
        {
            EmployeeServices = new HashSet<EmployeeService>();
            Issues = new HashSet<Issue>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
