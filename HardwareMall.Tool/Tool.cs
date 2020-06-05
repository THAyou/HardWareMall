using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;



namespace Tools
{
    public class Utils
    {

        #region 字符串处理

        /// <summary>
        /// 剪切字符串
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="intLen"></param>
        /// <returns></returns>
        public static string CutString(string strInput, int intLen)
        {
            if (String.IsNullOrEmpty(strInput))
                return strInput;
            strInput = strInput.Trim();
            byte[] buffer1 = Encoding.Default.GetBytes(strInput);
            if (buffer1.Length > intLen)
            {
                string text1 = "";
                for (int num1 = 0; num1 < strInput.Length; num1++)
                {
                    byte[] buffer2 = Encoding.Default.GetBytes(text1);
                    if (buffer2.Length >= (intLen - 4))
                    {
                        break;
                    }
                    text1 = text1 + strInput.Substring(num1, 1);
                }
                return (text1 + "...");
            }
            return strInput;
        }
        /// <summary>
        /// 获取：张***三格式的字段
        ///创建人：张成  时间：2012-03-04
        /// </summary>
        /// <param name="strInput">文件</param>
        /// <returns></returns>
        public static string GetSubContent(string strInput)
        {
            if (String.IsNullOrEmpty(strInput))
                return strInput;
            else
            {
                string text1 = "";
                text1 += strInput.Substring(0, 1);
                for (int num1 = 1; num1 < strInput.Length - 1; num1++)
                {
                    text1 += "*";
                }
                text1 += strInput.Substring(strInput.Length - 1);
                return text1;
            }
        }
        /// <summary>
        /// 文本框内容输出成一行(文本内容去回车空格,转换HTML输出)
        /// 创建人：陈民礼  时间：2012-12-20
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToLineText(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = RemoveHtml(str);
            str = str.Replace("　", "");

            string text1 = "\\s+";
            Regex regex1 = new Regex(text1);
            str = regex1.Replace(str, " ");
            str = System.Web.HttpUtility.HtmlEncode(str);
            return str.Trim();
        }

        /// <summary>
        /// 剪切字符串(末尾不加点号)
        /// 创建人:吕海斌 创建时间:2012-1-12 
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="intLen"></param>
        /// <returns></returns>
        public static string GetSubString(string strInput, int intLen)
        {
            strInput = strInput.Trim();
            byte[] buffer1 = Encoding.Default.GetBytes(strInput);
            if (buffer1.Length > intLen)
            {
                string text1 = "";
                for (int num1 = 0; num1 < strInput.Length; num1++)
                {
                    byte[] buffer2 = Encoding.Default.GetBytes(text1 + strInput.Substring(num1, 1));
                    if (buffer2.Length > intLen)
                    {
                        break;
                    }
                    text1 = text1 + strInput.Substring(num1, 1);
                }
                return (text1 + "…");
            }
            return strInput;
        }

        /// <summary>
        /// 读取末尾字符串数
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="intLen"></param>
        /// <returns></returns>
        public static string GetR_SubString(string strInput, int intLen)
        {
            strInput = strInput.Trim();
            byte[] buffer1 = Encoding.Default.GetBytes(strInput);
            if (buffer1.Length > intLen)
            {
                string text1 = "";
                for (int num1 = strInput.Length - intLen; num1 < strInput.Length; num1++)
                {
                    byte[] buffer2 = Encoding.Default.GetBytes(text1 + strInput.Substring(num1, 1));
                    if (buffer2.Length > intLen)
                    {
                        break;
                    }
                    text1 = text1 + strInput.Substring(num1, 1);
                }
                return text1;
            }
            return strInput;
        }

        /// <summary>
        /// 文本框内容输出成html显示
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToHtmlText(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            StringBuilder builder1 = new StringBuilder();
            builder1.Append(str);
            builder1.Replace("&", "&amp;");
            builder1.Replace("<", "&lt;");
            builder1.Replace(">", "&gt;");
            builder1.Replace("\"", "&quot;");
            builder1.Replace("\r", "<br>");
            builder1.Replace(" ", "&nbsp;");
            return builder1.ToString();
        }


        /// <summary>
        /// 去除html标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveHtml(string str)
        {
            string text1 = "<.*?>";
            Regex regex1 = new Regex(text1);
            str = regex1.Replace(str, "");
            str = str.Replace("&nbsp;", " ");
            return str;
        }

        /// <summary>
        /// 去除html标签并截字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string RemoveHtmlAndLimit(string str, int num)
        {
            str = RemoveHtml(str);
            str = CutString(str, num);

            return str;
        }


