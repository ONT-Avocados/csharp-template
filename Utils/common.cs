using Ont.SmartContract.Framework;
using Ont.SmartContract.Framework.Services.Ont;
using Ont.SmartContract.Framework.Services.System;
using System.Numerics;

public class Contract : SmartContract
{
    public static bool Main(string operation, params object[] args)
    {
        return false;
    }

    public byte[] bytesConcat(byte[] a, byte[] b)
    {
        return a.Concat(b);
    }

    public byte[] stringConcat(string a, string b)
    {
        return a.AsByteArray().Concat(b.AsByteArray());
    }

    public byte[] stringToBytes(string s)
    {
        return s.AsByteArray();
    }

    public string bytesToString(byte[] arr)
    {
        return arr.AsString();
    }

    public BigInteger bytestoBiginteger(byte[] arr)
    {
        return arr.AsBigInteger();
    }

    public byte[] bigintegerToBytes(BigInteger b)
    {
        return b.AsByteArray();
    }
    
    public static bool validateAddress(byte[] address)
    {
        if (address.Length != 20) return false;
        if (address.AsBigInteger() == 0) return false;
        return true;
    }
}
