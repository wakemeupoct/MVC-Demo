using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;

namespace MVCDemo.DataAccess
{
    public class DeptDAL
    {
        readonly MVCDemoEntities entities = new MVCDemoEntities();

        public List<Depart> GetDepartList()
        {
            var result = new List<Depart>();

            using (entities)
            {
                result = entities.Depart.ToList();
            }

            return result;
        }

    }
}