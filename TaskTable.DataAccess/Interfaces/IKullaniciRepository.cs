using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface IKullaniciRepository
    {
        void KaydetKullanici(Kullanici Kullanici);
        void SilKullanici(Kullanici Kullanici);
        Kullanici GetirKullanici(int id);
        List<Kullanici> GetirKullanicilar();
    }
}
