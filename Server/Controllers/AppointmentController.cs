using Bl;
using Bl.Api;
using Bl.Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IBl bl) : ControllerBase
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        IBLAppointment bl = bl.BLAppointment;
#pragma warning restore CS8601 // Possible null reference assignment.

        // GET: api/<AppointmentController>
        
        [HttpGet]
        public List<AppointmentFullDetaills> GetAllAppointments()
        {
            return bl.GetFullAppointments();
        }

        // GET api/<AppointmentController>
        [HttpGet("{id}")]
        public AppointmentFullDetaills? GetAppointmentByID(int id)
        {

            return bl.GetAppointmentId(id);
        }

        // GET api/<AppointmentController>
        [Route("getByDate/{date}")]
        [HttpGet]
        public List<AppointmentFullDetaills>? GetAppointmentByDate(DateOnly date)
        {

            return bl.GetAppointmentDate(date);
        }

        // GET api/<AppointmentController>/5
        [Route("getAvailableAppointments/{date}")]
        [HttpGet]
        
        public List<AppointmentFullDetaills> GetAvailableAppointments(DateOnly date)
        {

            return bl.GetAvailableAppointments(date);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] AppointmentFullDetaills newAppointment)
        {
            bl.Create(newAppointment);
        }

     
        // DELETE api/<GownsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.DeleteAppointment(id);
        }
    }
}

