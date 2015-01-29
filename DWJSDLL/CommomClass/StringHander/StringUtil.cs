using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Globalization;
namespace CommonClass.StringHander
{
    /// <summary>
    /// 字符串相关处理
    ///by:xucongli  @2012  
    ///http://blog.csdn.net/luoyeyu1989
    /// </summary>
    public class StringUtil
    {
        #region 私有变量
        private static byte[] val = { 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x00, 0x01,
          0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F,
          0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F, 0x3F };
        private static char[] constant =   
          {   
            '0','1','2','3','4','5','6','7','8','9',   
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
          };
        private static char[] constantChar =   
          {   
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
          };
        private static string[] arrString = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private static int[] pyValue = new int[] { 
    -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, 
    -20230, -20051, -20036, -20032, -20026, -20002, -19990, -19986, -19982,
    -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, 
    -19741, -19739, -19728, -19725, -19715, -19540, -19531, -19525, -19515, 
    -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, 
    -19263, -19261, -19249, -19243, -19242, -19238, -19235, -19227, -19224, 
    -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977,
    -18961, -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, 
    -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501, -18490,
    -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220,
    -18211, -18201, -18184, -18183, -18181, -18012, -17997, -17988, -17970, 
    -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, 
    -17733, -17730, -17721, -17703, -17701, -17697, -17692, -17683, -17676,
    -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, 
    -17185, -16983, -16970, -16942, -16915, -16733, -16708, -16706, -16689, 
    -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448, 
    -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, 
    -16393, -16220, -16216, -16212, -16205, -16202, -16187, -16180, -16171,
    -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, 
    -15903, -15889, -15878, -15707, -15701, -15681, -15667, -15661, -15659, 
    -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419,
    -15416, -15408, -15394, -15385, -15377, -15375, -15369, -15363, -15362, 
    -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, 
    -15141, -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, 
    -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922, -14921,
    -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, 
    -14678, -14674, -14670, -14668, -14663, -14654, -14645, -14630, -14594,
    -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345,
    -14170, -14159, -14151, -14149, -14145, -14140, -14137, -14135, -14125, 
    -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, 
    -14087, -14083, -13917, -13914, -13910, -13907, -13906, -13905, -13896, 
    -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601,
    -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, 
    -13359, -13356, -13343, -13340, -13329, -13326, -13318, -13147, -13138, 
    -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, 
    -12888, -12875, -12871, -12860, -12858, -12852, -12849, -12838, -12831,
    -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359,
    -12346, -12320, -12300, -12120, -12099, -12089, -12074, -12067, -12058,
    -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, 
    -11536, -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067,
    -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019, -11018,
    -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587,
    -10544, -10533, -10519, -10331, -10329, -10328, -10322, -10315, -10309, 
    -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254 
    };
        private static string[] pyName = new string[]{ 
     "A", "Ai", "An", "Ang", "Ao", "Ba", "Bai", "Ban", "Bang", "Bao", "Bei", 
     "Ben", "Beng", "Bi", "Bian", "Biao", "Bie", "Bin", "Bing", "Bo", "Bu",
     "Ba", "Cai", "Can", "Cang", "Cao", "Ce", "Ceng", "Cha", "Chai", "Chan",
     "Chang", "Chao", "Che", "Chen", "Cheng", "Chi", "Chong", "Chou", "Chu",
     "Chuai", "Chuan", "Chuang", "Chui", "Chun", "Chuo", "Ci", "Cong", "Cou",
     "Cu", "Cuan", "Cui", "Cun", "Cuo", "Da", "Dai", "Dan", "Dang", "Dao", "De", 
     "Deng", "Di", "Dian", "Diao", "Die", "Ding", "Diu", "Dong", "Dou", "Du", 
     "Duan", "Dui", "Dun", "Duo", "E", "En", "Er", "Fa", "Fan", "Fang", "Fei", 
     "Fen", "Feng", "Fo", "Fou", "Fu", "Ga", "Gai", "Gan", "Gang", "Gao", "Ge", 
     "Gei", "Gen", "Geng", "Gong", "Gou", "Gu", "Gua", "Guai", "Guan", "Guang", 
     "Gui", "Gun", "Guo", "Ha", "Hai", "Han", "Hang", "Hao", "He", "Hei", "Hen", 
     "Heng", "Hong", "Hou", "Hu", "Hua", "Huai", "Huan", "Huang", "Hui", "Hun",
     "Huo", "Ji", "Jia", "Jian", "Jiang", "Jiao", "Jie", "Jin", "Jing", "Jiong", 
     "Jiu", "Ju", "Juan", "Jue", "Jun", "Ka", "Kai", "Kan", "Kang", "Kao", "Ke",
     "Ken", "Keng", "Kong", "Kou", "Ku", "Kua", "Kuai", "Kuan", "Kuang", "Kui", 
     "Kun", "Kuo", "La", "Lai", "Lan", "Lang", "Lao", "Le", "Lei", "Leng", "Li",
     "Lia", "Lian", "Liang", "Liao", "Lie", "Lin", "Ling", "Liu", "Long", "Lou", 
     "Lu", "Lv", "Luan", "Lue", "Lun", "Luo", "Ma", "Mai", "Man", "Mang", "Mao",
     "Me", "Mei", "Men", "Meng", "Mi", "Mian", "Miao", "Mie", "Min", "Ming", "Miu",
     "Mo", "Mou", "Mu", "Na", "Nai", "Nan", "Nang", "Nao", "Ne", "Nei", "Nen", 
     "Neng", "Ni", "Nian", "Niang", "Niao", "Nie", "Nin", "Ning", "Niu", "Nong", 
     "Nu", "Nv", "Nuan", "Nue", "Nuo", "O", "Ou", "Pa", "Pai", "Pan", "Pang",
     "Pao", "Pei", "Pen", "Peng", "Pi", "Pian", "Piao", "Pie", "Pin", "Ping", 
     "Po", "Pu", "Qi", "Qia", "Qian", "Qiang", "Qiao", "Qie", "Qin", "Qing",
     "Qiong", "Qiu", "Qu", "Quan", "Que", "Qun", "Ran", "Rang", "Rao", "Re",
     "Ren", "Reng", "Ri", "Rong", "Rou", "Ru", "Ruan", "Rui", "Run", "Ruo", 
     "Sa", "Sai", "San", "Sang", "Sao", "Se", "Sen", "Seng", "Sha", "Shai", 
     "Shan", "Shang", "Shao", "She", "Shen", "Sheng", "Shi", "Shou", "Shu", 
     "Shua", "Shuai", "Shuan", "Shuang", "Shui", "Shun", "Shuo", "Si", "Song", 
     "Sou", "Su", "Suan", "Sui", "Sun", "Suo", "Ta", "Tai", "Tan", "Tang", 
     "Tao", "Te", "Teng", "Ti", "Tian", "Tiao", "Tie", "Ting", "Tong", "Tou",
     "Tu", "Tuan", "Tui", "Tun", "Tuo", "Wa", "Wai", "Wan", "Wang", "Wei",
     "Wen", "Weng", "Wo", "Wu", "Xi", "Xia", "Xian", "Xiang", "Xiao", "Xie",
     "Xin", "Xing", "Xiong", "Xiu", "Xu", "Xuan", "Xue", "Xun", "Ya", "Yan",
     "Yang", "Yao", "Ye", "Yi", "Yin", "Ying", "Yo", "Yong", "You", "Yu", 
     "Yuan", "Yue", "Yun", "Za", "Zai", "Zan", "Zang", "Zao", "Ze", "Zei",
     "Zen", "Zeng", "Zha", "Zhai", "Zhan", "Zhang", "Zhao", "Zhe", "Zhen", 
     "Zheng", "Zhi", "Zhong", "Zhou", "Zhu", "Zhua", "Zhuai", "Zhuan", 
     "Zhuang", "Zhui", "Zhun", "Zhuo", "Zi", "Zong", "Zou", "Zu", "Zuan",
     "Zui", "Zun", "Zuo"};
        #endregion

