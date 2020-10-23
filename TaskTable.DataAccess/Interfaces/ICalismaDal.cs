﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
   public interface ICalismaDal
    {
        void KaydetCalisma(Calisma calisma);
        void SilCalisma(Calisma calisma);
        Calisma GetirCalisma(int id);
        List<Calisma> GetirCalismalar();
    }
}
