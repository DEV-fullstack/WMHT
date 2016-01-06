
using System.IO;
using System.Net;

namespace BanDiDau.Models
{
    class WebServicesTest
    {


        public void Respone()
        {
            HttpWebRequest request = CreateWebRequest();
            System.Xml.XmlDocument soapEnvelopeXml = new System.Xml.XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version='1.0' encoding='utf-8'?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
            <soap:Body>
            <MakeRequest xmlns=""http://www.goglobal.travel/"">
            <requestType>11</requestType>
            <xmlRequest>
            <![CDATA[<Root>
	<Header>
		<Agency>1521345</Agency>
		<User>TRIPGLOBALXML</User>
		<Password>XMLTRIPGLOBAL</Password>
		<Operation>HOTEL_SEARCH_REQUEST</Operation>
		<OperationType>Request</OperationType>
	</Header>
	<Main>
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
		<CityCode>75</CityCode>
		<ArrivalDate>2016-02-28</ArrivalDate>
		<Nights>3</Nights>
		<Rooms>
			<Room Adults='2' RoomCount='2'></Room>
        </Rooms>
    </Main>
</Root>]]>
           </xmlRequest>
            </MakeRequest>
           </soap:Body>
           </soap:Envelope>");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    //doc.InnerXml = rd.ReadToEnd();
                    //,,,,,,,= doc.InnerText;
                }
            }
        }
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://xml.qa.goglobal.travel/XMLWebService.asmx");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}