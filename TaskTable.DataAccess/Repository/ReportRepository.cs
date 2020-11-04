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
        public int GetReportsCount()
        {
            using var context = new DatabaseContext();
            return context.Reports.Count();
        }

        public int GetReportsCountWithAppUserIdProperty(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
           return context.Tasks.Where(a => a.AppUserId == id)
                .Include(a => a.Reports).Select(a=>a.Reports).Count();

        }

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
