using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Web;

namespace CommonClass.FileHandler
{
    /// <summary>
    /// 图片上传类
    ///by:xucongli  @2012  
    ///http://blog.csdn.net/luoyeyu1989
    /// </summary>
   public class UploadImg
    {
        private string OFullName;// 保存时的完整路径.原图
        private string TFullName;// 保存时的完整路径.缩略图
        private string TFileName;// 保存时的图片名称.缩略图
        /// <summary>
        /// 信息
        /// </summary>
        private static string _MSG;
        public static string MSG
        {
            get { return _MSG; }
            set { _MSG = value; }
        }
        /// <summary>
        /// 缩略图前缀
        /// </summary>
        private string _tprefix = "small_";
        public string TPrefix
        {
            get { return _tprefix; }
            set { _tprefix = value; }
        }
        /// <summary>
        /// 原图最大宽度
        /// </summary>
        private int _limitwidth = 3072;
        public int LimitWidth
        {
            get { return _limitwidth; }
            set { _limitwidth = value; }
        }
        /// <summary>
        /// 原图最大高度
        /// </summary>
        private int _limitheight = 2304;
        public int LimitHeight
        {
            get { return _limitheight; }
            set { _limitheight = value; }
        }
        /// <summary>
        /// 缩略图最大宽度
        /// </summary>
        private int _twidth = 100;
        public int TWidth
        {
            get { return _twidth; }
            set { _twidth = value; }
        }
        /// <summary>
        /// 缩略图最大高度
        /// </summary>
        private int _theight = 100;
        public int THeight
        {
            get { return _theight; }
            set { _theight = value; }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        private int _size = 3000000;
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        /// <summary>
        /// 是否成比例
        /// </summary>
        private bool _israte;
        public bool IsRate
        {
            get { return _israte; }
            set { _israte = value; }
        }
        /// <summary>
        /// 是否生成缩略图
        /// </summary>
        private bool _iscreate;
        public bool IsCreate
        {
            get { return _iscreate; }
            set { _iscreate = value; }
        }
        /// <summary>
        /// 存放图片的文件夹名称
        /// </summary>
        private string _path = "Upload";
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        /// <summary>
        /// 原图名称
        /// </summary>
        private static string _OFileName;
        public static string OFileName
        {
            get { return _OFileName; }
            set { _OFileName = value; }
        }
        /// <summary>
        /// 图片上传(默认:"等比压缩,限定上传尺寸2048*1536,缩略图尺寸100*100,限定上传大小1MB,存放在根目录upload中")
        /// </summary>
        /// <param name="UploadFile">文件上传控件</param>
        /// <returns>返回是否成功保存图片</returns>
        public bool UpLoadIMG(FileUpload UploadFile)
        {
            if (UploadFile.HasFile)//检查是否已经选择文件
            {
                string filename = UploadFile.FileName.ToLower();
                int i = filename.LastIndexOf(".");
                filename = filename.Substring(i, filename.Length - i);
                if (!(filename == ".jpg" || filename == ".jpeg" || filename == ".gif" || filename == ".png" || filename == ".bmp"))
                {
                    MSG = "文件格式不正确，只能为jpeg,jpg,gif,png或bmp !";
                    return false;
                }//检查上传文件的格式是否有效
                if (UploadFile.PostedFile.ContentLength == 0 || UploadFile.PostedFile.ContentLength >= Size)
                {
                    MSG = string.Format("图片的大小应小于 {0} M!", Math.Round(_size / 1024.0 / 1024.0, 2));
                    return false;
                }//检查图片文件的大小
                //生成原图 
                Stream oStream = UploadFile.PostedFile.InputStream;
                System.Drawing.Image oImage = System.Drawing.Image.FromStream(oStream);
                int owidth = oImage.Width; //原图宽度 
                int oheight = oImage.Height; //原图高度
                if (owidth > LimitWidth || oheight > LimitHeight)
                {
                    MSG = string.Format("图片尺寸应小于{0}*{1}", _limitwidth, this._limitheight);
                    return false;
                }//检查是否超出规定尺寸
                if (IsRate)
                {
                    //按比例计算出缩略图的宽度和高度 
                    if (owidth >= oheight)
                    {
                        THeight = (int)Math.Floor(Convert.ToDouble(oheight) * (Convert.ToDouble(TWidth) / Convert.ToDouble(owidth)));//等比设定高度
                    }
                    else
                    {
                        TWidth = (int)Math.Floor(Convert.ToDouble(owidth) * (Convert.ToDouble(THeight) / Convert.ToDouble(oheight)));//等比设定宽度
                    }
                }
                //生成缩略原图 
                Bitmap tImage = new Bitmap(TWidth, THeight);
                Graphics g = Graphics.FromImage(tImage);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; //设置高质量插值法 
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//设置高质量,低速度呈现平滑程度 
                g.Clear(Color.Transparent); //清空画布并以透明背景色填充 
                g.DrawImage(oImage, new Rectangle(0, 0, TWidth, THeight), new Rectangle(0, 0, owidth, oheight), GraphicsUnit.Pixel);
                Random orandom = new Random();
                string oStringRandom = orandom.Next(999999999).ToString();//生成9位随机数字
                //格式化日期作为文件名
                string oStringTime = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
                OFileName = oStringTime + oStringRandom + filename;
                TFileName = TPrefix + oStringTime + oStringRandom + filename;
                string SavePath = HttpContext.Current.Server.MapPath("~") + "\\" + Path + "\\";
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);//在根目录下建立文件夹
                }
                OFullName = SavePath + OFileName;
                TFullName = SavePath + TFileName;
                //开始保存图片至服务器
                try
                {
                    switch (filename)
                    {
                        case ".jpeg":
                        case ".jpg":
                            {
                                oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                if (IsCreate) tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            }
                        case ".gif":
                            {
                                oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Gif);
                                if (IsCreate) tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            }
                        case ".png":
                            {
                                oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Png);
                                if (IsCreate) tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            }
                        case ".bmp":
                            {
                                oImage.Save(OFullName, System.Drawing.Imaging.ImageFormat.Bmp);
                                if (IsCreate) tImage.Save(TFullName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            }
                    }
                    MSG = "图片上传成功!";
                    //保存路径+完整文件名
                    string _SavePath = "/" + Path + "/";
                    OFullName = _SavePath + OFileName;
                    TFullName = _SavePath + TFileName;
                    return true;
                }
                catch (Exception ex)
                {
                    MSG = ex.Message;
                    return false;
                }
                finally
                {
                    //释放资源 
                    oImage.Dispose();
                    g.Dispose();
                    tImage.Dispose();
                }
            }
            else
            {
                MSG = "请先选择需要上传的图片!";
                return false;
            }
        }
    }
}