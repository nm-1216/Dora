
namespace Dora.Core
{
    using System.Text;

    public static class Pager
    {


        public static int PageSize { get; private set; }

        public static int CurrPage { get; private set; }

        public static int PageCount { get; private set; }

        public static int RecordCount { get; private set; }

        public static string Path { get; set; }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="htmlAttributes">分页头标签属性</param>
        /// <param name="className">分页样式</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager1(string path,int currPage, int pageSize, int pageCount, int recordCount)
        {
            CurrPage = currPage;
            PageSize = pageSize;

            PageCount = pageCount;
            
            RecordCount = recordCount;

            Path = path;

            StringBuilder sb = new StringBuilder();

            sb.Append("\n\n<!-- 分页 开始 -->\n\n");
            sb.Append("<div class=\"PList\">\n");

            sb.Append(Msg);

            sb.Append(Nav);

            //writer.Write(sb.ToString());

            //Jump(writer);


            sb.Append("\n</div>\n");

            sb.Append("\n<!-- 分页 结束 -->\n\n");


            return (sb.ToString());
        }


        public static int MoveStep
        {
            get
            {
                return 10;
            }
        }

        private static int Pre
        {
            get
            {
                return CurrPage <= 1 ? 1 : CurrPage - 1;
            }
        }

        private static int Next
        {
            get
            {
                return CurrPage >= PageCount ? PageCount : CurrPage + 1;
            }
        }

        private static int[] StartAndEnd
        {
            get
            {
                int pStart = 1, pEnd = 1;
                if (RecordCount <= 1)
                {
                    pStart = 1; pEnd = 1;
                }
                else if (RecordCount <= MoveStep)
                {
                    pStart = 1; pEnd = RecordCount;
                }
                else
                {
                    if (CurrPage > MoveStep / 2)
                    {
                        if (MoveStep % 2 == 0)
                        {
                            pStart = CurrPage - MoveStep / 2 + 1;
                            pEnd = MoveStep % 2 == 0 ? CurrPage + MoveStep / 2 : CurrPage + MoveStep / 2 - 1;
                            if (pEnd > RecordCount) { pStart -= pEnd - RecordCount; pEnd = RecordCount; }
                        }
                        else
                        {
                            pStart = CurrPage - MoveStep / 2;
                            pEnd = CurrPage + MoveStep / 2;
                            if (pEnd > RecordCount) { pStart -= pEnd - RecordCount; pEnd = RecordCount; }
                        }

                    }
                    else
                    {
                        pStart = 1; pEnd = MoveStep;
                    }
                }
                return new int[] { pStart, pEnd > PageCount ? PageCount : pEnd };

            }
        }

        private static string Msg
        {
            get
            {
                return ("\t<span class=\"msg\">每页 <b> " + PageSize + " </b> 条 , 共 <b>" + RecordCount.ToString() + "</b> 条 <b>" + PageCount + "</b> 页</span>\n");
            }
        }

        private static string Url
        {
            get
            {
                string url = "javascript: AspNetPager({0})";

                //url = Path;//HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.Url.PathAndQuery);
                //Regex reg = new Regex(@"(\?|&){0,1}page=[^&]*", RegexOptions.IgnoreCase);
                //url = reg.Replace(url, string.Empty);
                //if (url.IndexOf("?") >= 0)
                //    url += "&page={0}";
                //else
                //    url += "?page={0}";

                return url;
            }
        }

        private static string Nav
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\t<span class=\"nav\">\n");


                if (CurrPage < 2)
                {
                    sb.Append("\t\t<a class=\"arr disabled\">首页</a>\n");
                    sb.Append("\t\t<a class=\"arr disabled\">上一页</a>\n");
                }
                else
                {
                    sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(Url, "1") + "\">首页</a>\n");
                    sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(Url, Pre.ToString()) + "\">上一页</a>\n");
                }

                sb.Append(Num);

                if (CurrPage >= PageCount)
                {
                    sb.Append("\t\t<a class=\"arr disabled\">下一页</a>\n");
                    sb.Append("\t\t<a class=\"arr disabled\">末页</a>\n");
                }
                else
                {
                    sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(Url, Next.ToString()) + "\">下一页</a>\n");
                    sb.Append("\t\t<a class=\"arr\" href=\"" + string.Format(Url, PageCount.ToString()) + "\">末页</a>\n");
                }

                sb.Append("\t</span>");
                return sb.ToString();
            }
        }

        private static string Num
        {
            get
            {
                StringBuilder sb = new StringBuilder();


                for (int i = StartAndEnd[0]; i <= StartAndEnd[1]; i++)
                {
                    if (i != CurrPage)
                        sb.Append("\t\t<a class=\"num\" href=\"" + string.Format(Url, i.ToString()) + "\">" + i.ToString() + "</a>\n");
                    else
                        sb.Append("\t\t<a class=\"Cur\">" + i.ToString() + "</a>\n");
                }

                return sb.ToString();
            }
        }

    }
}
