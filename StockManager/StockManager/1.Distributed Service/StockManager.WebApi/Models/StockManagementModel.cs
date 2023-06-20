using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManager.WebApi.Models
{
    public class StockManagementModel
    {
        public string StockId { get; set; }

        public string StockName { get; set; }

        public string StockDescription { get; set; }
    }
}