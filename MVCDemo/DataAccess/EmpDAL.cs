using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.DataAccess
{
    public class EmpDAL
    {
        readonly MVCDemoEntities entities = new MVCDemoEntities();

        public List<Employee> GetEmployees(Employee emp)
        {
            var result = new List<Employee>();

            using (entities)
            {
                result = entities.Employee.Where(x => x.EmpId == emp.EmpId || x.EmpName.Contains(emp.EmpName)).ToList();
            }

            return result;
        }

        public Employee GetEmployee(int id)
        {
            var result = new Employee();

            using (entities)
            {
                result = entities.Employee.Where(x => x.ID == id).FirstOrDefault();
            }

            return result;
        }

        public void AddNewEmpployee(Employee employee)
        {
            try
            {
                using (entities)
                {
                    entities.Employee.Add(employee);
                    entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void ModifyEmployee(Employee employee)
        {
            try
            {
                Employee originEmp = new Employee();
                using (entities)
                {
                    originEmp = entities.Employee.Where(x => x.ID == employee.ID).ToList().FirstOrDefault();

                    entities.Entry(originEmp).CurrentValues.SetValues(employee);
                    entities.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveEmployee(int ID)
        {
            try
            {
                Employee originEmp = new Employee();
                using (entities)
                {
                    originEmp = entities.Employee.Where(x => x.ID == ID).ToList().FirstOrDefault();
                    entities.Entry(originEmp).State = System.Data.Entity.EntityState.Deleted;
                    entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}