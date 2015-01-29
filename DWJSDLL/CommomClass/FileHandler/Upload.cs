using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
namespace CommonClass.FileHandler
{
        #region 附：修改上传大小的配置
        /*  
             需要修改的是  
             在 CONFIG目录里，  
             找到文件maxRequestLength="4096"  
             将值修改大一些，例如：102400  
             这个参数的单位应该是KB的  
             以上方法是修改全局的，如果公需要修改一个项目，那么是修改项目里的Web.config文件  
             在<system.web></system.web>之间添加，  
             <httpRuntime useFullyQualifiedRedirectUrl="true" maxRequestLength="21000" executionTimeout="300" />  
             其中，  
             maxRequestLength：设置上传文件的最大值，单位：KB。（默认是4096KB，即4M）  
             executionTimeout：设置超时时间，单位：秒。（默认是90秒）  
             */
        #endregion
        /// <summary>
        /// 文件上传类
        /// </summary>  
        public class Upload
        {
            #region 字段
            private string _UploadInfo; // 文件上传的返回信息。  
            private bool _UploadState; // 文件上传的返回状态。  
            private string _FileType; // 允许上传文件的类型。  
            private int _FileSize; // 上传文件的大小，单位B  
            private int _MaxFileSize; // 上传文件大小的最大长度，单位B  
            private string _NewFileName; // 上传后的文件名。  
            #endregion
            /// <summary>
            /// 初始文件上传类(默认)
            /// </summary>  
            public Upload()
            {
                _UploadInfo = "NONE";
                _UploadState = false;
                _FileType = "*";
                _MaxFileSize = 10240000;//1000k 即1024*1000b，单位B  
                _NewFileName = "";
            }
            #region 属性
            /// <summary>
            /// 文件上传的返回信息
            /// </summary>  
            public string UploadInfo
            {
                set { _UploadInfo = value; }
                get { return _UploadInfo; }
            }
            /// <summary>
            /// 文件上传的返回状态，成功true，失败false
            /// </summary>  
            public bool UploadState
            {
                set { _UploadState = value; }
                get { return _UploadState; }
            }
            /// <summary>
            /// 允许上传文件的类型,* 默认代表可任意类型,或自定义类型，如 "jpg|gif|bmp"
            /// </summary>  
            public string FileType
            {
                set { _FileType = value; }
                get { return _FileType; }
            }
            /// <summary>
            /// 上传文件的大小，单位K
            /// </summary>  
            public int FileSize
            {
                get { return _FileSize / 1024; }
            }
            /// <summary>
            /// 上传文件大小的最大长度，单位K
            /// </summary>  
            public int MaxFileSize
            {
                set { _MaxFileSize = value * 1024; }
                get { return _MaxFileSize / 1024; }
            }
            /// <summary>
            /// 上传后的文件名
            /// </summary>  
            public string NewFileName
            {
                set { _NewFileName = value; }
                get { return _NewFileName; }
            }
            #endregion
            #region 上传主程序
            /// <summary>
            /// 上传本地文件到服务器
            /// </summary>  
            /// <param name="strSaveDir">在服务器端保存的物理路径。</param>  
            /// <param name="FileUploadCtrlID">上传的文件对象，这里使用的是FileUpload控件，</param>  
            /// <param>第二个参数如果是HTMl Input(File)控件可改为：HtmlInputFile HtmCtrlObjUploadFile</param>  
            /// <returns></returns>  
            public void UploadFileGo(string strSaveDir, FileUpload FileUploadCtrlID)
            {
                int intFileExtPoint = FileUploadCtrlID.PostedFile.FileName.LastIndexOf("."); //最后一个 . 号的位置  
                string strFileExtName = FileUploadCtrlID.PostedFile.FileName.Substring(intFileExtPoint + 1).ToLower(); // 获取上传文件的后缀名。  
                _FileSize = FileUploadCtrlID.PostedFile.ContentLength;//上传的文件大小 byte  
                if (_FileSize == 0) // 判断是否有文件需要上传或所选文件是否为0字节。  
                {
                    _UploadInfo = "没有选择要上传的文件或所选文件大小为0字节";
                    _UploadState = false;
                    return; // 返回文件上传状态和信息。  
                }
                if (_FileSize > _MaxFileSize) // 限制要上传的文件大小(byte)。  
                {
                    _UploadInfo = "上传的文件超过限制大小(" + (_MaxFileSize / 1024).ToString() + "K)";
                    _UploadState = false;
                    return; // 返回文件上传状态和信息。  
                }
                if (_FileType != "*")
                {
                    if (_FileType.ToLower().IndexOf(strFileExtName.ToLower().Trim()) == -1) // 判断要上传的文件类型的是否在允许的范围内。  
                    {
                        _UploadInfo = "不允许上传的文件类型(允许的类型：|" + _FileType + ")";
                        _UploadState = false;
                        return; // 返回文件上传状态和信息  
                    }
                }
                if (_NewFileName == "")
                {
                    _NewFileName = string.Format("{0:yyyyMMdd}",DateTime.Now) +GetRandomStr(); // 随机地为上传后的文件命名,日期+随机数。  
                    _NewFileName = _NewFileName + "." + strFileExtName; //包含扩展名的文件名  
                }
                string newFileName = this.GetSaveDirectory(strSaveDir) + _NewFileName;
                FileUploadCtrlID.PostedFile.SaveAs(newFileName); // 以新的文件名保存上传的文件到指定物理路径。             
                _UploadInfo = newFileName; // 返回上传后的服务器端文件物理路径。  
                _UploadState = true;
            }
            #endregion
            /// <summary>
            /// 返回GUID
            /// </summary>  
            private string GetRandomStr()
            {
                return Guid.NewGuid().ToString().Replace("-","");
            }
            /// <summary>
            /// 获取上传文件存放目录
            /// </summary>  
            /// <param name="DirectoryPath">存放文件的物理路径。</param>  
            /// <returns>返回存放文件的目录。</returns>  
            public string GetSaveDirectory(string DirectoryPath)
            {
                if (!Directory.Exists(DirectoryPath)) // 判断当前目录是否存在。  
                {
                    Directory.CreateDirectory(DirectoryPath); // 建立上传文件存放目录。  
                }
                return DirectoryPath;
            }
        }
    }
