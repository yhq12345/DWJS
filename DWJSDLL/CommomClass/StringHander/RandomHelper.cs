using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.StringHander
{
    /// <summary>
    /// 随机数操作类
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 生成指定范围内的随机数（不重复）
        /// </summary>
        /// <param name="minValue">最小值（包含）</param>
        /// <param name="maxValue">最大值（不包含）</param>
        /// <returns></returns>
        public static int GetRandomValue(int minValue,int maxValue)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            return rand.Next(minValue, maxValue); 
        }
    }
}
