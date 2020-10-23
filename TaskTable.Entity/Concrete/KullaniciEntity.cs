using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class KullaniciEntity : ITablo
    {
       
        public int Id { get; set; }
       
        public string Ad { get; set; }
        
        public string Soyad { get; set; }
       
        public string Telefon { get; set; }
       
        public string Eposta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public List<CalismaEntity> Calismalar { get; set; }
    }
}
