using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.veiwmodel.Model
{

    internal class Motorcycle : Vehicle
    {


        private string category;
        public Motorcycle(Type vehicleType) : base(vehicleType)
        {
        }
        public string Category
        {
            get { return category; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Kategorin kan ej vara tom och kan ej inneålla siffor");


                }
                else
                {
                    category = value.ToUpper();
                }

            }



        }

    }
}
