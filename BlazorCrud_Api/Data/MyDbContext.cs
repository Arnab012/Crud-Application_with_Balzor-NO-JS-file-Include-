using Brazor_web_class;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorCrud_Api.Data
{
	public class MyDbContext:DbContext
	{
        public MyDbContext(DbContextOptions<MyDbContext>options):base(options) { 

        }
        public DbSet<StudentClass> Table_studnt {  get; set; }

    }
}
