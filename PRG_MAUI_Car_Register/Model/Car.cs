using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {
        private int doors;
        public Car(Type vehicleType) : base(vehicleType)
        {
        }
        public int Doors
        {
            get { return doors; }

            set
            {
                if (value < 1 || value > 6)
                {
                    doors = value;
                }
                else
                {
                    throw new ArgumentException("Antal dörrar måste vara mellan 1 och 6");
                }
            }
        }
    }
}
