using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.veiwmodel.Model
{
    internal class Truck : Vehicle
    {
        private double loadcapacity;

        public Truck(Type vehicleType) : base(vehicleType)
        {
        }

        public double LoadCapacity
        {
            get { return loadcapacity; }
        }

        public string LoadCapacityInput
        {
            set
            {
                if (double.TryParse(value, out double result))
                {
                    if (result > 0 && result <= 50000)
                    {
                        loadcapacity = result;
                    }
                    else
                    {
                        throw new ArgumentException("Lastkapacitet måste vara mellan 0-50000 kg");
                    }
                }
                else
                {
                    throw new ArgumentException("Lastkapacitet måste skrivas med siffror");
                }
            }
        }


    }
}