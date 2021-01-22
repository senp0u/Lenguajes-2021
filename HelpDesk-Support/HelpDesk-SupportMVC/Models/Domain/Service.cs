using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk_SupportMVC.Models.Domain
{
    public class Service
    {
        private int serviceId;
        private string name;
        private int createBy;
        private int modifyBy;
        private DateTime createDate;
        private DateTime modifyDate;

        private ICollection<EmployeeService> employeeServices;
        private ICollection<Issue> issues;

        public Service(int serviceId, string name, int createBy, int modifyBy, DateTime createDate, DateTime modifyDate, ICollection<EmployeeService> employeeServices, ICollection<Issue> issues)
        {
            this.serviceId = serviceId;
            this.name = name;
            this.createBy = createBy;
            this.modifyBy = modifyBy;
            this.createDate = createDate;
            this.modifyDate = modifyDate;
            this.employeeServices = employeeServices;
            this.issues = issues;
        }

        public Service() { }
        public int ServiceId { get => serviceId; set => serviceId = value; }
        public string Name { get => name; set => name = value; }
        public int CreateBy { get => createBy; set => createBy = value; }
        public int ModifyBy { get => modifyBy; set => modifyBy = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime ModifyDate { get => modifyDate; set => modifyDate = value; }
        public ICollection<EmployeeService> EmployeeServices { get => employeeServices; set => employeeServices = value; }
        public ICollection<Issue> Issues { get => issues; set => issues = value; }
    }
}
