using IlmMachine.Backend.Models;

namespace backend.Data;
using Microsoft.EntityFrameworkCore;
public class ILMDbContext: DbContext
{
	public ILMDbContext(DbContextOptions<ILMDbContext> options) : base(options) {}
	
	public DbSet<Hadith> Hadiths { get; set; }
	
	public DbSet<QuranQuotes> QuranQuotes { get; set; }
}