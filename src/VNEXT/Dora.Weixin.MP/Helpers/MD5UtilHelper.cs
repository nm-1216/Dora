
using System;
using System.Security.Cryptography;
using System.Text;
using Dora.Helpers;

namespace Dora.Weixin.MP.Helpers
{
	/// <summary>
    /// MD5UtilHelper 
	/// </summary>
	public class MD5UtilHelper
	{
        /// <summary>
        /// ��ȡ��д��MD5ǩ�����
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, string charset)
        {
            return EncryptHelper.GetMD5(encypStr, charset);
        }
	}
}
