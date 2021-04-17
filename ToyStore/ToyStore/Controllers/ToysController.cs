using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStore.Models;
using ToyStore.Services;

namespace ToyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //CLASE DONDE SE USA EL PATRON IREPOSITORY
    public class ToysController : ControllerBase
    {

        //ToyService
        private readonly IToyService toyService;
        public ToysController(IToyService toyService)
        {
            this.toyService = toyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toy>>> GetToys()
        {
            var listToys = await toyService.GetAll();
            return listToys;
        }

        // GET: api/Toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toy>> GetToy(int id)
        {
            var toy = await toyService.GetById(id);

            if (toy == null)
            {
                return NotFound();
            }

            return toy;
        }

        // PUT: api/Toys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToy(int id, Toy toy)
        {
            if (id != toy.Id)
            {
                return BadRequest();
            }

            await toyService.Update(id, toy);
            return NoContent();
        }

        // POST: api/Toys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Toy>> PostToy(Toy toy)
        {
            var toys = await toyService.Insert(toy);

            return CreatedAtAction("GetToy", new { id = toys.Id }, toys);
        }

        // DELETE: api/Toys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToy(int id)
        {
            var toy = await toyService.GetById(id);

            if (toy == null)
            {
                return NotFound();
            }

            await toyService.Delete(id, toy as Toy);

            return NoContent();
        }
    }
    //public class ToysController : ControllerBase
    //{
    //    private readonly DataContext _context;

    //    public ToysController(DataContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/Toys
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<Toy>>> GetToys()
    //    {
    //        return await _context.Toys.ToListAsync();
    //    }

    //    // GET: api/Toys/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Toy>> GetToy(int id)
    //    {
    //        var toy = await _context.Toys.FindAsync(id);

    //        if (toy == null)
    //        {
    //            return NotFound();
    //        }

    //        return toy;
    //    }

    //    // PUT: api/Toys/5
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutToy(int id, Toy toy)
    //    {
    //        if (id != toy.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(toy).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!ToyExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Toys
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPost]
    //    public async Task<ActionResult<Toy>> PostToy(Toy toy)
    //    {
    //        _context.Toys.Add(toy);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetToy", new { id = toy.Id }, toy);
    //    }

    //    // DELETE: api/Toys/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteToy(int id)
    //    {
    //        var toy = await _context.Toys.FindAsync(id);
    //        if (toy == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Toys.Remove(toy);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool ToyExists(int id)
    //    {
    //        return _context.Toys.Any(e => e.Id == id);
    //    }
    //}

}
