using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HitachiLift
{
    public static class Package
    {
        private static byte[] InitArray(int length, byte val)
        {
            byte[] array = new byte[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = val;
            }
            return array;
        }

        private static byte GetXOR(List<byte> data)
        {
            byte val = 0;
            foreach (var b in data)
            {
                val ^= b;
            }
            return val;
        }

        public static byte[] CardDataSendToLiftPackage(byte[] handfloors, byte autofloor)
        {
            List<byte> buffers = new List<byte>();
            buffers.Add(0xAC);
            buffers.Add(0x5C);

            byte[] cardID = new byte[4] { 0, 0, 0, 0 };
            buffers.AddRange(cardID);

            buffers.AddRange(handfloors);

            var reserves = InitArray(27, 0xFF);
            buffers.AddRange(reserves);

            buffers.Add(autofloor);

            var xor = GetXOR(buffers);
            buffers.Add(xor);

            buffers.Add(0xCA);

            var totals = buffers.ToArray();
            return totals;
        }
    }
}
