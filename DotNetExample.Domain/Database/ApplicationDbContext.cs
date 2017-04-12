using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using DotNetExample.Common.Utils.Attributes;
using DotNetExample.Domain.Models;
using DotNetExample.Domain.Models.Owin;

namespace DotNetExample.Domain.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += (sender, e) => DateTimeKindAttribute.Apply(e.Entity);
#if DEBUG
            Database.Log = s => Debug.Write(s);
#endif
        }

        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
            //todo: should be deleted
            //            Database.SetInitializer<DefaultDataContext>(new UHealthDatabaseInitializer());
            //            Database.Initialize(true);
            // Sets the default command timeout 1.5 minutes.
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 90;

            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += (sender, e) => DateTimeKindAttribute.Apply(e.Entity);

#if DEBUG
            Database.Log = s => Debug.Write(s);
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<Role>().ToTable("Roles");
        }

        public override int SaveChanges()
        {
            AddAuditingInformation();
            return base.SaveChanges();
        }

        /// <summary>
        /// Adds information about the creation and modification dates.
        /// </summary>
        private void AddAuditingInformation()
        {
            foreach (var entry in ChangeTracker
                .Entries()
                .Where(x => x.Entity is IAuditInfo
                    && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {
                var auditInfo = (IAuditInfo)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        if (auditInfo.CreatedOn.Equals(DateTime.MinValue))
                        {
                            auditInfo.CreatedOn = DateTime.UtcNow;
                        }
                        break;
                    case EntityState.Modified:
                        auditInfo.ModifiedOn = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
