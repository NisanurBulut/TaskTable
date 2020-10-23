using System;
using System.Collections.Generic;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class KullaniciRepository : IKullaniciRepository
    {
        public Kullanici GetirKullanici(int id)
        {
            throw new NotImplementedException();
        }

        public List<Kullanici> GetirKullanicilar()
        {
            throw new NotImplementedException();
        }

        public void KaydetKullanici(Kullanici Kullanici)
        {
            throw new NotImplementedException();
        }

        public void SilKullanici(Kullanici Kullanici)
        {
            throw new NotImplementedException();
        }
    }
}
