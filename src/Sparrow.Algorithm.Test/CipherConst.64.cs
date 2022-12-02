using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string Original64 = "11111111";
        internal const string Key64 = "qwertyui";
        internal const string IV64 = "11111111";
        internal static byte[] Original64Bytes
        {
            get
            {
                return Encoding.UTF8.GetBytes(Original64);
            }
        }
        internal static byte[] Key64Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(Key64);
            }
        }
        internal static byte[] IV64Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(IV64);
            }
        }

    }
}
