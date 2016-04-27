using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace MeetingClient.Core
{
    public class MeetingHttpRequest : IDisposable
    {
        /// <summary>
        /// API地址区分大小写
        /// </summary>
        private const string URL = "https://meeting.yowhale.com/openapi/guard/openDoor.json?{0}";

        public SortedDictionary<string, string> GetRequestParam(string qrcode)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("content", qrcode);
            sParaTemp.Add("gurad", Config.termId);
            sParaTemp.Add("app", Config.App);
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

            var mysign = AlipayMD5.Sign(preSignStr, Config.Key, Config.Input_charset);

            return mysign;
        }

        public bool VerfiyAccess(string qrcode)
        {
            var mysign = GetSign(qrcode);

            //真正的url
            var inputPara = GetRequestParam(qrcode);
            inputPara.Add("sign", mysign);
            inputPara.Add("sign_type", Config.Sign_type);

            var urlcode = Encoding.GetEncoding(Config.Input_charset);
            var preSignStr = Core.CreateLinkStringUrlencode(inputPara, urlcode);

            try
            {
                var httpGetUrl = string.Format(URL, preSignStr);
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
                    return false;

                JavaScriptSerializer java = new JavaScriptSerializer();
                var jsonObject = java.Deserialize<ErrorModel>(jsonStr);
                return jsonObject.success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
        }
    }
}
