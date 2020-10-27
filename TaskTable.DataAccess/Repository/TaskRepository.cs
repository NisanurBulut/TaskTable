using System;
using System.Collections.Generic;
using System.Linq;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity>,ITaskRepository
    {
      
    }
}
