using System;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class Calisma : ITablo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KullaniciId { get; set; }
    }
}
