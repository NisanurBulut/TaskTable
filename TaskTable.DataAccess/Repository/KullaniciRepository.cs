using System;
using System.Collections.Generic;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class KullaniciRepository : IKullaniciRepository
    {
        public KullaniciEntity GetirKullanici(int id)
        {
            throw new NotImplementedException();
        }

        public List<KullaniciEntity> GetirKullanicilar()
        {
            throw new NotImplementedException();
        }

        public void KaydetKullanici(KullaniciEntity Kullanici)
        {
            throw new NotImplementedException();
        }

        public void SilKullanici(KullaniciEntity Kullanici)
        {
            throw new NotImplementedException();
        }
    }
}
