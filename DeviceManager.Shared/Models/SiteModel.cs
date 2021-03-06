using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Shared.Models
{
    public class SiteModel
    {
        public int SITE_ID { get; set; }
        public string NAME { get; set; }
        public string DSCR { get; set; }
        public DateTime LAST_UPDATED { get; set; }
        public double LONGITUDE { get; set; }
        public double LATITUDE { get; set; }
    }
}
