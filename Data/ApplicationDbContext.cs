using System;
using CRMFamaV2.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMFamaV2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<PartnerModel> PartnerList { get; set; }

        public DbSet<UserModel> UserList { get; set; }
    }
}

