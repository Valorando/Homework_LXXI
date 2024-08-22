using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;

namespace Generate
{
    public class Generate_Keys
    {
        public static string GeneratePrivateKey()
        {
            var ecKey = EthECKey.GenerateKey();
            return ecKey.GetPrivateKeyAsBytes().ToHex();
        }

        public static string GenerateAddress(string privateKey)
        {
            var ecKey = new EthECKey(privateKey.HexToByteArray(), true);
            return ecKey.GetPublicAddress();
        }
    }
}