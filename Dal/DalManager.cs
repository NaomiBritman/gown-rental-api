using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public class DalManager : IDal
    {
        public IAppointment Appointment { get; }

        public ICustomer Customer { get; }

        public DalManager()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<DataManager>();
            services.AddSingleton<IAppointment, AppointmentService>();
            services.AddSingleton<ICustomer, CustomerService>();

            ServiceProvider provider = services.BuildServiceProvider();
            Appointment = provider.GetRequiredService<IAppointment>();
            Customer = provider.GetRequiredService<ICustomer>();
            // DataManager db = new();
            // Products=new ProductService(db);


            //  Orders = new OrdersService(db);
        }


    }
}
