using System;
using System.Collections.Generic;
using System.Text;

namespace TechODayApp.Models
{
    public class DriveRequest
    {
        public Driver SelectedDriver { get; set; }

        public static string Location { get; set; }
        public static string Direction { get; set; }
    }
}
