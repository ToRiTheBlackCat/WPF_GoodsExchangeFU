using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportService
    {
        private ReportRepository _repo = new();
        public List<Report> LoadWaitingReportList()
        {
            return _repo.GetReports().Where(r => r.Status == 0).ToList();
        }
        public void MarkDoneReport(Report report)
        {
            _repo.UpdateReport(report);
        }
    }
}
