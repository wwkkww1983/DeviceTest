using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GateTest.Visitor
{
    public struct GateCommon
    {
        public byte SFD;
        public byte DA;
        public byte SA;
        public byte Len;
        public byte group;
        public byte key;
        public ushort reserved;
        public byte installationtype;
        public byte subkey;
    }
}
