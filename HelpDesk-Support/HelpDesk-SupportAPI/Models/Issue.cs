using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Notes = new HashSet<Notes>();
        }

        public int ReportNumber { get; set; }
        public string Classification { get; set; }
        public string Status { get; set; }
        public DateTime? ReportDate { get; set; }
        public string ResolutionComment { get; set; }
        public int? EmployeeId { get; set; }
        public int? SupervisorId { get; set; }
        public int ServiceId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
        public virtual Employee Supervisor { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
    }
}
