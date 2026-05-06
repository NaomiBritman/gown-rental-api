using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal.Services
{
    public class AppointmentService : IAppointment
    {
        DataManager datamanager;
        public AppointmentService(DataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void CreateAppointment(Appointment a)
        {
            this.datamanager.Appointments.Add(a);
        }

        public void DeleteAppointment(int id)
        {
            Appointment app = datamanager.Appointments.ToList().Find(x => x.Id == id);
            if (app != null)
            {
                this.datamanager.Appointments.Remove(app);
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            return this.datamanager.Appointments.ToList();
        }

        public List<Appointment> GetAppointmentByDate(DateOnly date)
        {
            return this.datamanager.Appointments.Where(x => x.Date == date).ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            Appointment appointment = datamanager.Appointments.ToList().Find(x => x.Id == id);
            if (appointment == null)
            {
                throw new ArgumentNullException("This appointment doesn't exist");
            }
            return appointment;
        }

        public void UpdateIsAvailable(int id)
        {
            Appointment appointment = datamanager.Appointments.ToList().Find(x => x.Id == id);
            if (appointment == null)
            {
                throw new ArgumentNullException("this appointment does not exist. you can't update it ");
            }
            appointment.IsAvailable = !appointment.IsAvailable;
        }


    }



}
    
