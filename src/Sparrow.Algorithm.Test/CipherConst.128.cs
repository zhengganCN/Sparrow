using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string Original128 = "1111111122222222";
        internal const string Key128 = "qwertyuiasdfghjk";
        internal const string IV128 = "1111111122222222";
        internal static byte[] Original128Bytes
        {
            get
            {
                return Encoding.UTF8.GetBytes(Original128);
            }
        }
        internal static byte[] Key128Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(Key128);
            }
        }
        internal static byte[] IV128Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(IV128);
            }
        }
    }
}
