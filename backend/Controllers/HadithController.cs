using backend.Data;
using Microsoft.AspNetCore.Mvc;
using IlmMachine.Backend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class HadithController : ControllerBase
{
	private readonly ILMDbContext _context;
	
	public HadithController(ILMDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetHadith()
	{
		try
		{
			var hadiths = await _context.Hadiths.ToListAsync();
			return Ok(hadiths);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, new { message = "An error occurred while fetching the hadiths.", Error = e.Message });
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetHadithById(int id)
	{
		try
		{
			var hadith = await _context.Hadiths.FindAsync(id);
			if (hadith == null)
				return NotFound(new { Message = $"Hadith with ID {id} not found." });
			
			return Ok(hadith);
		}
		catch (Exception e)
		{
			return StatusCode(500, new { Message = "An error occured while retrieving the hadith", Error = e.Message });
		}
	}
	
	[HttpPost]
	public async Task<IActionResult> PostHadith(Hadith hadith)
	{
		try
		{
			if (!ModelState.IsValid)
				return BadRequest(new { Message = "Invalid Hadith data." });
			
			_context.Hadiths.Add(hadith);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetHadithById), new { id = hadith.Id }, hadith);
		}
		catch (Exception e)
		{
			return StatusCode(500, new { Message = "An error occured while adding the hadith", Error = e.Message });
		}
	}
}