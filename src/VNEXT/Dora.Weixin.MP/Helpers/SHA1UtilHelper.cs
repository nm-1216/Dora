
using System;
using System.Security.Cryptography;
using System.Text;
using Dora.Helpers;

namespace Dora.Weixin.MP.Helpers
{
    public class SHA1UtilHelper
    {
        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [Obsolete("此方法已过期，请使用Dora.Weixin.Helpers.EncryptHelper.GetSha1(str)")]
        public static string GetSha1(string str)
        {
            return EncryptHelper.GetSha1(str);

            ////建立SHA1对象
            //SHA1 sha = new SHA1CryptoServiceProvider();
            ////将mystr转换成byte[] 
            //ASCIIEncoding enc = new ASCIIEncoding();
            //byte[] dataToHash = enc.GetBytes(str);
            ////Hash运算
            //byte[] dataHashed = sha.ComputeHash(dataToHash);
            ////将运算结果转换成string
            //string hash = BitConverter.ToString(dataHashed).Replace("-", "");
            //return hash;
        }
    }
}