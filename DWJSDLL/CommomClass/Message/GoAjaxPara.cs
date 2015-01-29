using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonClass.Message
{
   public class GoAjaxPara
    {
       public string msg
       {
           get;
           set;
       }
       public int isReload
       {
           get;set;
       }
       public bool isError
       {
           get;
           set;

       }

       public string msnLog
       {
           get;
           set;

       }
       public object Data
       {
           get;
           set;
       }
    }
}
