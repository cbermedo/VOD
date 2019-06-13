using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VOD.Common.Entities;

namespace VOD.Database.Contexts
{
    public class VODContext : IdentityDbContext<VODUser>
    {
        public VODContext(DbContextOptions<VODContext> options): base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
