using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string Original256 = "11111111222222221111111122222222";
        internal const string Key256 = "qwertyuiasdfghjkqwertyuiasdfghjk";
        internal static byte[] Original256Bytes
        {
            get
            {
                return Encoding.UTF8.GetBytes(Original256);
            }
        }
        internal static byte[] Key256Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(Key256);
            }
        }
    }
}
