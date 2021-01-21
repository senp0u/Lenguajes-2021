using System;
using System.Collections.Generic;

#nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeServices = new HashSet<EmployeeService>();
            InverseSupervisor = new HashSet<Employee>();
            IssueEmployees = new HashSet<Issue>();
            IssueSupervisors = new HashSet<Issue>();
            Notes = new HashSet<Note>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public bool IsSupervisor { get; set; }
        public int SupervisorId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Employee Supervisor { get; set; }
        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public virtual ICollection<Employee> InverseSupervisor { get; set; }
        public virtual ICollection<Issue> IssueEmployees { get; set; }
        public virtual ICollection<Issue> IssueSupervisors { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
