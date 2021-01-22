using System;
using System.Collections.Generic;

#nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class Note
    {
        public int NotesId { get; set; }
        public string Description { get; set; }
        public DateTime NoteDate { get; set; }
        public int ReportNumber { get; set; }
        public int? EmployeeId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Issue ReportNumberNavigation { get; set; }
    }
}
