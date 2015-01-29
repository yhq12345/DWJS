using System;
using System.IO;

namespace CommonClass.FileHandler
{
	/// <summary>
	/// �ļ�Ŀ¼������
	/// </summary>
	public class FileDirectory
	{
		#region Ŀ¼����
		/// <summary>
		/// �ж�Ŀ¼�Ƿ����
		/// </summary>
		/// <param name="DirectoryName">Ŀ¼·��</param>
		/// <returns>true�����ڣ�false��������</returns>
		public static  bool DirectoryExists(string DirectoryName)
		{
			return Directory.Exists(DirectoryName);
		}
		/// <summary>
		/// ����Ŀ¼
		/// </summary>
		/// <param name="DirectoryName">Ŀ¼��</param>
		/// <returns>����boolean,true:Ŀ¼�����ɹ�, false:Ŀ¼����ʧ��</returns>
		public static  bool MakeDirectory(string DirectoryName)
		{
			try
			{
				if(!Directory.Exists(DirectoryName))
				{
					Directory.CreateDirectory(DirectoryName);
					return true;
				}
				else
				{
					
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// ɾ��ָ����Ŀ¼
		/// </summary>
		/// <param name="DirectoryName">Ŀ¼��</param>
		/// <returns>true��ɾ���ɹ���false��ɾ��ʧ��</returns>
		public static  bool RMDIR(string DirectoryName)
		{
			DirectoryInfo di = new DirectoryInfo(DirectoryName);
			if (di.Exists == false)
			{
				return false;
			}
			else
			{
				di.Delete(true);
				return true;
			}

		}
		/// <summary>
		/// ɾ��Ŀ¼��ɾ�����µ���Ŀ¼�����ļ�
		/// </summary>
		/// <param name="DirectoryName">Ŀ¼��</param>
		/// <returns>true:ɾ���ɹ�,false:ɾ��ʧ��</returns>
		public static  bool DelTree(string DirectoryName)
		{
			if(DirectoryExists(DirectoryName))
			{
				Directory.Delete(DirectoryName,true);
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region �ļ�����
		/// <summary>
		/// ����һ���ļ�
		/// </summary>
		/// <param name="FilePathName">Ŀ¼��</param>
		/// <returns>true:�����ɹ�,false:����ʧ��</returns>
		public static  bool CreateTextFile(string FilePathName)
		{
			try
			{
				FileInfo CreateFile = new FileInfo(FilePathName); //�����ļ� 
				if (!CreateFile.Exists)
				{
					FileStream FS = CreateFile.Create();
					FS.Close();
					CreateFile = null;
					return true;
				}
				else
				{
					CreateFile = null;
					return false;
				}				
			}
			catch
			{
				return false;
			}
		}
		/// <summary> 
		/// ���ļ���׷������ 
		/// </summary> 
		/// <param name="FilePathName">�ļ���</param> 
		/// <param name="WriteWord">׷������</param>
		public static  void AppendText(string FilePathName, string WriteWord)
		{
			try
			{
				//�����ļ� 
				CreateTextFile(FilePathName);
				//�õ�ԭ���ļ������� 
				FileStream FileRead = new FileStream(FilePathName, FileMode.Open, FileAccess.ReadWrite);
				using(StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default))
				{
					string OldString = FileReadWord.ReadToEnd().ToString();
					OldString = OldString + WriteWord;
					//���µ���������д�� 
					using(StreamWriter FileWrite = new StreamWriter(FileRead, System.Text.Encoding.Default))
					{
						FileWrite.Write(WriteWord);
					}
				}
				FileRead.Close();
			}
			catch
			{
				// throw; 
			}
		}

		/// <summary> 
		/// ��ȡ�ļ������� 
		/// </summary> 
		/// <param name="FilePathName">�ļ���</param>
		/// <returns>�ļ�����</returns>
		public static  string ReadFileData(string FilePathName)
		{
			string TxtString = "";
			try
			{

				FileStream FileRead = new FileStream(System.Web.HttpContext.Current.Server.MapPath(FilePathName).ToString(), FileMode.Open, FileAccess.Read);
				using(StreamReader FileReadWord = new StreamReader(FileRead, System.Text.Encoding.Default))
				{
					TxtString = FileReadWord.ReadToEnd().ToString();
				}
				FileRead.Close();
				return TxtString;
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// ɾ���ļ�
		/// </summary>
		/// <param name="AbsoluteFilePath">�ļ����Ե�ַ</param>
		/// <returns>true:ɾ���ļ��ɹ�,false:ɾ���ļ�ʧ��</returns>
		public static  bool FileDelete(string AbsoluteFilePath)
		{
			try 
			{
				FileInfo objFile = new FileInfo(AbsoluteFilePath);
				if(objFile.Exists)//�������
				{
					//ɾ���ļ�.
					objFile.Delete();
					return true;
				}

			} 
			catch 
			{
				return false;
			}
			return false;
		}
        /// <summary>
        /// ����ɾ�����ֳ�Ⱥ�����ͼƬ
        /// </summary>
        /// <param name="FilePaths"></param>
        /// <returns></returns>
        public static  void BatchFileDelete(string FilePaths)
        {
            foreach (string path in FilePaths.Split('$'))
            {
                if (path != string.Empty)
                {
                    FileDelete(path);
                }
            }
        }
		#endregion
	}
}
