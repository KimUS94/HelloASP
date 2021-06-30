using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace HelloWorld.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "This is my default action...";
        }

        public string Welcome()
        {
            return "This is the Welcome action method..";
        }

        
        public string Nodes()
        {
            try

            {
                //string targetUTL = "https://192.168.0.58:5000/nodes/index.do";
                //System.Net.HttpWebRequest gomRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(targetUTL);

                //HttpWebResponse ckResponse = (HttpWebResponse)gomRequest.GetResponse();

                WebRequest request = WebRequest.Create("http://192.168.0.58:5000/nodes"); // 호출할 url
                request.Method = "GET";

                string responseFromServer;


                using (WebResponse response = request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);

                    responseFromServer = reader.ReadToEnd();

                    Console.WriteLine(responseFromServer); // response 출력

                    reader.Close();
                    dataStream.Close();                 
                }

                return responseFromServer;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            #region http://www.dreamy.pe.kr/zbxe/CodeClip/164854
            //HttpWebRequest wReq;
            //HttpWebResponse wRes;
            //Uri uri;

            //string resResult;

            //try
            //{
            //    uri = new Uri("https://192.168.0.58:5000/nodes/index.do"); // string 을 Uri 로 형변환
            //    wReq = (HttpWebRequest)WebRequest.Create(uri); // WebRequest 객체 형성 및 HttpWebRequest 로 형변환
            //    wReq.Method = "GET"; // 전송 방법 "GET" or "POST"
            //    wReq.ServicePoint.Expect100Continue = false;
            //    wReq.CookieContainer = new CookieContainer();
            //    //wReq.CookieContainer.SetCookies(uri, cookie); // 넘겨줄 쿠키가 있을때 CookiContainer 에 저장

            //    /* POST 전송일 경우
            //    byte[] byteArray = Encoding.UTF8.GetBytes(data);

            //    Stream dataStream = wReq.GetRequestStream();
            //    dataStream.Write(byteArray, 0, byteArray.Length);
            //    dataStream.Close();
            //    */

            //    using (wRes = (HttpWebResponse)wReq.GetResponse())
            //    {
            //        Stream respPostStream = wRes.GetResponseStream();
            //        StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("EUC-KR"), true);

            //        resResult = readerPost.ReadToEnd();
            //    }

            //    //return true;
            //}
            //catch (WebException ex)
            //{
            //    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
            //    {
            //        var resp = (HttpWebResponse)ex.Response;
            //        if (resp.StatusCode == HttpStatusCode.NotFound)
            //        {
            //            // 예외 처리
            //        }
            //        else
            //        {
            //            // 예외 처리
            //        }
            //    }
            //    else
            //    {
            //        // 예외 처리
            //    }

            //    //return false;
            //}
            #endregion
        }
    }
}
