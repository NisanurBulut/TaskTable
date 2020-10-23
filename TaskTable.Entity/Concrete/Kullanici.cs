using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class Kullanici : ITablo
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public List<Calisma> Calismalar { get; set; }
    }
}
