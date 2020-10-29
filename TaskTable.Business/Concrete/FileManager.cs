using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;

namespace TaskTable.Business.Concrete
{
    public class FileManager : IFileService
    {
        public byte[] ExportExcel<T>(List<T> entity) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public string ExportPdf<T>(List<T> entity) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
