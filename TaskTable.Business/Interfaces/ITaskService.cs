﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Interfaces
{
    public interface ITaskService:IBaseService<TaskEntity>
    {
        List<TaskEntity> GetirTamamlanmayanGorevler();
    }
}