        /// <summary>
        /// 转换大写字母 避免特殊字符转换错误
        /// 创建人:俞忠亮 创建时间:2012-5-29
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUpperNew(string str)
        {
            string ret = string.Empty;
            str = str.Trim();
            foreach (char zf in str)
            {
                if ('a' <= zf && zf <= 'z')
                {
                    ret += char.ToUpper(zf);
                }
                else
                {
                    ret += zf;
                }
            }

            return ret;
        }



        public static bool IsNumber(string checkStr)
        {
            if (string.IsNullOrEmpty(checkStr)) { return false; }
            return Regex.IsMatch(checkStr, @"^[-]{0,1}\d+$");

        }


        /// <summary>
        /// 格式为yyyy-MM-dd
        /// 创建人:吕海斌 创建时间:2012-3-16
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDate(string date)
        {
            Regex reg = new Regex(@"^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])$");
            return reg.IsMatch(date);
        }

        /// <summary>
        /// 格式为yyyy-MM-dd hh:mm:ss
        /// 创建人:俞忠亮 创建时间:2012-5-1-76
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateTime(string date)
        {
            Regex reg = new Regex(@"^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])\s+(1[012]|0?[1-9]){1}:(0?[1-5]|[0-6][0-9]){1}:(0?[0-6]|[0-6][0-9]){1}$");
            return reg.IsMatch(date);
        }

        /// <summary>
        /// 格式为yyyy-MM-dd hh:mm
        /// 创建人:俞忠亮 创建时间:2013-2-3
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateTime2(string date)
        {
            Regex reg = new Regex(@"^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])\s+(2[0123]|1[0-9]|0?[0-9]){1}:(0?[0-9]|[1-5][0-9]|60){1}$");
            return reg.IsMatch(date);
        }

