namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string KeyPublicELGAMAL = "A0QAAkEAk55MGbz8MXXYVCBlr3DQykuZFilrFGQ0d9h1TbTyt9OpT0kdAPGEz812rCkZNLlFn7LqYCcC9h/iF6zRMJjyfg==";
        internal const string KeyPrivateELGAMAL = "BEICQG/5vRQgB50qMH/ABNBPbsCryP4me04DTEZHVpmdMu0mT6610TspsOCZZeCP1OG/DQJsC55g1NWVXmp4Xt3JsIM=";
        internal static byte[] KeyPublicELGAMALBytes
        {
            get
            {
                return Convert.FromBase64String(KeyPublicELGAMAL);
            }
        }

        internal static byte[] KeyPrivateELGAMALBytes
        {
            get
            {
                return Convert.FromBase64String(KeyPrivateELGAMAL);
            }
        }
    }
}
