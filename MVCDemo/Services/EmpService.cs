using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
using MVCDemo.DataAccess;

namespace MVCDemo.Services
{
    public class EmpService
    {
        EmpDAL empDAL = new EmpDAL();

        public List<Employee> GetEmployees(Employee emp)
        {
            return empDAL.GetEmployees(emp);
        }

        public Employee GetEmployee(int id)
        {
            return empDAL.GetEmployee(id);
        }

        public bool AddNewEmployee(Employee emp)
        {
            EmpDAL dal = new EmpDAL();

            bool isSuccess = false;

            try
            {
                dal.AddNewEmpployee(emp);
                isSuccess = true;
            }
            catch (Exception)
            {
                throw;
            }

            return isSuccess;
        }

        public bool EditEmployee(Employee employee)
        {
            EmpDAL dal = new EmpDAL();
            bool isSuccess = false;

            try
            {
                dal.ModifyEmployee(employee);
                isSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }

            return isSuccess;
        }

        public bool RemoveEmployee(int id)
        {
            EmpDAL dal = new EmpDAL();
            bool isSuccess = false;

            try
            {
                dal.RemoveEmployee(id);
                isSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }

            return isSuccess;
        }

    }
}