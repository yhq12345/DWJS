using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using com.mxgraph;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace CommonClass.Control.MxGraph
{
    /// <summary>
    /// MxGraph操作类
    /// </summary>
    public class MxGraphHelper
    {
        /// <summary>
        /// 根据view形式的xml生成图片
        /// </summary>
        /// <param name="xml">view形式的xml</param>
        /// <returns>image对象</returns>
        public static Image GetImage(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new Exception("要生成图片的xml信息不能为空！");
            }
            XmlTextReader xmlReader = new XmlTextReader(new StringReader(xml));
            mxGraphViewImageReader viewReader = new mxGraphViewImageReader(xmlReader, Color.White, 4, true, true);
            return mxGraphViewImageReader.Convert(viewReader);
        }

        /// <summary>
        /// 导出mxGraph为图片
        /// </summary>
        /// <param name="xml">mxGraph的model的view形式的xml</param>
        /// <param name="filename">导出后的文件名（包含扩展名）</param>
        public static void ExportImage(string xml,string filename)
        {
            Image image = GetImage(xml);
            if (null == image)
            {
                throw new Exception(string.Format("XML：【{0}】所生成的图片为null，生成失败！",xml));
            }
            HttpContext context = HttpContext.Current;
            context.Response.ContentType = "image/jpeg";
            context.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, ImageFormat.Jpeg);
            memStream.WriteTo(context.Response.OutputStream);  
        }
    }
}
