using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTable.Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Geriye üretilen pdf dosyasının virtual path'ini döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        string ExportPdf<T>(List<T> entity) where T : class, new();
        /// <summary>
        /// Geriye excel dosyasını byte dizi olarak döner
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        byte[] ExportExcel<T>(List<T> entity) where T : class, new();
    }
}
