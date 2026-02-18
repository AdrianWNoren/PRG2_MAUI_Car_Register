using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Services
{
    public interface IVehicleStorageService 
    {
        Task SaveAsync(IEnumerable<Vehicle> vehicles);
        Task<IList<Vehicle>> LoadAsync();
    }
}