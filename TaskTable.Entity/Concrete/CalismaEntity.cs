using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Entity.Concrete
{
    public class CalismaEntity : ITablo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ad { get; set; }
        [Required]
        [MaxLength(150)]
        public string Aciklama { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public KullaniciEntity Kullanici { get; set; }
    }
}
