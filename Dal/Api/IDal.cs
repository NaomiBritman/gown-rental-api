using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        IAppointment Appointment { get; }
        ICustomer Customer { get; }
         
    }
}
