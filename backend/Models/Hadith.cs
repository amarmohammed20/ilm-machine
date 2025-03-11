using System.ComponentModel.DataAnnotations.Schema;
namespace IlmMachine.Backend.Models

{
	[Table("Hadiths", Schema = "dirtyData")]
	public class Hadith
	{
		public int Id { get; set; }
		public bool Authentic { get; set; }
		public string Arabic { get; set; } = string.Empty;
		public string Narrater { get; set; } = string.Empty;
	}
}