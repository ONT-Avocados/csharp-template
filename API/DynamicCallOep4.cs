using Ont.SmartContract.Framework;
using System;
using System.Numerics;

namespace Contract
{
    public class Contract : SmartContract
    {
        public delegate object OEP4Contract(string method, object[] args);

        public static Object Main(string operation, params object[] args)
        {
            if (operation == "CallOep4Contract")
            {
                if (args.Length != 4) return false;
                byte[] from = (byte[])args[0];
                byte[] to = (byte[])args[1];
                ulong value = (ulong)args[2];
                byte[] hash = (byte[])args[3];
                return CallOep4Contract(from, to, value, hash);
            }
            return false;
        }
       
        public static bool CallOep4Contract(byte[] from, byte[] to, ulong value, byte[] contractHash)
        {
       		
            if (!TransferOEP4(from, to, contractHash, value)) throw new Exception();
            return true;
        }

        private static bool TransferOEP4(byte[] from, byte[] to, byte[] assetID, BigInteger amount)
        {
            var args = new object[] { from, to, amount };
            var contract = (OEP4Contract)assetID.ToDelegate();
            if (!(bool)contract("transfer", args)) return false;
            return true;
        }
    }
}
