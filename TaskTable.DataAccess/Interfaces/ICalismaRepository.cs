using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface ICalismaRepository
    {
        void KaydetCalisma(Calisma calisma);
        void SilCalisma(Calisma calisma);
        Calisma GetirCalisma(int id);
        List<Calisma> GetirCalismalar();
    }
}
