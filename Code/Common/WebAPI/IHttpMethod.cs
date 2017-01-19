using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.WebAPI
{
    public interface IHttpMethod
    {
        T HttpGet<T>(string url, out string requesterror) where T : class, new();

        string Post(string url, byte[] data, Dictionary<string, string> parms);

        string Post(string url, Dictionary<string, string> parms);
    }
}
