using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class ReportRepository : BaseRepository<ReportEntity>, IReportRepository
    {
        public ReportEntity GetReportWithTaskProperty(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Reports
                .Include(a => a.Task)
                .ThenInclude(a => a.Urgency)
                .Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