        /// <summary>
        /// 是否为URL地址
        /// 创建人：吴李辉 时间：2012-6-28
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrl(string url)
        {
            Regex reg = new Regex(@"^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$", RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }



        /// <summary>
        /// 获取随即数.a-z,0-9
        /// 陈艺艺
        /// </summary>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string GetRadmonString(int len)
        {

            Random random = new Random();
            var _chars = new char[36];
            for (int i = 65; i <= 90; i++)
            {
                _chars[i - 65] = (char)i;
            }
            for (int i = 48; i < 58; i++)
            {

                _chars[i - 22] = (char)(i);

            }
            string str = string.Empty;
            for (int i = 0; i < len; i++)
            {
                str += _chars[random.Next(0, 35)];
            }
            return str;
        }

        /// <summary>
        /// 获取随机6位数字
        /// 俞忠亮
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetNumCode(int num)
        {
            string a = "0123456789";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Append(a[new Random(Guid.NewGuid().GetHashCode()).Next(0, a.Length - 1)]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 是否是价格 小数点后保留后两位 包括正或负
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPrice(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            Regex reg = new Regex(@"^[-+]?(\d{1,}|\d{1,}\.\d{1,2}0{0,})$");
            return reg.Match(str).Success;
        }

        /// <summary>
        /// 是否为lookchemmall网站文件     Author：王建魁     时间：2012-05-02
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsLookchemFile(string path)
        {

            Regex reg = new Regex(@"^(http(s)?://|//)[\w-\.]*?\.lookchemmall\.com[\w\./]+?$");
            Regex reg2 = new Regex(@"^(http(s)?://|//)[\w-\.]*?\.luech\.com[\w\./]+?$");
            Regex reg3 = new Regex(@"^(http(s)?://|//)[\w-\.]*?\.lookchem\.com[\w\./]+?$");
            if (reg.Match(path).Success)
                return true;
            else if (reg2.Match(path).Success)
                return true;
            else
                return reg3.Match(path).Success;
        }

        /// <summary>
        ///数据库插入值判断
        /// 替换Unicode码+替换关键字 每个传入数据库的值必须调用这个方法
        /// 创建人：张成 创建时间:2013-04-24
        /// </summary>
        /// <param name="InputValue">传入值</param>
        public static string ReplaceAndFilterData(string InputValue)
        {
            string temp = string.Empty;
            if (InputValue == null)
            {
                return temp;
            }
            else
            {
                temp = InputValue;
            }
            #region 转换为Unicode码
            string str_a1 = "'|\\|<|>";
            string str_a2 = "&#39;|&#92;|&lt;|&gt;";
            string[] strs_a1 = str_a1.Split('|');
            string[] strs_a2 = str_a2.Split('|');
            //转换
            for (int i = 0; i < strs_a1.Length; i++)
            {
                temp = temp.Replace(strs_a1[i], strs_a2[i]);
            }
            #endregion

            temp = Regex.Replace(temp, @"\<script[^>]*>|<\/script>", "", RegexOptions.IgnoreCase);
            temp = Regex.Replace(temp, @"\<form[^>]*>|<\/form>", "", RegexOptions.IgnoreCase);


            #region 替换SQL关键字
            string word = "insert|delete|update|truncate|declare";
            foreach (string i in word.Split('|'))
            {
                temp = temp.Replace(i + " ", "").Replace(" " + i, "");
            }
            //string word1 = "and |exec |insert |select |delete |update |chr |mid |master |or |truncate |char |declare |join ";
            //string word2 = " and| exec| insert| select| delete| update| chr| mid| master| or| truncate| char| declare| join";

            //temp = Regex.Replace(temp, word1, "", RegexOptions.IgnoreCase);
            //temp = Regex.Replace(temp, word2, "", RegexOptions.IgnoreCase);
            #endregion

            return temp;
        }
        public static bool IsCasNo(string casno)
        {
            string tempCasNo = casno.Trim();
            if (Regex.IsMatch(tempCasNo, "^[0-9]{2,7}-[0-9]{1,2}-[0-9]{1}$"))
            {
                string cas2 = tempCasNo.Substring(0, tempCasNo.Length - 2).Replace("-", "");
                int iAllCount = 0;
                int iIndex = 1;
                for (int i = cas2.Length - 1; i >= 0; i--)
                {
                    iAllCount += Convert.ToInt32(cas2.Substring(i, 1)) * iIndex;
                    iIndex++;
                }
                int iLastNum = Convert.ToInt32(tempCasNo.Substring(tempCasNo.Length - 1, 1));
                if (iAllCount % 10 == iLastNum)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否为中文
        /// </summary>
        /// <param name="strkey"></param>
        /// <returns></returns>
        public static bool IsChinaese(string strkey)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(strkey, @"[\u4e00-\u9fbb]");
        }
        #endregion


        #region 文件处理





        /// <summary>
        /// 获得一个17位时间随机数
        /// </summary>
        /// <returns>返回随机数</returns>
        public static string GetDataRandom()
        {

            return System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }


        public static string GetFileSize(float filesize)
        {
            float filesizeFloat = filesize / 1024;
            if (filesizeFloat < 1024)
            {
                return Math.Ceiling(filesizeFloat) + "K";
            }
            else
            {
                filesizeFloat = filesizeFloat / 1024;
                return Math.Round(filesizeFloat, 2) + "M";
            }

        }

        #endregion

        #region 网络文件获取
        /// <summary>
        /// 下载网络文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="savePath">保存路径</param>
        /// <returns></returns>
        public static bool DownLoadFile(string url, string savePath)
        {
            try
            {
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(url, savePath);
                return true;
            }
            catch
            {
                return false;
            }

        }



        /// <summary>
        /// 下载网络文件(传递前导页，破简单的反盗链)
        /// </summary>
        /// <param name="url">网络文件地址</param>
        /// <param name="savePath">保存文件的路径</param>
        /// <param name="referer">需要传递的前导页</param>
        /// <returns>下载文件的大小(K)</returns>
        public static float DownLoadFile(string url, string savePath, string referer)
        {
            try
            {
                long ThisLength = 0;
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.01; Windows NT 5.0)";
                myHttpWebRequest.Referer = referer;
                myHttpWebRequest.Timeout = 10 * 1000;
                myHttpWebRequest.Method = "GET";


                HttpWebResponse res = myHttpWebRequest.GetResponse() as HttpWebResponse;
                System.IO.Stream stream = res.GetResponseStream();


                byte[] b = new byte[1024];
                int nReadSize = 0;
                nReadSize = stream.Read(b, 0, 1024);

                System.IO.FileStream fs = System.IO.File.Create(savePath);
                try
                {

                    while (nReadSize > 0)
                    {
                        ThisLength += nReadSize;
                        fs.Write(b, 0, nReadSize);
                        nReadSize = stream.Read(b, 0, 1024);
                    }
                }
                catch
                {
                    ThisLength = 0;
                }
                finally
                {
                    fs.Close();
                }
                res.Close();
                stream.Close();
                myHttpWebRequest.Abort();
                if (ThisLength < 1024 && ThisLength > 0)
                {
                    return 1;
                }
                return (float)(ThisLength / 1024);
            }
            catch
            {
                return 0;
            }
        }



        #endregion
    }
}
