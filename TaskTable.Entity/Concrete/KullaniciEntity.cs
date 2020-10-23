using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class KullaniciEntity : ITablo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ad { get; set; }
        [Required]
        [MaxLength(50)]
        public string Soyad { get; set; }
        [Required]
        [MaxLength(11)]
        public string Telefon { get; set; }
        [Required]
        [MaxLength(150)]
        public string Eposta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public List<CalismaEntity> Calismalar { get; set; }
    }
}
