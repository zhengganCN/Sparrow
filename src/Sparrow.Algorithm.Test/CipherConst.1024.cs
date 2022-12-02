using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal static string Original1024Bit
        {
            get
            {
                return "11111111222222221111111122222222111111112222222211111111222222221111111122222222111111112222222211111111222222221111111122222222";
            }
        }

        internal const string Key1024 = "qwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjkqwertyuiasdfghjk";
        internal static byte[] Original1024Bytes
        {
            get
            {
                return Encoding.UTF8.GetBytes(Original1024Bit);
            }
        }
        internal static byte[] Key1024Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(Key1024);
            }
        }
    }
}
