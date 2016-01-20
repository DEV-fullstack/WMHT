using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanDiDau.Models
{
    public class Hotel_Result_Info
    {
        public string name{get; set;}
        public string cityCode { get; set; }
        public string address{get; set;}
        public string phone{ get; set;}
        public string fax { get; set; }
        public string description { get; set; }
        public string hotelFacilities { get; set; }
        public string roomFacilities { get; set; }
        public float price{get; set;}
        public float rate { get; set; }
        public string location { get; set; }
        public string currency { get; set; }
        public int reviewCount { get; set; }
        public string category { get; set; }
        public string cxDeadline { get; set; }
        public string urlImageRate { get; set; }
        public string falicity { get; set; }
        public string hotelSearchCode{get; set;}
        public List<string> pictureDescription = new List<string>();
    }
}
