﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.SimTaxi.Web.Models.Drivers
{
    public class DriverPageViewModel
    {
        public List<DriverListViewModel> Drivers { get; set; }
        public MultiSelectList CarSelectList { get; set; }
    }
}
