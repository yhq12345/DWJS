using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemConfig
{
    /// <summary>
    /// 权限enum
    /// </summary>
      public  enum RightEnum
        {
            //用户管理
            用户管理_新增用户 = 1,
            用户管理_修改用户,
            用户管理_删除用户,
            用户管理_查看用户,
            //权限管理
            权限管理_添加角色,
            权限管理_修改角色,
            权限管理_删除角色,
            权限管理_查看角色,
            //任务管理
            任务管理_新增任务,
            任务管理_修改任务,
            任务管理_删除任务,
            任务管理_查看任务,
            任务管理_任务详细_添加详细,
            任务管理_任务详细_修改详细,
            任务管理_任务详细_删除详细,
            任务管理_任务详细_查看详细
        }
}
