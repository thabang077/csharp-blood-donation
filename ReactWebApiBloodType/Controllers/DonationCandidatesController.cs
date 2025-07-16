using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWebApiBloodType.Model;

namespace ReactWebApiBloodType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidatesController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DonationCandidatesController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DonationCandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationCandidate>>> GetDonationCandidates()
        {
            return await _context.DonationCandidates.ToListAsync();
        }

        // GET: api/DonationCandidate
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCandidate>> GetDonationCandidate(int id)
        {
            var donationCandidate = await _context.DonationCandidates.FindAsync(id);

            if (donationCandidate == null)
            {
                return NotFound();
            }

            return donationCandidate;
        }

        // PUT: api/DonationCandidate
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationCandidate(int id, DonationCandidate donationCandidate)
        {
           donationCandidate.Id = id;

            _context.Entry(donationCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationCandidateExists(id))
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

        // POST: api/DonationCandidate
        [HttpPost]
        public async Task<ActionResult<DonationCandidate>> PostDonationCandidate(DonationCandidate donationCandidate)
        {
            _context.DonationCandidates.Add(donationCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonationCandidate", new { id = donationCandidate.Id }, donationCandidate);
        }

        // DELETE api/DonationCandidate
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonationCandidate(int id)
        {
            var donationCandidate = await _context.DonationCandidates.FindAsync(id);
            if (donationCandidate == null)
            {
                return NotFound();
            }

            _context.DonationCandidates.Remove(donationCandidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonationCandidateExists(int id)
        {
            return _context.DonationCandidates.Any(e => e.Id == id);
        }
    }
}
