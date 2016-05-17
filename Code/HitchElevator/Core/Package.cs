using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HitachiLift
{
    /// <summary>
    /// 日立电梯协议包
    /// </summary>
    public static class Package
    {
        private const byte _bFrameStart = 0xAC;
        private const byte _bFrameEnd = 0xCA;

        /// <summary>
        /// 发送卡数据
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="handfloors"></param>
        /// <param name="autofloor"></param>
        /// <returns></returns>
        public static byte[] CardDataSendToLiftPackage(int cardID, byte[] handfloors, byte autofloor)
        {
            List<byte> buffers = new List<byte>();
            buffers.Add(_bFrameStart);
            buffers.Add(0x5C);

            byte[] cardBytes = Funs.IntToBytes(cardID);
            buffers.AddRange(cardBytes);
            //手动权限层
            buffers.AddRange(handfloors);
            //保留
            var reserves = Funs.InitArray(27, 0xFF);
            buffers.AddRange(reserves);
            //自动权限层及用户类型
            buffers.Add(autofloor);
            //校验位
            var xor = Funs.GetXOR(buffers);
            buffers.Add(xor);
            //帧尾
            buffers.Add(_bFrameEnd);
            
            var totals = buffers.ToArray();
            return totals;
        }

        /// <summary>
        /// 查询包
        /// </summary>
        /// <returns></returns>
        public static byte[] Query_Package()
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5A);

            var data = Funs.InitArray(5, 0xFF);
            package.AddRange(data);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }

        /// <summary>
        /// 确认包
        /// </summary>
        /// <returns></returns>
        public static byte[] Confrm_Package(int cardID)
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5A);

            var cardBytes = Funs.IntToBytes(cardID);
            package.AddRange(cardBytes);

            package.Add(0xFF);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }

        /// <summary>
        /// 变更波特率
        /// </summary>
        /// <param name="baudRate"></param>
        /// <returns></returns>
        public static byte[] ChangeBaud_Package(int baudRate)
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5B);

            var baudBytes = Funs.IntToBytes(baudRate);
            package.AddRange(baudBytes);

            package.Add(0xFF);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);

            return package.ToArray();
        }

        /// <summary>
        /// 查询闸机状态
        /// </summary>
        /// <returns></returns>
        public static byte[] QueryGateState_Package()
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5E);

            var data = Funs.InitArray(5, 0xFF);
            package.AddRange(data);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }

        /// <summary>
        /// 查询闸机卡片权限
        /// </summary>
        /// <returns></returns>
        public static byte[] QueryGateCardState_Package(int cardId)
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5E);

            var cardBytes = Funs.IntToBytes(cardId);
            package.AddRange(cardBytes);

            package.Add(0xFF);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }


        /// <summary>
        /// 没有卡数据包
        /// </summary>
        /// <returns></returns>
        public static byte[] NoCard_Package()
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5C);

            var data = Funs.InitArray(40, 0xFF);
            package.AddRange(data);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }

        /// <summary>
        /// 闸机状态数据包
        /// </summary>
        /// <param name="gateState"></param>
        /// <returns></returns>
        public static byte[] GateState_Package(byte gateState)
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5F);

            var data = Funs.InitArray(38, 0xFF);
            package.AddRange(data);

            package.Add(gateState);
            package.Add(0x00);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }

        /// <summary>
        /// 确认闸机卡片状态
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static byte[] ConfrmGateCard_Package(int cardID, byte permission)
        {
            List<byte> package = new List<byte>();
            package.Add(_bFrameStart);
            package.Add(0x5F);

            var bytes = Funs.IntToBytes(cardID);
            package.AddRange(bytes);

            var data = Funs.InitArray(34, 0xFF);
            package.AddRange(data);

            package.Add(permission);
            package.Add(0x00);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }
        /// <summary>
        /// 确认波特率变更
        /// </summary>
        /// <param name="baudRate"></param>
        /// <returns></returns>
        public static byte[] ConfrmBaudRate_Package(int baudRate)
        {
            List<byte> package = new List<byte>(44);    
            package.Add(_bFrameStart);
            package.Add(0x5D);

            var baudBytes = Funs.IntToBytes(baudRate);
            package.AddRange(baudBytes);

            var data = Funs.InitArray(36, 0xFF);
            package.AddRange(data);

            byte xor = Funs.GetXOR(package);
            package.Add(xor);
            package.Add(_bFrameEnd);
            return package.ToArray();
        }
    }
}
