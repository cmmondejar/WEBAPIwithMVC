 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Model;

namespace WebApplication8.EmployeeData
{
    public class MockEmployeeData : iEmployeeData
    {
        private List<TimeTracking> employees = new List<TimeTracking>() {
            new TimeTracking()
            {
                ID = Guid.NewGuid(),
                employeeName = "Charlie",
                clockInTime = DateTime.Today,
                clockOutTime = DateTime.Now,
                isActive = true
            },
            new TimeTracking()
            {
                ID = Guid.NewGuid(),
                employeeName = "Cindy",
                clockInTime = DateTime.Today,
                clockOutTime = DateTime.Now,
                isActive = false
            }

        };
        public TimeTracking AddTimeEmployee(TimeTracking timeemployee)
        {
            timeemployee.ID = Guid.NewGuid();
            employees.Add(timeemployee);
            return timeemployee;
        }

        public void DeleteTimeEmployee(TimeTracking timeemployee)
        {
            employees.Remove(timeemployee);
        }

        public TimeTracking EditTimeEmployee(TimeTracking timeemployee)
        {
            var existingEmployee = getEmployee(timeemployee.ID);
            existingEmployee.employeeName = timeemployee.employeeName;
            existingEmployee.isActive = timeemployee.isActive;
            return existingEmployee;
        }

        public List<TimeTracking> getAllEmployee()
        {
            return employees;
        }

        public TimeTracking getEmployee(Guid ID)
        {
            return employees.SingleOrDefault(x => x.ID == ID);
        }
        public List<TimeTracking> searchName(string employeeName)
        {
            return employees;
        }
    }
}
