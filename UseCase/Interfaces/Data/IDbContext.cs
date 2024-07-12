using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Interfaces.Data
{
    public abstract class IDbContext : DbContext
    {
        protected IDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
