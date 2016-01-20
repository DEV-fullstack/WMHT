using BanDiDau.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
namespace BanDiDau.Controllers
{
    public class HomeController : Controller
    {
        #region ------Default action--------
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contasct()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
        
        #region--------Home/Flights--------
        /// <summary>
        /// Flights
        /// </summary>
        /// <returns></returns>
        public ActionResult Flight()
        {
            return View();
        }

        public ActionResult Flight_Payment()
        {
            return View();
        }
        public ActionResult Flight_Ppayment_Registered_Card()
        {
            return View();
        }
        public ActionResult Flight_Payment_Unregistered()
        {
            return View();
        }

        public ActionResult Flight_Search()
        {
            return View();
        }
        public ActionResult Flight_Search_Results()
        {
            return View();
        }
        #endregion
        
    }

}