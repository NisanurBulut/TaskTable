using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface ICalismaRepository
    {
        void KaydetCalisma(CalismaEntity calisma);
        void SilCalisma(CalismaEntity calisma);
        CalismaEntity GetirCalisma(int id);
        List<CalismaEntity> GetirCalismalar();
    }
}