        #region HTML处理
        /// <summary>
        /// 删除所有HTML标记
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring))
            {
                return "";
            }
            //删除脚本    
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML    
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = Htmlstring.Replace("'", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 替换HTML标签为html实体形式
        /// </summary>
        public static string ReplaceHTML(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Trim();
                str = Microsoft.Security.Application.Encoder.XmlEncode(str);
            }
            return str;
        }
        #endregion

        #region 截取指定条度的字符串
        /// <summary>
        /// 截取指定条度的字符串
        /// </summary>
        /// <param name="str">需要被截选的字符串</param>
        /// <param name="length">截选长度</param>
        /// <returns></returns>
        public static string LessString(string str, int length)
        {
            string value = null;
            if (str.Length > length)
            {
                value = str.Substring(0, length);
                value += "...";
            }
            else
            {
                value = str;
            }
            return value;
        }
        #endregion

        #region 按指定字符截断并返回指定长度的字符
        /// <summary>
        /// 按指定字符截断并返回指定长度的字符
        /// </summary>
        /// <param name="str">源字符</param>
        /// <param name="length">返回长度</param>
        /// <param name="c">截断字符</param>
        /// <returns></returns>
        public static string LessString(string str, int length, char c)
        {
            string value = null;
            int chr = str.IndexOf(c);
            if (str.Length > length)
            {
                if (chr >= 0)
                {
                    value = str.Substring(0, chr);
                    if (value.Length > length)
                    {
                        value = StringUtil.LessString(str, length);
                    }
                }
                else
                {
                    value = StringUtil.LessString(str, length);
                }

            }
            else
            {
                value = str + "...";
            }
            return value;
        }
        #endregion

        #region 截断并返回指定长度的字符(中英混合)
        /// <summary>
        /// 截断并返回指定长度的字符(中英混合)
        /// 匹配中文字符的正则表达式： [\u4e00-\u9fa5]
        /// 匹配双字节字符(包括汉字在内)：[^\x00-\xff]
        /// 应用：计算字符串的长度(一个双字节字符长度计2，ASCII字符计1)
        /// String.prototype.len=function(){return this.replace([^\x00-\xff]/g,"aa").length;}
        /// 匹配空行的正则表达式：\n[\s| ]*\r
        /// 匹配HTML标记的正则表达式：/<(.*)>.*<\/\1>|<(.*) \/>/ 
        /// 匹配首尾空格的正则表达式：(^\s*)|(\s*$)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetSubString(string str, int length)
        {
            string temp = str;
            int j = 0;
            int k = 0;
            ASCIIEncoding ascii = new ASCIIEncoding();
            for (int i = 0; i < temp.Length; i++)
            {
                //if (ascii.GetByteCount(temp.Substring(i, 1))==2)
                if (Regex.IsMatch(temp.Substring(i, 1), @"[^\x00-\xff]+"))
                {
                    j += 2;
                }
                else
                {
                    j += 1;
                }
                if (j <= length)
                {
                    k += 1;
                }
                if (j >= length)
                {
                    return temp.Substring(0, k);
                }
            }
            return temp;
        }
        #endregion

        #region 计算字符串的长度(一个双字节字符长度计2)
        /// <summary>
        /// 计算字符串的长度(一个双字节字符长度计2)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetStringLength(string str)
        {
            string temp =NoHTML(str);
            int j = 0;
            ASCIIEncoding ascii = new ASCIIEncoding();
            for (int i = 0; i < temp.Length; i++)
            {
                if (Regex.IsMatch(temp.Substring(i, 1), @"[^\x00-\xff]+"))
                {
                    j += 2;
                }
                else
                {
                    j += 1;
                }
            }
            return j;
        }
        #endregion

        #region 截取指定长度的字符串，一个汉字算两个字符
        /// <summary>
        /// 截取指定长度的字符串，一个汉字算两个字符
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="length">长度</param>
        /// <param name="s">需要替代的字符串</param>
        /// <returns></returns>
        public static string GetSubString(string str, int length, string s)
        {
            string temp =NoHTML(str);
            if (!String.IsNullOrEmpty(temp))
            {
                int j = 0;
                int k = 0;
                ASCIIEncoding ascii = new ASCIIEncoding();
                for (int i = 0; i < temp.Length; i++)
                {
                    //if (ascii.GetByteCount(temp.Substring(i, 1))==2)
                    if (Regex.IsMatch(temp.Substring(i, 1), @"[^\x00-\xff]+"))
                    {
                        j += 2;
                    }
                    else
                    {
                        j += 1;
                    }
                    if (j <= length)
                    {
                        k += 1;
                    }
                    if (j >= length)
                    {
                        return temp.Substring(0, k) + s;
                    }
                }
            }
            return temp;
        }
        #endregion

        #region 随机数生成相关
        /// <summary>
        /// 随机器生成数字和字母组合,区分大小写
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
        /// <summary>
        /// 随机生成只有字符的组合，区分大小写
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomToChars(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(52);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constantChar[rd.Next(52)]);
            }
            return newRandom.ToString();
        }
        /// <summary>
        /// 随机生成只有字符的组合，不区分大小写
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string getRand(int len)
        {

            Random rnd = new Random();
            string strTemp = "";
            int rndNum;
            for (int i = 0; i < len; i++)
            {
                rndNum = rnd.Next(35);
                //得0~9的随机数
                strTemp += arrString[rndNum];
            }
            return strTemp;
        }
        /// <summary>
        /// 根据GUID生成唯一字符标示
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string getRndString(int len)
        {
            return System.Guid.NewGuid().ToString().Substring(0, len);
        }
        #endregion

        #region 编码相关
        /// <summary>
        /// 对js的escape进行解码
        /// 解码 说明：本方法保证不论参数s是否经过escape()编码，均能得到正确的“解码”结果
        /// </summary>
        /// <param name="s">解码字符串</param>
        /// <returns></returns>
        public static String unescape(String s)
        {
            StringBuilder sbuf = new StringBuilder();
            int i = 0;
            int len = s.Length;
            while (i < len)
            {
                int ch = s.ToCharArray()[i];
                if ('A' <= ch && ch <= 'Z')
                { // 'A'..'Z' : as it was
                    sbuf.Append((char)ch);
                }
                else if ('a' <= ch && ch <= 'z')
                { // 'a'..'z' : as it was
                    sbuf.Append((char)ch);
                }
                else if ('0' <= ch && ch <= '9')
                { // '0'..'9' : as it was
                    sbuf.Append((char)ch);
                }
                else if (ch == '-' || ch == '_' // unreserved : as it was
              || ch == '.' || ch == '!' || ch == '~' || ch == '*'
              || ch == '\'' || ch == '(' || ch == ')')
                {
                    sbuf.Append((char)ch);
                }
                else if (ch == '%')
                {
                    int cint = 0;
                    if ('u' != s.ToCharArray()[i + 1])
                    { // %XX : map to ascii(XX)
                        cint = (cint << 4) | val[s.ToCharArray()[i + 1]];
                        cint = (cint << 4) | val[s.ToCharArray()[i + 2]];
                        i += 2;
                    }
                    else
                    { // %uXXXX : map to unicode(XXXX)
                        cint = (cint << 4) | val[s.ToCharArray()[i + 2]];
                        cint = (cint << 4) | val[s.ToCharArray()[i + 3]];
                        cint = (cint << 4) | val[s.ToCharArray()[i + 4]];
                        cint = (cint << 4) | val[s.ToCharArray()[i + 5]];
                        i += 5;
                    }
                    sbuf.Append((char)cint);
                }
                else
                { // 对应的字符未经过编码
                    sbuf.Append((char)ch);
                }
                i++;
            }
            return sbuf.ToString();
        }

        #region Base64编码相关

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Base64Code(string Message)
        {
            byte[] bytes = Encoding.Default.GetBytes(Message);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Base64Decode(string Message)
        {
            byte[] bytes = Convert.FromBase64String(Message);
            return Encoding.Default.GetString(bytes);
        }
        #endregion

        #region Unicode编码相关
        private static Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
        private static Regex reUnicodeChar = new Regex(@"[^\u0000-\u00ff]", RegexOptions.Compiled);
        /// <summary>
        /// Unicode解码
        /// </summary>
        public static string UnicodeDecode(string s)
        {
            return reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                {
                    return "" + (char)c;
                }
                return m.Value;
            });
        }

        /// <summary>
        /// Unicode编码
        /// </summary>
        public static string UnicodeEncode(string s)
        {
            return reUnicodeChar.Replace(s, m => string.Format(@"\u{0:x4}", (short)m.Value[0]));
        }
        #endregion

        #endregion

        #region 日期相关
        /// <summary>
        /// 返回星期几，如："星期一"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetWeek(DateTime date)
        {
            string str = string.Empty;
            switch (date.DayOfWeek)
            { 
                case DayOfWeek.Monday:
                    str = "一";
                    break;
                case DayOfWeek.Tuesday:
                    str = "二";
                    break;
                case DayOfWeek.Wednesday:
                    str = "三";
                    break;
                case DayOfWeek.Thursday:
                    str = "四";
                    break;
                case DayOfWeek.Friday:
                    str="五";
                    break;
                case DayOfWeek.Saturday:
                    str = "六";
                    break;
                default:
                    str="日";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 获取日期区间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String GetDateSpan(DateTime date)
        {
            DateTime dt = (DateTime)date;
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToShortDateString();
            }
            else if (span.TotalDays > 30)
            {
                return "1个月前";
            }
            else if (span.TotalDays > 14)
            {
                return "2周前";
            }
            else if (span.TotalDays > 7)
            {
                return "1周前";
            }
            else if (span.TotalDays > 1)
            {
                return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
            }
            else if (span.TotalHours > 1)
            {
                return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
            }
            else if (span.TotalMinutes > 1)
            {
                return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
            }
            else if (span.TotalSeconds >= 1)
            {
                return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
            }
            else
            {
                return "1秒前";
            }
        }

        public static DateTime AddWorkDays(DateTime dt1, int day)
        {
            DateTime tempdt = dt1;
            int i = 0;
            while (i < day)
            {
                tempdt = tempdt.Date.AddDays(1);
                if (tempdt.DayOfWeek != System.DayOfWeek.Saturday && tempdt.DayOfWeek != System.DayOfWeek.Sunday)
                {
                    i++;
                }
            }
            return tempdt;
        }

        /// <summary> 
        /// 时间差 
        /// </summary> 
        /// <param name="starttime">开始时间</param> 
        /// <param name="endtime">结束时间</param> 
        /// <returns>0}时{1}分{2}秒{3}毫秒</returns> 
        public static string GetTimeSpan(DateTime starttime, DateTime endtime)
        {
            TimeSpan ts = endtime - starttime;
            return string.Format("{0}时{1}分{2}秒{3}毫秒", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        /// <summary>
        /// 获取某一日期是该年中的第几周
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns> 该日期在该年中的周数 </returns>
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
        /// <summary>
        /// 获取某一年有多少周
        /// </summary>
        /// <param name="year">年份 </param>
        /// <returns>该年周数</returns>
        public static int GetWeekAmount(int year)
        {
            DateTime end = new DateTime(year, 12, 31);   // 该年最后一天 
            System.Globalization.GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(end, CalendarWeekRule.FirstDay, DayOfWeek.Monday);   // 该年星期数 
        }
        /// <summary>
        /// 返回月份list(1到12)
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetMonthLst()
        {
            List<ListItem> lst = new List<ListItem>();
            for (int i = 1; i <= 12; i++)
            {
                lst.Add(new ListItem(i.ToString(), i.ToString()));
            }
            return lst;
        }
        /// <summary>
        /// 返回指定年份的前count年的LIST
        /// </summary>
        /// <param name="count">前几年</param>
        /// <returns></returns>
        public static List<ListItem> GetYear(DateTime dt, int count)
        {
            List<ListItem> lst = new List<ListItem>();
            for (int i = 0; i < count; i++)
            {
                lst.Add(new ListItem((dt.Year - i).ToString(), (dt.Year - i).ToString()));
            }
            return lst;
        }
        #endregion

        #region 比较
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="Lp"></param>
        /// <param name="Hp"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        private static bool In(int Lp, int Hp, int Value)
        {
            return ((Value <= Hp) && (Value >= Lp));
        }
        #endregion

        #region 字符串空转换
        /// <summary>
        /// 字符串空转换
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string CheckNullToEmpty(object inputString)
        {
            if (inputString == null)
                return string.Empty;
            else
            {
                string localString = (string)inputString.ToString();
                if (localString.Length == 0) return string.Empty;
                return localString;
            }
        }
        #endregion

        #region 加密与解密
        /// <summary>
        /// 加密方法 
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey">sKey输入密码的时候，必须使用英文字符，区分大小写，且字符数量是8个，不能多也不能少，否则出错</param>
        /// <returns></returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            //原来使用的UTF8编码，我改成Unicode编码了，不行  
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// 解密方法 
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey">sKey输入密码的时候，必须使用英文字符，区分大小写，且字符数量是8个，不能多也不能少，否则出错</param>
        /// <returns></returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// 给字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string str_md5(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            else
                return "";
        }
        #endregion

        #region 四舍五入
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="value">源数值</param>
        /// <param name="digit">保留小数点位数</param>
        /// <returns>double</returns>
        public static double C1Round(double value, int digit)
        {
            double vt = Math.Pow(10, digit);
            double vx = value * vt;
            vx += 0.5;
            return (Math.Floor(vx) / vt);
        }
        #endregion

        #region 返回字符串数组
        /// <summary>
        /// 返回字符串数组
        /// </summary>
        /// <param name="stemp"></param>
        /// <returns></returns>
        public static string[] GetTagID(string stemp)
        {
            string[] temp = null;
            try
            {
                if (stemp != "")
                {
                    temp = stemp.Split(',');
                }
            }
            catch
            {

            }
            finally
            {

            }
            return temp;
        }
        #endregion

        #region 判断输入是否数字
        /// <summary>
        /// 判断输入是否数字
        /// </summary>
        /// <param name="num">要判断的字符串</param>
        /// <returns></returns>
        static public bool VldInt(string num)
        {
            #region
            try
            {
                Convert.ToInt32(num);
                return true;
            }
            catch { return false; }
            #endregion
        }
        #endregion

        #region 返回文本编辑器替换后的字符串
        /// <summary>
        /// 返回文本编辑器替换后的字符串
        /// </summary>
        /// <param name="str">要替换的字符串</param>
        /// <returns></returns>
        public static string GetHtmlEditReplace(string str)
        {
            #region
            return str.Replace("'", "''").Replace("&nbsp;", " ").Replace(",", "，").Replace("%", "％").Replace("script", "").Replace(".js", "");
            #endregion
        }
        #endregion

        #region 汉字操作
        /// <summary>
        /// 获取汉字第一个拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public string getSpells(string input)
        {
            #region
            int len = input.Length;
            string reVal = "";
            for (int i = 0; i < len; i++)
            {
                reVal += getSpell(input.Substring(i, 1));
            }
            return reVal;
            #endregion
        }

        static public string getSpell(string cn)
        {
            #region
            byte[] arrCN = Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
            #endregion
        }
        #endregion

        #region 全半角转换
        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="BJstr"></param>
        /// <returns></returns>
        static public string GetQuanJiao(string BJstr)
        {
            #region
            char[] c = BJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 0)
                    {
                        b[0] = (byte)(b[0] - 32);
                        b[1] = 255;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }

            string strNew = new string(c);
            return strNew;

            #endregion
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="QJstr"></param>
        /// <returns></returns>
        static public string GetBanJiao(string QJstr)
        {
            #region
            char[] c = QJstr.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            string strNew = new string(c);
            return strNew;
            #endregion
        }
        #endregion

        #region 对中文字符进行编码（用于文件导出时的文件名乱码问题）
        /// <summary>
        /// 为字符串中的非英文字符编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public string ToHexString(string s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < chars.Length; index++)
            {
                bool needToEncode = NeedToEncode(chars[index]);
                if (needToEncode)
                {
                    string encodedString = ToHexString(chars[index]);
                    builder.Append(encodedString);
                }
                else
                {
                    builder.Append(chars[index]);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        ///指定 一个字符是否应该被编码
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
         static public bool NeedToEncode(char chr)
        {
            string reservedChars = "$-_.+!*'(),@=&";

            if (chr > 127)
                return true;
            if (char.IsLetterOrDigit(chr) || reservedChars.IndexOf(chr) >= 0)
                return false;

            return true;
        }

        /// <summary>
        /// 为非英文字符串编码
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
         static public string ToHexString(char chr)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] encodedBytes = utf8.GetBytes(chr.ToString());
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < encodedBytes.Length; index++)
            {
                builder.AppendFormat("%{0}", Convert.ToString(encodedBytes[index], 16));
            }
            return builder.ToString();
        }

        #endregion

        #region 字符串引号处理
        /// <summary>
        /// 将指定字符串中的英文引号替换为中文引号（中文引号没有考虑正反）
        /// </summary>
         public static string ReplaceQuoteENToCN(string str)
         {
             if (!string.IsNullOrEmpty(str))
             {
                 str = str.Replace("'", "‘").Replace("\"", "“");
             }
             return str;
         }

         /// <summary>
         /// 将指定字符串中的英文引号替换为html引号实体
         /// </summary>
         public static string ReplaceQuoteToHTML(string str)
         {
             if (!string.IsNullOrEmpty(str))
             {
                 str = str.Replace("\"", "&quot;").Replace("'", "&apos;");
             }
             return str;
         }

         /// <summary>
         /// 移除指定字符串中的英文引号
         /// </summary>
         public static string RemoveQuote(string str)
         {
             if (!string.IsNullOrEmpty(str))
             {
                 str = str.Replace("'", "").Replace("\"", "");
             }
             return str;
         }
        #endregion
    }
}