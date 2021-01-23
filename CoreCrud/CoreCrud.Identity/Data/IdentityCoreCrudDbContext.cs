using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCrud.Identity.Data
{
    public class IdentityCoreCrudDbContext : IdentityDbContext
    {
        public IdentityCoreCrudDbContext(DbContextOptions<IdentityCoreCrudDbContext> options)
            : base(options)
        {
        }
    }
}
