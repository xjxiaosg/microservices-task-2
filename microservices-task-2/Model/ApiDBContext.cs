using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservices_task_2.Model
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options): base(options)
        {
        }

        public DbSet<MTBooking> MTBooking { get; set; }
    }
}
