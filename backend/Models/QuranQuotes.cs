using System.ComponentModel.DataAnnotations.Schema;
namespace IlmMachine.Backend.Models

{
	[Table("QuranQuotes", Schema = "dirtyData")]
	public class QuranQuotes
	{
		public int Id { get; set; }
		public string Arabic { get; set; } = string.Empty;
		public string English { get; set; } = string.Empty;
		public string Narrater { get; set; } = string.Empty;
	}
}