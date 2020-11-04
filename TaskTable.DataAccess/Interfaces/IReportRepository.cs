using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Interfaces
{
    public interface IReportRepository:IBaseRepository<ReportEntity>
    {
        ReportEntity GetReportWithTaskProperty(int id);
        int GetReportsCountWithAppUserIdProperty(int id);
    }
}
