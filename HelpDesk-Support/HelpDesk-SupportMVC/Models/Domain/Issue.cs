using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk_SupportMVC.Models.Domain
{
    public class Issue
    {
        private int reportNumber;
        private string classification;
        private string status;
        private DateTime reportDate;
        private string resolutionComment;
        private int? employeeId;
        private int? supervisorId;
        private int serviceId;
        private int createBy;
        private int? modifyBy;
        private DateTime createDate;
        private DateTime? modifyDate;

        private Employee employee;
        private Service service;
        private Employee supervisor;
        private ICollection<Note> notes;

        public Issue(int reportNumber, string classification, string status, DateTime reportDate, string resolutionComment, int employeeId, int supervisorId, int serviceId, int createBy, int modifyBy, DateTime createDate, DateTime modifyDate, Employee employee, Service service, Employee supervisor, ICollection<Note> notes)
        {
            this.ReportNumber = reportNumber;
            this.Classification = classification;
            this.Status = status;
            this.ReportDate = reportDate;
            this.ResolutionComment = resolutionComment;
            this.EmployeeId = employeeId;
            this.SupervisorId = supervisorId;
            this.ServiceId = serviceId;
            this.CreateBy = createBy;
            this.ModifyBy = modifyBy;
            this.CreateDate = createDate;
            this.ModifyDate = modifyDate;
            this.Employee = employee;
            this.Service = service;
            this.Supervisor = supervisor;
            this.Notes = notes;
        }

        public Issue() {}

        public int ReportNumber { get => reportNumber; set => reportNumber = value; }
        public string Classification { get => classification; set => classification = value; }
        public string Status { get => status; set => status = value; }
        public DateTime ReportDate { get => reportDate; set => reportDate = value; }
        public string ResolutionComment { get => resolutionComment; set => resolutionComment = value; }
        public int? EmployeeId { get => employeeId; set => employeeId = value; }
        public int? SupervisorId { get => supervisorId; set => supervisorId = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }
        public int CreateBy { get => createBy; set => createBy = value; }
        public int? ModifyBy { get => modifyBy; set => modifyBy = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime? ModifyDate { get => modifyDate; set => modifyDate = value; }
        public Employee Employee { get => employee; set => employee = value; }
        public Service Service { get => service; set => service = value; }
        public Employee Supervisor { get => supervisor; set => supervisor = value; }
        public ICollection<Note> Notes { get => notes; set => notes = value; }


    }
}
