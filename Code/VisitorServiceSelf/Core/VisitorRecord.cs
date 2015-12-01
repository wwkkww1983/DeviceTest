using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorServiceSelf.Core
{
    public class VisitorRecord
    {
        public VisitorInfo VisitorInfo { get; set; }

        public ResponserInfo ResponserInfo { get; set; }

        public CertificateInfo CertificateInfo { get; set; }


        public void Reset()
        {

        }
    }

    public class VisitorInfo
    {
    }

    public class ResponserInfo
    {
    }

    public class CertificateInfo
    {

    }
}
