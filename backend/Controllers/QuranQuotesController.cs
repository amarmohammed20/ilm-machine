using Microsoft.AspNetCore.Mvc;
using IlmMachine.Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class QuranQuotesController: ControllerBase
{
    private static readonly string[] ArabicText = 
    {
        "قُلْ هُوَ اللَّهُ أَحَدٌ",
        "قُلْ أَعُوذُ بِرَبِّ الْفَلَقِ",
        "قُلْ أَعُوذُ بِرَبِّ النَّاسِ"
    };

    private static readonly string[] Narraters = 
    {
        "Abu Huraira",
        "Ibn Majah",
        "Al-Bukhari"
    };

    private static readonly string[] EnglishText = 
    {
        "Say, 'He is Allah, [who is] One,'",
        "Say, 'I seek refuge in the Lord of daybreak'",
        "Say, 'I seek refuge in the Lord of mankind,'"
    };

    [HttpGet]
    public IActionResult GetQuranQuotes()
    {
			if (ArabicText == null || ArabicText.Length == 0 
					|| Narraters == null || Narraters.Length == 0
					|| EnglishText == null || EnglishText.Length == 0
					) {
					return BadRequest(new { message = "The Arabic text, the English text, or the narraters are not available." });
			}

		try {
			var QuranQuotes = Enumerable.Range(1, 5).Select(index =>
					new QuranQuotes
					(
							Arabic: ArabicText[Random.Shared.Next(ArabicText.Length)],
							English: EnglishText[Random.Shared.Next(EnglishText.Length)],
							Narrater: Narraters[Random.Shared.Next(Narraters.Length)]
					))
					.ToArray();
			return Ok(QuranQuotes);

		} catch (Exception e) {
			Console.WriteLine(e);
			return StatusCode(500, new { message = "An error occurred while fetching the Quran quotes.", detials = e.Message });
		}
	}
}