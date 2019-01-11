using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MachinApp.Common.Models;
using MachinApp.Domain.Models;

namespace MachinApp.Api.Controllers
{
    public class MachinesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Machines
        public IQueryable<Machine> GetMachines()
        {
            return db.Machines;
        }

        // GET: api/Machines/5
        [ResponseType(typeof(Machine))]
        public async Task<IHttpActionResult> GetMachine(int id)
        {
            Machine machine = await db.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        // PUT: api/Machines/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMachine(int id, Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.MachineId)
            {
                return BadRequest();
            }

            db.Entry(machine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Machines
        [ResponseType(typeof(Machine))]
        public async Task<IHttpActionResult> PostMachine(Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Machines.Add(machine);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = machine.MachineId }, machine);
        }

        // DELETE: api/Machines/5
        [ResponseType(typeof(Machine))]
        public async Task<IHttpActionResult> DeleteMachine(int id)
        {
            Machine machine = await db.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            db.Machines.Remove(machine);
            await db.SaveChangesAsync();

            return Ok(machine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MachineExists(int id)
        {
            return db.Machines.Count(e => e.MachineId == id) > 0;
        }
    }
}