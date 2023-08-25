using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BikeFactory2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeFactory2.Data;

public class BikeFactoryContext: IdentityDbContext
{
    public BikeFactoryContext (DbContextOptions options): base(options)
    {

    }

    public DbSet<Bikes> Bikes { get; set; }

}
