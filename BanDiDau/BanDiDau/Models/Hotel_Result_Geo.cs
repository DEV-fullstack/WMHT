using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDiDau.Models
{
    public class Hotel_Result_Geo
    {
        public string name{get; set;}
        public float price { get; set; }
        public float rate { get; set; }
        public string location { get; set; }
        public string currency { get; set; }
        public int reviewCount { get; set; }
        public string category { get; set; }
        public string cxDeadline { get; set; }
        public string urlImageRate { get; set; }
        public string hotelSearchCode{get; set;}
        public string description { get; set; }
        public int hotelCode { get; set; }
        public int cityCode { get; set; }
        public string thumbnail { get; set; }
        public string roomType { get; set; }
        
    }
}
