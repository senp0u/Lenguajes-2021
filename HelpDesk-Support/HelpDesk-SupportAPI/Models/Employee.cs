using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeService = new HashSet<EmployeeService>();
            InverseSupervisor = new HashSet<Employee>();
            IssueEmployee = new HashSet<Issue>();
            IssueSupervisor = new HashSet<Issue>();
            Notes = new HashSet<Notes>();
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
        public string Password { get; set; }

        public virtual Employee Supervisor { get; set; }
        public virtual ICollection<EmployeeService> EmployeeService { get; set; }
        public virtual ICollection<Employee> InverseSupervisor { get; set; }
        public virtual ICollection<Issue> IssueEmployee { get; set; }
        public virtual ICollection<Issue> IssueSupervisor { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
    }
}
