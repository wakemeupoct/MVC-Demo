using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using MVCDemo.Services;
using MVCDemo.ViewModels;

namespace MVCDemo.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        /// <summary>
        /// 員工清單頁，目前預設資料全拿
        /// </summary>
        /// <returns></returns>
        public ActionResult Inquiry()
        {
            return View(GetDepEmp());
        }

        /// <summary>
        /// 回傳員工編輯頁所需model
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            EmpService service = new EmpService();
            List<Depart> deps = GetDeparts();
            List<SelectListItem> depSelects = new List<SelectListItem>();
            Employee emp = new Employee();

            if (deps != null && deps.Count > 0)
            {

                depSelects.Add(new SelectListItem
                {
                    Text = "請選擇",
                    Value = "",
                    Selected = true,
                });
                foreach (var item in deps)
                {
                    depSelects.Add(new SelectListItem
                    {
                        Text = item.DepName,
                        Value = item.DepId,
                    });
                }
            }

            if (id != null)
            {
                emp = service.GetEmployee(id.Value);
            }

            vmEmployee vm = new vmEmployee()
            {
                depSelectLists = depSelects,
                employee = emp,
            };

            return View(vm);
        }

        /// <summary>
        /// 新增/編輯員工資料
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            EmpService service = new EmpService();
            Employee emp = new Employee();
            var result = false;
            emp.EmpId = form["EmpId"];
            emp.EmpName = form["EmpName"];
            emp.Ext = form["Ext"];
            emp.DepId = form["DepId"];
            emp.Birthday = Convert.ToDateTime(form["Birthday"]);
            emp.ID = string.IsNullOrEmpty(form["ID"]) ? 0 : Convert.ToInt64(form["ID"]);
            try
            {
                if (emp.ID > 0)
                {
                    result = service.EditEmployee(emp);
                }
                else
                {
                    result = service.AddNewEmployee(emp);
                }

            }
            catch (Exception ex)
            {
                //可以處理要給前端的錯誤訊息/紀錄錯誤log
                throw ex;
            }

            return RedirectToAction("Inquiry", "Emp");
            //return View();
        }

        /// <summary>
        /// 刪除員工資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            EmpService service = new EmpService();
            var result = false;
            try
            {
                if (id > 0)
                {
                    result = service.RemoveEmployee(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Inquiry", "Emp");
        }

        private List<vDeptEmp> GetDepEmp()
        {
            List<vDeptEmp> deptEmps = new List<vDeptEmp>();

            using (MVCDemoEntities db = new MVCDemoEntities())
            {
                deptEmps = db.vDeptEmp.ToList();
            }

            return deptEmps;
        }

        private List<Depart> GetDeparts()
        {
            DeptService deptService = new DeptService();

            return deptService.GetDeparts();
        }
    }
}