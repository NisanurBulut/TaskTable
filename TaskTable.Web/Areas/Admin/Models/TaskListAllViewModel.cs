using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;
namespace TaskTable.Web.Areas.Admin.Models
{
    public class TaskListAllViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public AppUser AppUser { get; set; }
        public UrgencyEntity Urgency { get; set; }
        public List<ReportEntity> Reports { get; set; }
    }
}
