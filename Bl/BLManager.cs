using Bl.Api;
using Bl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bl.Api;
using Bl.Services;
using Dal.Api;

namespace Bl
{
    // Implement the IBl facade so it can be resolved from DI
    public class BLManager : IBl
    {
        public IBLAppointment? BLAppointment { get; }

        // Accept IDal from DI and construct the appointment service (or accept IBLAppointment directly)
        public BLManager(IDal dal)
        {
            BLAppointment = new BLAppointmentService(dal);
        }
    }
}
