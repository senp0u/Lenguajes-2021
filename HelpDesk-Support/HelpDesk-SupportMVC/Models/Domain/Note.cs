using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk_SupportMVC.Models.Domain
{
    public class Note
    {
        private int notesId;
        private string description;
        private DateTime noteDate;
        private int reportNumber;
        private int? employeeId;
        private int createBy;
        private int? modifyBy;
        private DateTime createDate;
        private DateTime? modifyDate;

        private Employee employee;
        private Issue reportNumberNavigation;

        public Note(int notesId, string description, DateTime noteDate, int reportNumber, int employeeId, int createBy, int modifyBy, DateTime createDate, DateTime modifyDate, Employee employee, Issue reportNumberNavigation)
        {
            this.NotesId = notesId;
            this.Description = description;
            this.NoteDate = noteDate;
            this.ReportNumber = reportNumber;
            this.EmployeeId = employeeId;
            this.CreateBy = createBy;
            this.ModifyBy = modifyBy;
            this.CreateDate = createDate;
            this.ModifyDate = modifyDate;
            this.Employee = employee;
            this.ReportNumberNavigation = reportNumberNavigation;
        }

        public Note() {}

        public int NotesId { get => notesId; set => notesId = value; }
        public string Description { get => description; set => description = value; }
        public DateTime NoteDate { get => noteDate; set => noteDate = value; }
        public int ReportNumber { get => reportNumber; set => reportNumber = value; }
        public int? EmployeeId { get => employeeId; set => employeeId = value; }
        public int CreateBy { get => createBy; set => createBy = value; }
        public int? ModifyBy { get => modifyBy; set => modifyBy = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime? ModifyDate { get => modifyDate; set => modifyDate = value; }
        public Employee Employee { get => employee; set => employee = value; }
        public Issue ReportNumberNavigation { get => reportNumberNavigation; set => reportNumberNavigation = value; }


    }
}
