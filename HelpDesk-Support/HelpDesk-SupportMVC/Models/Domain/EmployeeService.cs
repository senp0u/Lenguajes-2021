using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk_SupportMVC.Models.Domain
{
    public class EmployeeService
    {
        private int employeeId;
        private int serviceId;
        private int createBy;
        private int modifyBy;
        private DateTime createDate;
        private DateTime modifyDate;

        private Employee employee;
        private Service service;

        public EmployeeService(int employeeId, int serviceId, int createBy, int modifyBy, DateTime createDate, DateTime modifyDate, Employee employee, Service service)
        {
            this.EmployeeId = employeeId;
            this.ServiceId = serviceId;
            this.CreateBy = createBy;
            this.ModifyBy = modifyBy;
            this.CreateDate = createDate;
            this.ModifyDate = modifyDate;
            this.Employee = employee;
            this.Service = service;
        }

        public EmployeeService() { }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }
        public int CreateBy { get => createBy; set => createBy = value; }
        public int ModifyBy { get => modifyBy; set => modifyBy = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime ModifyDate { get => modifyDate; set => modifyDate = value; }
        public Employee Employee { get => employee; set => employee = value; }
        public Service Service { get => service; set => service = value; }
    }
}
