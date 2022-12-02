using System.Text;

namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string IV96 = "111111112222";
        internal static byte[] IV96Bytes
        {
            get
            {
                return Encoding.ASCII.GetBytes(IV96);
            }
        }
    }
}
