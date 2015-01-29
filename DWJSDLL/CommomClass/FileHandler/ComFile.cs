using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace CommonClass.FileHandler
{
    /// <summary>
    ///文件操作公共类
    /// </summary>
    public class ComFile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ComFile()
        {
        }
        #region 图片相关
        #region 指定坐标和宽高裁剪图片
        /// <summary>
        /// 指定坐标和宽高裁剪图片
        /// </summary>
        /// <param name="img">原图路径</param>
        /// <param name="width">指定的宽度</param>
        /// <param name="height">指定的高度</param>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <returns>System.Drawing.Image,再调用save就行了,注意：调用完后需要Dispose</returns>
        public System.Drawing.Image Crop(string img, int width, int height, int x, int y)
        {
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(img);
                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bmp.SetResolution(80, 60);
                Graphics gfx = Graphics.FromImage(bmp);
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gfx.DrawImage(image, new Rectangle(0, 0, width, height), x, y, width, height, GraphicsUnit.Pixel);
                // Dispose to free up resources
                image.Dispose();
                //bmp.Dispose();
                gfx.Dispose();
                return bmp;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 生成缩略图
        ///<summary>
        ///生成缩略图
        ///</summary>
        ///<param name="originalImagePath">源图路径（物理路径）</param>
        ///<param name="thumbnailPath">缩略图路径（物理路径）</param>
        ///<param name="width">缩略图宽度</param>
        ///<param name="height">缩略图高度</param>
        ///<param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            if (null == originalImage)
            {
                return;
            }
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        #region 生成验证码的随机数
        /// <summary>
        /// 生成验证码的随机数
        /// </summary>
        /// <returns></returns>
        public static string GenerateCheckCode()
        {
            #region
            int number;
            char code;
            string checkCode = String.Empty;
            System.Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                checkCode += code.ToString();
            }
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CheckCode", checkCode));
            return checkCode;
            #endregion
        }
        #endregion

        #region 生成验证码图片
        /// <summary>
        /// 生成验证码图片
        /// </summary>
        public void CreateCheckCodeImage()
        {
            #region
            string checkCode =GenerateCheckCode();
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 2, 2);
                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
            #endregion
        }
        #endregion
        #endregion

        #region 取得文件物理路径
        /// <summary>
        /// 取得文件物理路径
        /// </summary>
        /// <param name="path">文件虚拟路径</param>
        /// <returns>文件物理路径</returns>
        public static string MapPath(string path)
        {
            if (path[1].Equals(':'))
                return path;
            else
                return System.Web.HttpContext.Current.Server.MapPath(path);
        }
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件(删除成功返回TRUE,删除失败返回FALSE)
        /// </summary>
        /// <param name="FilePath">文件路径,包括文件名(可用相对路径)</param>
        /// <returns>删除成功返回TRUE,删除失败返回FALSE</returns>
        public static bool DeleteFile(string FilePath)
        {
            try
            {
                if (System.IO.File.Exists(MapPath(FilePath)))
                {
                    System.IO.File.Delete(MapPath(FilePath));    //删除文件
                    if (System.IO.File.Exists(MapPath(FilePath))) //再次访问，验证文件是否依然存在，若存在则标示删除失败
                        return false;
                    return true;
                }
                else    //文件原本不存在，按文件成功删除处理
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 取得文件扩展名
        /// <summary>
        /// 取得文件扩展名(不包含小圆点的)
        /// </summary>
        /// <param name="fileName">文件完整路径或文件名</param>
        /// <returns>文件扩展名(不包含小圆点的)或""</returns>
        public static string GetExtName(string fileName)
        {
            if (fileName == null || fileName == "") return "";
            return fileName.Substring(fileName.LastIndexOf('.') + 1);
        }
        #endregion

        #region 复制文件
        /// <summary>
        /// 复制文件(若已存在目标文件则覆盖)
        /// </summary>
        /// <param name="srcPath">源文件</param>
        /// <param name="dstPath">目标文件</param>
        /// <returns>复制成功返回TRUE,复制失败返回FALSE</returns>
        public static bool CopyFile(string srcPath, string dstPath)
        {
            return CopyFile(srcPath, dstPath, true);
        }
        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="srcPath">源文件</param>
        /// <param name="dstPath">目标文件</param>
        /// <param name="overwrite">是否覆盖目标文件</param>
        /// <returns>复制成功返回TRUE,复制失败返回FALSE</returns>
        public static bool CopyFile(string srcPath, string dstPath, bool overwrite)
        {
            File.Copy(MapPath(srcPath), MapPath(dstPath), overwrite);
            return File.Exists(MapPath(dstPath));
        }
        #endregion

        #region 取得文件夹中的文件列表
        /// <summary>
        /// 取得文件夹中的文件列表
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>字符串数组(存储了一个或多个文件名)</returns>
        public static string[] GetFolderFiles(string path)
        {
            return System.IO.Directory.GetFiles(MapPath(path));
        }
        #endregion

        #region 文件下载
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="path">文件链接（物理路径）</param>
        /// <param name="realName">要显示下载时的文件名</param>
        /// <param name="isDel">true:输出后删除此文件</param>
        public static void DownLoadFile(string path, string realName, bool isDel)
        {
            realName = string.IsNullOrEmpty(realName) ? "任务详情" : realName;
            FileInfo info = new FileInfo(path);
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = false;
            Response.ContentType = "application/octet-stream";
            string exp = HttpContext.Current.Request.UserAgent.ToLower();
            if (exp.IndexOf("msie") > -1)
            {
                //当客户端使用IE时，对其进行编码；We should encode the filename when our visitors use IE
                //使用 ToHexString 代替传统的 UrlEncode()；We use "ToHexString" replaced "context.Server.UrlEncode(fileName)"
                realName = CommonClass.StringHander.StringUtil.ToHexString(realName);
            }
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + realName.Replace("+", "_").Replace(" ", ""));
            Response.AppendHeader("Content-Length", info.Length.ToString());
            Response.WriteFile(path);
            if (isDel)
            {
                DeleteFile(path);
            }
            Response.Flush();
            Response.End();
        }
        #endregion

        #region 目录相关
        /// <summary>
        /// 返回目录路径，若该目录不存在，则创建该目录
        /// </summary>  
        /// <param name="DirectoryPath">存放文件的物理路径。</param>  
        /// <returns>返回存放文件的目录。</returns>  
        public static string GetSaveDirectory(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath)) // 判断当前目录是否存在。  
            {
                Directory.CreateDirectory(DirectoryPath); // 建立上传文件存放目录。  
            }
            return DirectoryPath;
        }
        #endregion

        #region 文件属性相关
        /// <summary>
        /// 返回文件大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static long GetFileSize(string filePath)
        {
            long s = 0;
            if (System.IO.File.Exists(MapPath(filePath)))
            {
                FileInfo fi = new FileInfo(MapPath(filePath));
                s = fi.Length;
            }
            return s;
        }
        #endregion
    }
}