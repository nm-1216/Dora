
using System;
using System.Text;
using System.Net;
using Dora.Weixin.Helpers;
using Dora.Helpers;

namespace Dora.Weixin.MP.TenPayLibV3
{
    /// <summary>
    /// ΢��֧��������
    /// </summary>
    public class TenPayV3Util
    {
        public static Random random = new Random();

        /// <summary>
        /// �������Noncestr
        /// </summary>
        /// <returns></returns>
        public static string GetNoncestr()
        {
            return EncryptHelper.GetMD5(Guid.NewGuid().ToString(), "UTF-8");
        }

        /// <summary>
        /// ��ȡ΢��ʱ���ʽ
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// ���ַ�������URL����
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="charset">��.netstandard1.6��Ч</param>
        /// <returns></returns>
        public static string UrlEncode(string instr, string charset)
        {
            //return instr;
            if (instr == null || instr.Trim() == "")
                return "";
            else
            {
                //string res;

                try
                {
                    return WebUtility.UrlEncode(instr);
                }
                catch (Exception ex)
                {
                    return WebUtility.UrlEncode(instr);
                }

                //return res;
            }
        }

        /// <summary>
        /// ���ַ�������URL����
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string UrlDecode(string instr, string charset)
        {
            if (instr == null || instr.Trim() == "")
                return "";
            else
            {
                //string res;

                try
                {
                    return WebUtility.UrlDecode(instr);
                }
                catch (Exception ex)
                {
                    return WebUtility.UrlDecode(instr);
                }

            }
        }


        /// <summary>
        /// ȡʱ��������漴��,�滻���׵����еĺ�10λ��ˮ��
        /// </summary>
        /// <returns></returns>
        public static UInt32 UnixStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1);
            return Convert.ToUInt32(ts.TotalSeconds);
        }

        /// <summary>
        /// ȡ�����
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BuildRandomStr(int length)
        {
            int num;

            lock (random)
            {
                num = random.Next();
            }

            string str = num.ToString();

            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            else if (str.Length < length)
            {
                int n = length - str.Length;
                while (n > 0)
                {
                    str = str.Insert(0, "0");
                    n--;
                }
            }

            return str;
        }

        /// <summary>
        /// ���������ڲ����ظ�������
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BuildDailyRandomStr(int length)
        {
            var stringFormat = DateTime.Now.ToString("HHmmss0000");//��10λ

            return stringFormat;
        }

    }
}