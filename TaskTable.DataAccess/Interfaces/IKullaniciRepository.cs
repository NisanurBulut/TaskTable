using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface IKullaniciRepository
    {
        void KaydetKullanici(KullaniciEntity Kullanici);
        void SilKullanici(KullaniciEntity Kullanici);
        KullaniciEntity GetirKullanici(int id);
        List<KullaniciEntity> GetirKullanicilar();
    }
}
