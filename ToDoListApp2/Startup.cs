using ToDoListApp2.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(ToDoListApp2.Startup))]
namespace ToDoListApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
