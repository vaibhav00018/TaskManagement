using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDataAccess.DBModel;

namespace TaskManagementDataAccess
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options)
            : base(options)
        {
        }

        public  DbSet<TaskModel> Tasks { get; set; }
    }
}
