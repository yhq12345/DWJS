using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eastcom.Common
{
    public class ConvertNumToStart
    {
        private static  char[] Num={'0','1','2','3','4','5','6','7','8','9'};
        public static  string ConvertToStar(string GetString)
        {
            string ReturnValue = "";
            if (GetString == string.Empty)
            {
                return GetString;
            }
            else
            {
                foreach (char a in GetString)
                {
                    if (IsNum(a))
                    {
                        ReturnValue += '*';
                    }
                    else
                    {
                        ReturnValue += a;
                    }
                }
            }
            return ReturnValue;
        }
        public static bool IsNum(char b)
        {
            bool IsNum = false;
            for (int i = 0; i < Num.Length; i++)
            {
                if (b == Num[i])
                {
                    IsNum = true;
                }
            }
            return IsNum;
        }

    }
}
