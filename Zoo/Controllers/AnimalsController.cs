using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly ZooContext _db;
    public AnimalsController(ZooContext db)
    {
      _db = db;
    }

    [HttpGet]
public async Task<List<Animal>> Get(string species, string gender, string name, int minimumAge, int age)
{
  IQueryable<Animal> query = _db.Animals.AsQueryable();

  if (species != null)
  {
    query = query.Where(entry => entry.Species == species);
  }

  if (gender != null)
  {
    query = query.Where(entry => entry.Gender == gender);
  }

  if (name != null)
  {
    query = query.Where(entry => entry.Name == name);
  }

  if (minimumAge > 0)
  {
    query = query.Where(entry => entry.Age >= minimumAge);
  }

  if (age != 0)
  {
    query = query.Where(entry => entry.Age == age);
  }

  return await query.ToListAsync();
}

    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }
      return animal;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }
      _db.Entry(animal).State = EntityState.Modified;
      
      try 
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else 
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    [HttpGet("Random")]
    public async Task<ActionResult<Animal>> RandomAnimal()
    {
      Random random = new Random();
      int dbCount = _db.Animals.Count();
      int id = random.Next(1, dbCount);
      var animal = await _db.Animals.FindAsync(id);
      return animal;
    }
  }
}