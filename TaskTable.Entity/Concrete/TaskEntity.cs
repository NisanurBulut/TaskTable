using System;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class TaskEntity : ITablo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Durum { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        // görev oluşturulurken kullanıcı atama zorlaması olmaması için nullable olmalı
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // nullable olmadıı için zorunlu alan
        public int UrgencyId { get; set; }
        public UrgencyEntity Urgency { get; set; }
    }
}
