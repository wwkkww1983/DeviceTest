using Common.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Common.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpMethod : IHttpMethod
    {
        public string APIUrl
        {
            get;
            set;
        }

        public SortedDictionary<string, string> GetRequestParam(string qrcode)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("content", qrcode);
            sParaTemp.Add("guard", AlipayConfig.TermID);
            sParaTemp.Add("app", AlipayConfig.App);
            return sParaTemp;
        }

        private string GetSign(string qrcode)
        {
            var inputPara = GetRequestParam(qrcode);

            Dictionary<string, string> sPara = new Dictionary<string, string>();
            //过滤空值、sign与sign_type参数
            sPara = Core.FilterPara(inputPara);
            //获取待签名字符串
            string preSignStr = Core.CreateLinkString(sPara);

            var mysign = AlipayMD5.Sign(preSignStr, AlipayConfig.Key, AlipayConfig.Input_charset);

            return mysign;
        }

        public T HttpGet<T>(string qrcode, out string requesterror) where T : class, new()
        {
            var mysign = GetSign(qrcode);

            //真正的url
            var inputPara = GetRequestParam(qrcode);
            inputPara.Add("sign", mysign);
            inputPara.Add("sign_type", AlipayConfig.Sign_type);

            var urlcode = Encoding.GetEncoding(AlipayConfig.Input_charset);
            var preSignStr = Core.CreateLinkStringUrlencode(inputPara, urlcode);

            try
            {
                var httpGetUrl = string.Concat(APIUrl, "?" + preSignStr);
                LogHelper.Info(httpGetUrl);
                var request = (HttpWebRequest)WebRequest.Create(httpGetUrl);
                request.Method = "Get";
                request.ContentType = "application/x-www-form-urlencoded";

                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var jsonStr = "";
                using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    jsonStr = streamReader.ReadToEnd();
                }
                if (string.IsNullOrEmpty(jsonStr))
                {
                    requesterror = "返回数据为空";
                    return new T();
                }

                var jsonObject = Deserialize<T>(jsonStr);
                requesterror = string.Empty;
                return jsonObject;
            }
            catch (Exception ex)
            {
                requesterror = ex.Message;
                return new T();
            }
        }

        public void Dispose()
        {
        }

        private T Deserialize<T>(string input)
        {
            JavaScriptSerializer serial = new JavaScriptSerializer();
            return serial.Deserialize<T>(input);
        }

        public static HttpWebRequest PostImage(string url, string boundary)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wr.Timeout = 150000;
            wr.KeepAlive = false;
            return wr;
        }

        public string Post(string url, byte[] data, Dictionary<string, string> param)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)PostImage(url, boundary);
            WebResponse response = null;

            StringBuilder sb = new StringBuilder();
            try
            {
                var rs = request.GetRequestStream();
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (string key in param.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, param[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }

                //文件开始
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                //图片
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "image", "image.jpg", "text/plain");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);
                rs.Write(data, 0, data.Length);
                //文件结束
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    var responseStream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(responseStream);
                    var content = sr.ReadToEnd();
                    sr.Close();
                    return content;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }


        public string Post(string url, byte[] data, string cookie, Dictionary<string, string> param)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)PostImage(url, boundary);
            if (!cookie.IsEmpty())
                request.Headers["cookie"] = cookie;

            WebResponse response = null;

            StringBuilder sb = new StringBuilder();
            try
            {
                var rs = request.GetRequestStream();
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (string key in param.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, param[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }

                //文件开始
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                //图片
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "image", "image.jpg", "text/plain");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);
                rs.Write(data, 0, data.Length);
                //文件结束
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    var responseStream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(responseStream);
                    var content = sr.ReadToEnd();
                    sr.Close();
                    return content;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string PostPhoto(string url, byte[] data, string cookie, Dictionary<string, string> param)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)PostImage(url, boundary);
            if (!cookie.IsEmpty())
                request.Headers["cookie"] = cookie;

            WebResponse response = null;

            StringBuilder sb = new StringBuilder();
            try
            {
                var rs = request.GetRequestStream();
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (string key in param.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, param[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }

                //文件开始
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                //图片
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "photo", "image.jpg", "text/plain");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);
                rs.Write(data, 0, data.Length);
                //文件结束
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    var responseStream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(responseStream);
                    var content = sr.ReadToEnd();
                    sr.Close();
                    return content;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Post(string url, Dictionary<string, string> parms)
        {
            var dataQuery = parms.LinkUrl();
            var data = Encoding.UTF8.GetBytes(dataQuery);
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = data.Length;
            var responseStr = "";
            try
            {
                using (var rs = request.GetRequestStream())
                {
                    rs.Write(data, 0, data.Length);
                }
                var response = request.GetResponse();
                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
            }
            return responseStr;
        }

        public string Post(string url, string cookie, Dictionary<string, string> parms)
        {
            var dataQuery = parms.LinkUrl();
            var data = Encoding.UTF8.GetBytes(dataQuery);
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = data.Length;
            if (!cookie.IsEmpty())
                request.Headers["cookie"] = cookie;
            var responseStr = "";
            try
            {
                using (var rs = request.GetRequestStream())
                {
                    rs.Write(data, 0, data.Length);
                }
                var response = request.GetResponse();
                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = stream.ReadToEnd();
                }
            }
            catch
            {
            }
            return responseStr;
        }

        public string Delete(string url, string cookie)
        {
            try
            {
                var request = WebRequest.Create(url);
                request.Timeout = 5000;
                request.Method = "DELETE";
                if (!cookie.IsEmpty())
                    request.Headers["cookie"] = cookie;

                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var str = reader.ReadToEnd();
                return str;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 登录V3
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parms"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public KoalaLogin Login(string url, Dictionary<string, string> parms, out string cookie)
        {
            try
            {
                var buffer = parms.LinkUrl().ToUtf8();
                var wr = (HttpWebRequest)WebRequest.Create(url);
                wr.Timeout = 5000;
                wr.ContentType = "application/x-www-form-urlencoded";
                wr.Method = "POST";
                wr.UserAgent = "Koala Admin";
                wr.ContentLength = buffer.Length;

                var requeststream = wr.GetRequestStream();
                requeststream.Write(buffer, 0, buffer.Length);
                requeststream.Close();

                var response = wr.GetResponse();
                var stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                var content = sr.ReadToEnd();

                var headers = response.Headers;
                cookie = headers["Set-Cookie"];
                //return content.Deserialize<KoalaLogin>();
                return new KoalaLogin();
            }
            catch (Exception ex)
            {
                cookie = "";
                return null;
            }
        }

        public T Get<T>(string url, string cookie)
        {
            var wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Timeout = 5000;
            wr.Method = "GET";
            if (!cookie.IsEmpty())
                wr.Headers.Add("cookie", cookie);

            try
            {
                var response = wr.GetResponse();
                var stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                var content = sr.ReadToEnd();
                return content.Deserialize<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public FaceCompare Compare(string url, byte[] data1, byte[] data2)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)PostImage(url, boundary);
            WebResponse response = null;

            StringBuilder sb = new StringBuilder();
            try
            {
                var rs = request.GetRequestStream();
                //string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                //foreach (string key in param.Keys)
                //{
                //    rs.Write(boundarybytes, 0, boundarybytes.Length);
                //    string formitem = string.Format(formdataTemplate, key, param[key]);
                //    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                //    rs.Write(formitembytes, 0, formitembytes.Length);
                //}

                //文件开始
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                //图片1
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "image1", "image1.jpg", "text/plain");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);
                rs.Write(data1, 0, data1.Length);
                //文件结束1
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                rs.Write(trailer, 0, trailer.Length);

                //图片2
                string header2 = string.Format(headerTemplate, "image2", "image2.jpg", "text/plain");
                byte[] headerbytes2 = System.Text.Encoding.UTF8.GetBytes(header2);
                rs.Write(headerbytes2, 0, headerbytes.Length);
                rs.Write(data2, 0, data2.Length);

                //文件结束
                rs.Write(trailer, 0, trailer.Length);

                rs.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    var responseStream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(responseStream);
                    var content = sr.ReadToEnd();
                    sr.Close();
                    return content.Deserialize<FaceCompare>();
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
