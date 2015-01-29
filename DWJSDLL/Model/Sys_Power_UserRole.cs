using System;
namespace Eastcom.Model
{
	/// <summary>
	/// 用户角色表
	/// </summary>
	[Serializable]
	public partial class Sys_Power_UserRole
	{
		public Sys_Power_UserRole()
		{}
		#region Model
		private int _id;
		private int _fk_userid;
		private int _fk_roleid;
		private int? _fk_editid;
		private DateTime? _edittime;
		private int? _fk_createid;
		private DateTime? _createtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int FK_UserId
		{
			set{ _fk_userid=value;}
			get{return _fk_userid;}
		}
		/// <summary>
		/// 角色ID
		/// </summary>
		public int FK_RoleId
		{
			set{ _fk_roleid=value;}
			get{return _fk_roleid;}
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
		#endregion Model

	}
}

