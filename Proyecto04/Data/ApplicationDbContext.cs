using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto04.Areas.Identity.Models;

namespace Proyecto04.Data
{
    public class ApplicationDbContext : IdentityDbContext<MiUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
