using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string Original512 = "1111111122222222111111112222222211111111222222221111111122222222";
        internal const string Key512 = "qwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjk";
        internal static byte[] Original512Bytes
        {
            get
            {
                return Encoding.UTF8.GetBytes(Original512);
            }
        }
        internal static byte[] Key512Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(Key512);
            }
        }
    }
}
