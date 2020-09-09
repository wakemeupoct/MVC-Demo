using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
namespace MVCDemo.ViewModels
{
    public class vmEmployee
    {
        public Employee employee { get; set; }
        public List<SelectListItem> depSelectLists { get; set; }
        public SelectListItem SelectListItem { get; set; }
    }
}