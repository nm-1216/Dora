namespace Dora.Utilities.WebProxy
{
    using System;
    using System.Net;

    /// <summary>
    /// .NET Core 使用的 WebProxy 类
    /// 参考：http://www.abelliu.com/dotnet/dotnet%20core/2017/03/14/dotnetcore-proxy/
    /// </summary>
    public class CoreWebProxy : IWebProxy
    {
        public readonly Uri Uri;
        private readonly bool bypass;

        public CoreWebProxy(Uri uri, ICredentials credentials = null, bool bypass = false)
        {
            Uri = uri;
            this.bypass = bypass;
            Credentials = credentials;
        }

        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination) => Uri;

        public bool IsBypassed(Uri host) => bypass;

        public override int GetHashCode()
        {
            if (Uri == null)
            {
                return -1;
            }

            return Uri.GetHashCode();
        }
    }
}
