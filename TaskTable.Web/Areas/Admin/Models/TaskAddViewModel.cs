using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTable.Entity.Concrete;

namespace TaskTable.Web.Areas.Admin.Models
{
    public class TaskAddViewModel
    {
        public string Ad { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int UrgencyId { get; set; }
        public UrgencyEntity Urgency { get; set; }
    }
}
