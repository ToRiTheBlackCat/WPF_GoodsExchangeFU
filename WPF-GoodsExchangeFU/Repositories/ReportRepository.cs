using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   
    public class ReportRepository
    {
        GoodsExchangeFudbContext _context;

        public List<Report> GetReports()
        {
            _context = new();
            return _context.Reports.Include("Product").Include("User").ToList();
        }
        public void UpdateReport(Report report)
        {
            _context = new();
            _context.Reports.Update(report);
            _context.SaveChanges();
        }
        public void AddReport(Report report)
        {
            _context = new();
            _context.Reports.Add(report);
            _context.SaveChanges();
        }
    }
}
