using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.Business.Interfaces
{
   public interface INLogger
    {
        public void ErrorLog(string message);
    }
}
