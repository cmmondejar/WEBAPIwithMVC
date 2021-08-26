using System;
using System.Collections.Generic;
using WebApplication8.Model;

namespace WebApplication8.EmployeeData
{
    public interface iEmployeeData
    {
        List<TimeTracking> getAllEmployee();
        List<TimeTracking> searchName(string employeeName);

        TimeTracking getEmployee(Guid id);

        TimeTracking AddTimeEmployee(TimeTracking timeemployee);

        void DeleteTimeEmployee(TimeTracking timeemployee);
        TimeTracking EditTimeEmployee(TimeTracking timeemployee);
    }
}
