using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk_SupportMVC.Models.Domain
{
    public class Employee
    {

        private int employeeId;
        private string name;
        private string firstSurname;
        private string secondSurname;

        [Required(ErrorMessage = "Se requiere el correo.")]
        private string email;

        [Required(ErrorMessage = "Se requiere la contraseña.")]
        private string password;
        private bool isSupervisor;
        private int supervisorId;
        private int createBy;
        private int? modifyBy;
        private DateTime createDate;
        private DateTime? modifyDate;

        private Employee supervisor;
        private ICollection<EmployeeService> employeeServices;
        private ICollection<Employee> inverseSupervisor;
        private ICollection<Issue> issueEmployees;
        private ICollection<Issue> issueSupervisors;
        private ICollection<Note> notes;

        public Employee(int employeeId, string name, string firstSurname, string secondSurname, string email, string password, bool isSupervisor, int supervisorId, int createBy, int modifyBy, DateTime createDate, DateTime modifyDate, Employee supervisor, ICollection<EmployeeService> employeeServices, ICollection<Employee> inverseSupervisor, ICollection<Issue> issueEmployees, ICollection<Issue> issueSupervisors, ICollection<Note> notes)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.FirstSurname = firstSurname;
            this.SecondSurname = secondSurname;
            this.Email = email;
            this.Password = password;
            this.IsSupervisor = isSupervisor;
            this.SupervisorId = supervisorId;
            this.CreateBy = createBy;
            this.ModifyBy = modifyBy;
            this.CreateDate = createDate;
            this.ModifyDate = modifyDate;
            this.Supervisor = supervisor;
            this.EmployeeServices = employeeServices;
            this.InverseSupervisor = inverseSupervisor;
            this.IssueEmployees = issueEmployees;
            this.IssueSupervisors = issueSupervisors;
            this.Notes = notes;
        }

        public Employee(){}


        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string Name { get => name; set => name = value; }
        public string FirstSurname { get => firstSurname; set => firstSurname = value; }
        public string SecondSurname { get => secondSurname; set => secondSurname = value; }

        [Required(ErrorMessage = "Se requiere el correo.")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Se requiere la contraseña.")]
        public string Password { get => password; set => password = value; }
        public bool IsSupervisor { get => isSupervisor; set => isSupervisor = value; }
        public int SupervisorId { get => supervisorId; set => supervisorId = value; }
        public int CreateBy { get => createBy; set => createBy = value; }
        public int? ModifyBy { get => modifyBy; set => modifyBy = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime? ModifyDate { get => modifyDate; set => modifyDate = value; }
        public Employee Supervisor { get => supervisor; set => supervisor = value; }
        public ICollection<EmployeeService> EmployeeServices { get => employeeServices; set => employeeServices = value; }
        public ICollection<Employee> InverseSupervisor { get => inverseSupervisor; set => inverseSupervisor = value; }
        public ICollection<Issue> IssueEmployees { get => issueEmployees; set => issueEmployees = value; }
        public ICollection<Issue> IssueSupervisors { get => issueSupervisors; set => issueSupervisors = value; }
        public ICollection<Note> Notes { get => notes; set => notes = value; }

    }
}
