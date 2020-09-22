using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SqlData
{
    public class PetShopAppContext: DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt) { }

        public DbSet<Pet> pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }

    }
}
