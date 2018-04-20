using DateRangeWebApi.Service.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DateRangeWebApi.ConsoleClient.WebClient
{
    public class HttpClient
    {
        public void GetAll()
        {
            HttpWebRequest httpRequest =
                (HttpWebRequest)WebRequest
                .Create("http://localhost:62679/api/daterange/getall");

            string strResponse = string.Empty;
            using (WebResponse httpResponse = httpRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(httpResponse.GetResponseStream()))
                {
                    strResponse = rd.ReadToEnd();
                }
            }
            var servicedata = JsonConvert.DeserializeObject<IEnumerable<DateRangeDto>>(strResponse);
            foreach (var item in servicedata)
            {
                Console.WriteLine($"{item.DateStart.ToShortDateString()} - {item.DateEnd.ToShortDateString()}");
            }
        }

        public void GetIntersected(DateTime dateStart, DateTime dateEnd)
        {
            DateRangeDto dto = new DateRangeDto
            {
                DateStart = dateStart,
                DateEnd = dateEnd
            };
            if (dto.DateStart < dto.DateEnd)
            {
                // Send the request
                HttpWebRequest httpRequest =
                (HttpWebRequest)WebRequest
                    .Create($"http://localhost:62679/api/daterange/getintersected");
                httpRequest.Method = "POST";
                var data = JsonConvert
                    .SerializeObject(dto);
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                httpRequest.ContentType = "application/json";
                httpRequest.ContentLength = byteArray.Length;
                Stream dataStream = httpRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                // Get the response  
                WebResponse response = httpRequest.GetResponse();
                Console.WriteLine($"Status code: {((HttpWebResponse)response).StatusDescription}");
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                var servicedata = JsonConvert.DeserializeObject<IEnumerable<DateRangeDto>>(responseFromServer);
                foreach (var item in servicedata)
                {
                    Console.WriteLine($"{item.DateStart.ToShortDateString()} - {item.DateEnd.ToShortDateString()}");
                }
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }

        public void Create(DateTime dateStart, DateTime dateEnd)
        {
            DateRangeDto dto = new DateRangeDto
            {
                DateStart = dateStart,
                DateEnd = dateEnd
            };
            if (dto.DateStart < dto.DateEnd)
            {
                // Create the request
                HttpWebRequest httpRequest =
                    (HttpWebRequest)WebRequest
                    .Create($"http://localhost:62679/api/daterange/create");
                httpRequest.Method = "POST";
                var data = JsonConvert
                    .SerializeObject(dto);
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                httpRequest.ContentType = "application/json";
                httpRequest.ContentLength = byteArray.Length;
                Stream dataStream = httpRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                // Get the response
                WebResponse response = httpRequest.GetResponse();
                Console.WriteLine($"Status code: {((HttpWebResponse)response).StatusDescription}");
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                var servicedata = JsonConvert.DeserializeObject<DateRangeDto>(responseFromServer);
                Console.WriteLine($"Location {((HttpWebResponse)response).Headers["Location"].ToString()}");
                Console.WriteLine($"Created object: {servicedata.DateStart} - {servicedata.DateEnd}");
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
    }
}
