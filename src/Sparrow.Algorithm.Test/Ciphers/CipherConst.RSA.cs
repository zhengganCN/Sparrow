namespace Sparrow.Algorithm.Test
{
    internal partial class CipherConst
    {
        internal const string KeyPublicRSA = "MFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBALvIKE+qKGGLFQmkEmSyMHcvEEBG7vWX2MK2ZHsATAgfhmfZrNN53/WxNaDHP+EJ8CfyeKvW10S+WwUdr8ErISECAwEAAQ==";
        internal const string KeyPrivateRSA = "MIIBVQIBADANBgkqhkiG9w0BAQEFAASCAT8wggE7AgEAAkEAu8goT6ooYYsVCaQSZLIwdy8QQEbu9ZfYwrZkewBMCB+GZ9ms03nf9bE1oMc/4QnwJ/J4q9bXRL5bBR2vwSshIQIDAQABAkEAuz2GFImS4lCQlaBoRsf206C2D6GrPHBAz0aXQp61MZKoYSju+oXGLGrgU5og6eVu9ksgDDFl70y3Gm/DFeQ7AQIhAN6vS/jpqdJ8zXFSagpmpyvWDn3yx61Ig6RtNFT3nS4JAiEA1+AZbmNMhC3foIWbUpO7CEgSrq3lhUaSqMacyQjdIFkCIQCtxPMvAP/RTixvAtXW2fYXwgk7BWoF8bEwbTtKFpOkKQIgBUsadIl8y9TwIdiE2X6D3I0f4CaldSIo4HiWSZutCGkCIGNpa/8UxVDBd/E6f0YXSK6zgaQ8v7IMmg/IOr6zkrWt";
        internal static byte[] KeyPublicRSABytes
        {
            get
            {
                return Convert.FromBase64String(KeyPublicRSA);
            }
        }

        internal static byte[] KeyPrivateRSABytes
        {
            get
            {
                return Convert.FromBase64String(KeyPrivateRSA);
            }
        }
    }
}
