using assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace assignment2.View_Models
{
    public class DishesIndexViewModel
    {
        public IPagedList<local_dishes> Local_dishes { get; set; }
        public string Search { get; set; }
        public IEnumerable<CuisinesWithCount> CuisWithCount { get; set; }
        public string Cuisine{ get; set; }
        public IEnumerable<SelectListItem> CuiFilterItems
        {
            get
            {
                var allCuis = CuisWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CuisinesName,
                    Text = cc.CuiNameWithCount
                });
                return allCuis;
            }
        }
        public class CuisinesWithCount
        {
            public int DishesCount { get; set; }
            public string CuisinesName { get; set; }
            public string CuiNameWithCount
            {
                get
                {
                    return CuisinesName + " (" +
                    DishesCount.ToString() + ")";
                }
            }
        }
    }
}