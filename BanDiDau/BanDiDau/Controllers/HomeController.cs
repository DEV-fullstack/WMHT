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
        private int hotelCodeTemp; //field  hotel id 
        private List<Hotel_Result_Geo> listHotel_Result_GeoTemp;
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
        #region--------Home/Hotel----------
        #region -------------Action--------
        public ActionResult Hotel()
        {
            return View();
        }
        /// <summary>
        /// Hotel_Details
        /// </summary>
        /// <param name="searchHotelCode">searchHotelCode(Ma cua khach san)</param>
        /// <returns></returns>
        [OutputCache(Duration =600,VaryByParam ="price")]
        public ActionResult Hotel_Details(string id, float? price, int? iHotelCode, DateTime? start, DateTime? end, int? sumAdult, int? sumChild, int? sumRoom, int? ageChild1, int? ageChild2)
        {
            try
            {
                XmlDocument soapEnvelopeXml = CreateSoapEnvelopeSearchHotelInfo(id);
                soapEnvelopeXml = Request_Response(soapEnvelopeXml);
                //get CDATA from strResponse
                #region Get CDATA from strResponse-Method2
                //XDocument cpo = XDocument.Load(Server.MapPath(@"kien.xml"));// load by path
                XElement xelement = XElement.Parse(soapEnvelopeXml.InnerText);
                List<Hotel_Result_Info> hotel_Result = new List<Hotel_Result_Info>();
                IEnumerable<XElement> hotelInfos = xelement.Elements("Main");
                //get Pictures tag
                IEnumerable<XElement> hotelPictures = xelement.Elements("Main").Elements("Pictures");
                //get all tag child(<Picture>) of tag Pictures
                IEnumerable<XElement> childHotelPictures = hotelPictures.Elements();
                List<string> tempPictureDescription = new List<string>();
                foreach (var picture in childHotelPictures)
                {
                    tempPictureDescription.Add(picture.Value);
                }
                foreach (var hotel in hotelInfos)
                {
                    hotel_Result.Add(new Hotel_Result_Info
                    {
                        name = hotel.Element("HotelName").Value,
                        address = hotel.Element("Address").Value,
                        fax = hotel.Element("Fax").Value,
                        phone = hotel.Element("Phone").Value,
                        category = (hotel.Element("Category").Value),
                        description = hotel.Element("Description").Value,
                        price = (price ?? 0),
                        pictureDescription = tempPictureDescription
                        //location = hotel.Element("Location").Value,
                        //currency = hotel.Element("Currency").Value,
                        //cxDeadline = hotel.Element("CxlDeadline").Value != "" ? hotel.Element("CxlDeadline").Value : "",
                        //reviewCount = hotel.Element("TripAdvisor").Element("ReviewCount").Value != "" ? int.Parse(hotel.Element("TripAdvisor").Element("ReviewCount").Value) : 0,
                        //urlImageRate = hotel.Element("TripAdvisor").Element("RatingImage").Value != "" ? (hotel.Element("TripAdvisor").Element("RatingImage").Value) : "",
                        //rate = hotel.Element("TripAdvisor").Element("Rating").Value != "" ? float.Parse(hotel.Element("TripAdvisor").Element("Rating").Value) : 0,

                    });

                }
                #endregion
                ViewBag.hotel_Info_Result = hotel_Result;
                //method get all room of hotel
                XmlDocument soapEnvelopeXml2 = CreateSoapEnvelopeHotelSearchGeo_Id(0,iHotelCode, start, end, sumAdult, sumChild, sumRoom, ageChild1, ageChild2);
                List<Hotel_Result_Geo> hotel_Result_Geo = hotelGeo(soapEnvelopeXml2);
                ViewBag.hotel_listRoom_Result = hotel_Result_Geo;
                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }


        }
        public ActionResult Hotel_Payment()
        {
            return View();
        }
        public ActionResult Hotel_Ppayment_Registered_Card()
        {
            return View();
        }
        public ActionResult Hotel_Payment_Unregistered()
        {
            return View();
        }
        public ActionResult Hotel_Search()
        {
            return View();
        }
        /// <summary>
        /// RequestXML-Hotels_Search_Results
        /// </summary>
        /// <param name="iCityCode">CityCode(Ma thanh pho)</param>
        /// <param name="iHotelCode">HotelCode(Ma khach san- lay danh sach phong neu can)</param>
        /// <param name="starts">Check in(ngay nhan phong)</param>
        /// <param name="ends">check out(ngay tra phong)</param>
        /// <param name="sumAdult">Sum Adult(Tong so nguoi lon)</param>
        /// <param name="sumChild">Sum Child(Tong so tre em)</param>
        /// <param name="sumRoom"> Sum Room(Tong so phong)</param>
        /// <param name="ageChild1"> Age-Child1(So tuoi tre thu nhat)</param>
        /// <param name="ageChild2"> Age-Child2(So tuoi tre thu hai)</param>
        /// <returns></returns>
       // [OutputCache(Duration = 600, VaryByParam = "iCityCode;starts;ends;sumAdult;sumChild;sumRoom;ageChild1;ageChild2")]
        public ActionResult Hotels_Search_Results(int? iCityCode,int? iHotelCode, DateTime? start, DateTime? end, int? sumAdult, int? sumChild, int? sumRoom, int? ageChild1, int? ageChild2)
        {
            string exs;
            try
            {
                XmlDocument soapEnvelopeXml = CreateSoapEnvelopeHotelSearchGeo_Id(iCityCode, iHotelCode, start, end, sumAdult, sumChild, sumRoom, ageChild1, ageChild2);
                List<Hotel_Result_Geo> hotel_Result_Geo = hotelGeo(soapEnvelopeXml);
                ViewBag.hotel_Result = hotel_Result_Geo.DistinctBy(a => a.hotelCode);
                ViewBag.start = start;
                ViewBag.end = end;
                ViewBag.sumAdult = sumAdult;
                ViewBag.sumChild = sumChild;
                ViewBag.sumRoom = sumRoom;
                ViewBag.ageChild1 = ageChild1;
                ViewBag.ageChild2 = ageChild2;
                return View();
            }
            catch (Exception ex)
            {
                exs = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
        #region -----------Medthods--------
        private static string Header_Request(bool hotelInfo)
        {
            string strOperation = "";
            string strRequestType = "";
            if (hotelInfo == true)
            {
                strOperation = "<Operation>HOTEL_INFO_REQUEST</Operation>";
                strRequestType = " <requestType>61</requestType>";
            }
            else
            {
                strOperation = "<Operation>HOTEL_SEARCH_REQUEST</Operation>";
                strRequestType = " <requestType>11</requestType>";
            }
            string xml = @"<?xml version='1.0' encoding='utf-8'?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
            <soap:Body>
            <MakeRequest xmlns=""http://www.goglobal.travel/"">" +
            strRequestType + @"
            <xmlRequest>
            <![CDATA[<Root>
	        <Header>
		        <Agency>1521345</Agency>
		        <User>TRIPGLOBALXML</User>
		        <Password>XMLTRIPGLOBAL</Password>" +
                strOperation + @"
		        <OperationType>Request</OperationType>
                <SearchGuid return='true'></SearchGuid>
	        </Header>";
            return xml;
        }
        private static XmlDocument CreateSoapEnvelopeSearchHotelInfo(string searchHotelCode)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string xmlHeader = Header_Request(true);
            string xml = xmlHeader + @"
	       <Main>
		        <HotelSearchCode>" + searchHotelCode + @"</HotelSearchCode>
	       </Main>
   </Root>]]>
           </xmlRequest>
            </MakeRequest>
           </soap:Body>
           </soap:Envelope>";
            soapEnvelop.LoadXml(xml);
            return soapEnvelop;
        }
        /// <summary>
        /// search all roomo of Hotel by ID
        /// </summary>
        /// <param name="hotelCode">hotelCode(ma cua hotel)</param>
        /// <returns></returns>
        private static XmlDocument CreateSoapEnvelopeSearchHotelId(string hotelCode)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string xmlHeader = Header_Request(true);
            string xml = xmlHeader + @"
	       Main>
		<SortOrder>0</SortOrder>
		<FilterPriceMin>0</FilterPriceMin>
		<FilterPriceMax>10000</FilterPriceMax>
		<MaximumWaitTime>30</MaximumWaitTime>
		<MaxResponses>1000</MaxResponses>
		<FilterRoomBasises>
			<FilterRoomBasis></FilterRoomBasis>
		</FilterRoomBasises>
		<HotelName></HotelName>
		<Apartments>false</Apartments>
		<Hotels>
			<HotelId>" + hotelCode + @"</HotelId>
		</Hotels>
		<ArrivalDate>2016-03-06</ArrivalDate>
		<Nights>3</Nights>
		<Rooms>
			<Room Adults='2' RoomCount='1'></Room>
        </Rooms>
    </Main >
   </Root>]]>
           </xmlRequest>
            </MakeRequest>
           </soap:Body>
           </soap:Envelope>";
            soapEnvelop.LoadXml(xml);
            return soapEnvelop;
        }
        private static XmlDocument CreateSoapEnvelopeHotelSearchGeo_Id(int? iCityCode, int? iHotelCode, DateTime? starts, DateTime? ends, int? sumAdult, int? sumChild, int? sumRoom, int? ageChild1, int? ageChild2)
        {
            string strDayStart = (starts != null ? starts.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"));
            string strDayEnd = (ends != null ? ends.Value.ToString("yyyy-MM-dd") : DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            int iNights = ends.Value.Day - starts.Value.Day;
            XmlDocument soapEnvelop = new XmlDocument();
            string xmlHeader = Header_Request(false);
            iCityCode = (iCityCode??0);
            iHotelCode = (iHotelCode ?? 0);
            string strHotelCode = "";
            string strCityCode = "";
            if (iHotelCode !=0 )
            {
                strHotelCode =
                   @"<Hotels >
                         <HotelId > " + iHotelCode + @" </HotelId >
                      </Hotels >";
            }
            if (iCityCode != 0)
            {
                strCityCode =
                   @" <CityCode>" + iCityCode + @"</CityCode>";
            }
            string xml = xmlHeader + @"
	        <Main>
		        <SortOrder>1</SortOrder>
		        <FilterPriceMin>0</FilterPriceMin>
		        <FilterPriceMax>10000</FilterPriceMax>
		        <MaximumWaitTime>30</MaximumWaitTime>
		        <MaxResponses>10</MaxResponses>
		        <FilterRoomBasises>
			    <FilterRoomBasis></FilterRoomBasis>
		        </FilterRoomBasises>
                <Apartments>false</Apartments>" +
                strHotelCode +
                strCityCode+@"
		        <ArrivalDate>" + strDayStart + @"</ArrivalDate>
		        <Nights>" + iNights + @"</Nights>
		        <Rooms>
			        <Room Adults='" + sumAdult + @"' RoomCount='" + sumRoom + @"'></Room>";
            string xmlEnd = @"
                </Rooms>
           </Main >
            </Root>]]>
           </xmlRequest>
            </MakeRequest>
           </soap:Body>
           </soap:Envelope>";
            if (ageChild1 > 2 || ageChild2 > 2)
            {
                if (ageChild2 < 2)
                {
                    xml += "<ChildAge > " + ageChild1 + @" </ChildAge >" + xmlEnd;
                }
                else
                {
                    xml = xml + @"<ChildAge >" + ageChild1 + @"</ChildAge ><ChildAge >" + ageChild2 + @" </ChildAge >" + xmlEnd;
                }
            }
            else
            {
                xml += xmlEnd;
            }

            soapEnvelop.LoadXml(xml);
            return soapEnvelop;
        }
        private List<Hotel_Result_Geo> hotelGeo(XmlDocument soapEnvelopeXml)
        {

            soapEnvelopeXml = Request_Response(soapEnvelopeXml);
            //get CDATA from strResponse
            #region Get CDATA from strResponse-Method1
            //XElement root = XElement.Parse(strResponse);
            //string str1 =
            //root.Descendants("HotelName")
            //    .Select(s => s.Value)
            //    .Aggregate(
            //    new StringBuilder(),
            //    (s, i) => s.Append(i),
            //    s => s.ToString()
            //    );
            #endregion
            #region Get CDATA from strResponse-Method2
            //XDocument cpo = XDocument.Load(Server.MapPath(@"kien.xml"));// load by path
            XElement xelement = XElement.Parse(soapEnvelopeXml.InnerText);
            XElement po = xelement.Element("Main");
            List<Hotel_Result_Geo> hotel_Result = new List<Hotel_Result_Geo>();
            IEnumerable<XElement> hotels = po.Elements();
            foreach (var hotel in hotels)
            {
                hotel_Result.Add(new Hotel_Result_Geo
                {
                    name = hotel.Element("HotelName").Value,
                    hotelSearchCode = hotel.Element("HotelSearchCode").Value,
                   // cityCode= int.Parse(hotel.Element("CityCode").Value),
                    hotelCode = int.Parse(hotel.Element("HotelCode").Value),
                    thumbnail = hotel.Element("Thumbnail").Value,
                    price = float.Parse(hotel.Element("TotalPrice").Value),
                    category = (hotel.Element("Category").Value),
                    location = hotel.Element("Location").Value,
                    currency = hotel.Element("Currency").Value,
                    cxDeadline = hotel.Element("CxlDeadline").Value != "" ? hotel.Element("CxlDeadline").Value : "",
                    reviewCount = hotel.Element("TripAdvisor").Element("ReviewCount").Value != "" ? int.Parse(hotel.Element("TripAdvisor").Element("ReviewCount").Value) : 0,
                    urlImageRate = hotel.Element("TripAdvisor").Element("RatingImage").Value != "" ? (hotel.Element("TripAdvisor").Element("RatingImage").Value) : "",
                    rate = hotel.Element("TripAdvisor").Element("Rating").Value != "" ? float.Parse(hotel.Element("TripAdvisor").Element("Rating").Value) : 0,

                });

            }
            return hotel_Result;
        }
        #endregion
        #endregion
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
        #region -----Autocomplete search Country----
        /// <summary>
        /// Autocomplete search Country
        /// </summary>
        /// <param name="textValue">CountryCode(Ma than pho)</param>
        /// <returns></returns>
        public ActionResult CountryLookup(string textValue)
        {

            string text = textValue.ToUpper().Replace(" ", "");
            var line = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/" + "destinations.csv")).Select(a => a.Replace(" ", "")).Where(a => a.Contains(text));
            //var model = new List<Hotel_Destionations>();
            var line2 = line.SelectMany(a => a.Replace("\"", "").Split('\"', '|')).ToList();
            var model = new List<Hotel_DestionationsRecoder>();
            for (int i = 0; i < line2.Count(); i += 5)
            {
                model.Add(new Hotel_DestionationsRecoder
                {
                    cityID = line2[i],
                    city = line2[i + 1],
                    countryID = line2[i + 2],
                    country = line2[i + 3],
                    isoCode = line2[i + 4]
                });
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region ---------Basic methods create request and respponse XML -------------
        /// <summary>
        /// HttpWebRequest-CreateWebRequest(gui request toi link webservices)
        /// </summary>
        /// <returns></returns>
        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            // webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Method = "POST";
            return webRequest;
        }
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        /// <summary>
        /// Request-Response by url& action
        /// </summary>
        /// <param name="soapEnvelopeXml"> method contains ipnut request(phuong thuc chua input request)</param>
        /// <returns></returns>
        private static XmlDocument Request_Response(XmlDocument soapEnvelopeXml)
        {
            var _url = "http://xml.qa.goglobal.travel/XMLWebService.asmx";
            var _action = "http://www.goglobal.travel/MakeRequest";
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(r => autoResetEvent.Set(), null);
            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            autoResetEvent.WaitOne();
            // get the response from the completed web request.
            XmlDocument doc = new XmlDocument();
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    doc.InnerXml = rd.ReadToEnd();
                }
            }
            return doc;
        }

        #endregion
    }

}