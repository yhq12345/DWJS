using System;
namespace Eastcom.Model
{
	/// <summary>
	/// 角色表
	/// </summary>
	[Serializable]
	public partial class Sys_Power_Role
	{
		public Sys_Power_Role()
		{}
		#region Model
		private int _roleid;
		private string _rolename;
		private int _roleweight;
		private string _remark;
		private int? _fk_editid;
		private DateTime? _edittime;
		private int? _fk_createid;
		private DateTime? _createtime= DateTime.Now;
		private int? _sort=0;
		/// <summary>
		/// 编号ID
		/// </summary>
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 角色名
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 角色权重
		/// </summary>
		public int RoleWeight
		{
			set{ _roleweight=value;}
			get{return _roleweight;}
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
		/// 
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

