using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThirdPartyProvider.Controllers
{    
    [RoutePrefix("consumer")]
    public class ThirdPartyController : ApiController
    {
        static int count = 0;

        // GET: consumer/ping
        [Route("ping")]
        public IEnumerable<string> Get()
        {
            //String line;

            ////Pass the file path and file name to the StreamReader constructor
            //StreamReader sr = new StreamReader("C:\\demo\\demo.txt");

            ////Read the first line of text
            //line = sr.ReadLine();

            ////close the file
            //sr.Close();

            //int countFromFile = Convert.ToInt32(line);

            //TextWriter txt = new StreamWriter("C:\\demo\\demo.txt");
            //txt.Write(++countFromFile);
            //txt.Close();

            //if (countFromFile - 1 > 20)
            //{
            //    return new string[] { "Value from text file", countFromFile.ToString() };
            //}
            //else
            //{
            //    throw new TimeoutException();
            //}     

            return new string[] { "Consumer hit successfully1" };
        }

        // POST: consumer/getValue
        [Route("getValue")]
        public HttpResponseMessage Post([FromBody]string value)
        {
            String line;            

            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("C:\\demo\\demotdp.txt");

            //Read the first line of text
            line = sr.ReadLine();

            //close the file
            sr.Close();

            int countFromFile = Convert.ToInt32(line);
            int countToInsert = countFromFile + 1;

            TextWriter txt = new StreamWriter("C:\\demo\\demotdp.txt");
            txt.WriteLine(countToInsert.ToString());
            txt.Close();

            if(countFromFile - 1 > 50)
            {
                //return "Circuit breaker closed successfully";   
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Circuit breaker closed successfully");
            }
            else
            {
                return Request.CreateResponse<string>(HttpStatusCode.RequestTimeout, "RequestTimeout");
            }
        }
    }
}
