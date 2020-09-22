using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.SqlData
{
    public class PetShopAppContext: DbContext
    {
        public DbSet<Pet> pets { get; set; }

    }
}
