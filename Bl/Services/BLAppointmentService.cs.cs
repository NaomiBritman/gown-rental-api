using Aspose.Pdf.LowCode;
using Bl.Api;
using Bl.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services
{

    public class BLAppointmentService : IBLAppointment
    {

        ICustomer customer;
        IAppointment appointment;
        public BLAppointmentService(IDal A)
        {
            appointment = A.Appointment;
            customer = A.Customer;
        }

        public void Create(AppointmentFullDetaills fullAppointment)
        {
            appointment.CreateAppointment(new Appointment()
            {
                CustomerId = fullAppointment.CustomerId,
                Date = fullAppointment.AppointmentDate,
                Hour = fullAppointment.Hour,
                NumberOfPeople = fullAppointment.NumberOfPeople,
                IsAvailable = !fullAppointment.IsAvailable
            });

            customer.CreateCustomer(new Customer()
            {
                Id = fullAppointment.CustomerId,
                Name = fullAppointment.CustomerName,
                Phone = fullAppointment.CustomerPhone,
                Email = fullAppointment.CustomerEmail
            });

        }

        public void DeleteAppointment(int id)
        {
            Appointment oldAppointment = appointment.GetAppointmentById(id);

            if (oldAppointment == null)
            {
                throw new ArgumentNullException("This appointment details doesn't exist");
            }
            this.appointment.DeleteAppointment(id);
            this.appointment.UpdateIsAvailable(id);
        }

        public List<AppointmentFullDetaills>? GetAppointmentDate(DateOnly date)
        {
            
            return (from a in appointment.GetAllAppointments()
                    join c in customer.GetAllCustomers() on a.CustomerId equals c.Id
                    where a.Date == date
                    select new AppointmentFullDetaills()
                    {
                        AppointmentDate = a.Date,
                        CustomerId = a.CustomerId,
                        Hour = a.Hour,
                        NumberOfPeople = a.NumberOfPeople,
                        IsAvailable = a.IsAvailable,
                        CustomerName = c.Name,
                        CustomerPhone = c.Phone,
                        CustomerEmail = c.Email
                    }).ToList();

        }
        public List<AppointmentFullDetaills>? GetAvailableAppointments(DateOnly date)
        {
            return (from a in appointment.GetAllAppointments()
                    where a.IsAvailable == true
                    select new AppointmentFullDetaills()
                    {
                        AppointmentDate = a.Date,
                        CustomerId = a.CustomerId,
                        Hour = a.Hour,
                        NumberOfPeople = a.NumberOfPeople,
                        IsAvailable = a.IsAvailable,
                    }).ToList();
        }

        public AppointmentFullDetaills? GetAppointmentId(int id)
        {
            return (from a in appointment.GetAllAppointments()
                    join c in customer.GetAllCustomers() on a.CustomerId equals c.Id
                    where a.Id == id
                    select new AppointmentFullDetaills()
                    {
                        AppointmentDate = a.Date,
                        CustomerId = a.CustomerId,
                        Hour = a.Hour,
                        NumberOfPeople = a.NumberOfPeople,
                        IsAvailable = a.IsAvailable,
                        CustomerName = c.Name,
                        CustomerPhone = c.Phone,
                        CustomerEmail = c.Email
                    }).FirstOrDefault();
        }

        public List<AppointmentFullDetaills> GetFullAppointments()
        {
            if (appointment.GetAllAppointments == null || customer.GetAllCustomers()==null)
            {
                throw new ArgumentNullException("No appointments or customers");
            }

                return (from a in appointment.GetAllAppointments()
                    join c in customer.GetAllCustomers() on a.CustomerId equals c.Id
                    select new AppointmentFullDetaills()
                    {
                        AppointmentDate = a.Date,
                        CustomerId = a.CustomerId,
                        Hour = a.Hour,
                        NumberOfPeople = a.NumberOfPeople,
                        IsAvailable = a.IsAvailable,
                        CustomerName = c.Name,
                        CustomerPhone = c.Phone,
                        CustomerEmail = c.Email
                    }).ToList();


        }



        
    }
}

       
  

