using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
using MVCDemo.DataAccess;

namespace MVCDemo.Services
{
    public class DeptService
    {
        DeptDAL deptDAL = new DeptDAL();

        public List<Depart> GetDeparts()
        {
            return deptDAL.GetDepartList();
        }
    }
}