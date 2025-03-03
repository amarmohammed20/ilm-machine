using Microsoft.AspNetCore.Mvc;
using IlmMachine.Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class HadithController: ControllerBase
{
    private static readonly string[] ArabicText = 
    {
        "حَدَّثَنَا عَبْدُ اللَّهِ...",
        "رَوَى أَبُو هُرَيْرَةَ...",
        "حَدَّثَنَا مُحَمَّدٌ..."
    };

    private static readonly string[] Narraters = 
    {
        "Abu Huraira",
        "Ibn Majah",
        "Al-Bukhari"
    };

    [HttpGet]
    public IActionResult GetHadith()
    {
			if (ArabicText == null || ArabicText.Length == 0 
					|| Narraters == null || Narraters.Length == 0
					) {
				return BadRequest(new { message = "The Arabic text or the narraters are not available." });
			}
			
        try {
					var hadiths = Enumerable.Range(1, 5).Select(index =>
							new Hadith
							(
									Authentic: Random.Shared.Next(0, 2) == 1,
									Arabic: ArabicText[Random.Shared.Next(ArabicText.Length)],
									Narrater: Narraters[Random.Shared.Next(Narraters.Length)]
							))
							.ToArray();
				} catch (Exception e) {
						Console.WriteLine(e);
						return SttusCode(500, new { message = "An error occurred while fetching the hadiths.", detials = e.Message });
				}

        return Ok(hadiths);
    }
}