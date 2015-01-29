using System;
namespace Eastcom.Model
{
	/// <summary>
	/// 权限表（功能）
	/// </summary>
	[Serializable]
	public partial class Sys_Power_Right
	{
		public Sys_Power_Right()
		{}
		#region Model
		private int _rightid;
		private int _parentid;
		private string _rightname;
		private string _remark;
		private int? _fk_editid;
		private DateTime? _edittime;
		private int? _fk_createid;
		private DateTime? _createtime= DateTime.Now;
		private int? _sort=0;
		/// <summary>
		/// 
		/// </summary>
		public int RightID
		{
			set{ _rightid=value;}
			get{return _rightid;}
		}
		/// <summary>
		/// 父ID
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 权限名
		/// </summary>
		public string RightName
		{
			set{ _rightname=value;}
			get{return _rightname;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 修改人ID
		/// </summary>
		public int? FK_EditID
		{
			set{ _fk_editid=value;}
			get{return _fk_editid;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? EditTime
		{
			set{ _edittime=value;}
			get{return _edittime;}
		}
		/// <summary>
		/// 创建人ID
		/// </summary>
		public int? FK_CreateID
		{
			set{ _fk_createid=value;}
			get{return _fk_createid;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 排序编号
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

