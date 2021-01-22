using System;
using System.Collections.Generic;

#nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class EmployeeService
    {
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
    }
}
