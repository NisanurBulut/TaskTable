﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Interfaces
{
    public interface IReportService:IBaseService<ReportEntity>
    {
        ReportEntity GetReportWithTaskProperty(int id);
        int GetReportsCountWithAppUserIdProperty(int id);
        int GetReportsCount();
    }
}
