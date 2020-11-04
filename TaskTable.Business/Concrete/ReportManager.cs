using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportManager(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public void Add(ReportEntity item)
        {
            _reportRepository.Add(item);
        }

        public ReportEntity Get(int id)
        {
            return _reportRepository.Get(id);
        }

        public List<ReportEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ReportEntity item)
        {
            _reportRepository.Update(item);
        }

        public void Delete(ReportEntity item)
        {
            _reportRepository.Delete(item);
        }

        public ReportEntity GetReportWithTaskProperty(int id)
        {
           return  _reportRepository.GetReportWithTaskProperty(id);
        }

        public int GetReportsCountWithAppUserIdProperty(int id)
        {
            return _reportRepository.GetReportsCountWithAppUserIdProperty(id);
        }
    }
}
