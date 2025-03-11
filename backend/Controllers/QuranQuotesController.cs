using backend.Data;
using Microsoft.AspNetCore.Mvc;
using IlmMachine.Backend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class QuranQuotesController : ControllerBase
{
	private readonly ILMDbContext _context;
	
	public QuranQuotesController(ILMDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetQuranQuotes()
	{
		try
		{
			var quranQuotes = await _context.QuranQuotes.ToListAsync();
			return Ok(quranQuotes);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500,
				new { message = "An error occurred while fetching the Quran quotes.", detials = e.Message });
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetQuranQuote(int id)
	{
		try
		{
			var quranQuote = await _context.QuranQuotes.FindAsync(id);
			if (quranQuote == null)
				return NotFound(new { Message = $"Quran quote with ID {id} not found." });

			return Ok(quranQuote);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, new { Message = "An error has occured while retieving the quran quote", Error = e.Message });
		}
	}
	
	[HttpPost]
	public async Task<IActionResult> PostQuranQuote(QuranQuotes quranQuote)
	{
		try
		{
			if (!ModelState.IsValid)
				return BadRequest(new { Message = "Invalid Quran quote data." });
			
			_context.QuranQuotes.Add(quranQuote);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetQuranQuote), new { id = quranQuote.Id }, quranQuote);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, new { Message = "An error occured while saving the quran quote", Error = e.Message });
		}
	}
}