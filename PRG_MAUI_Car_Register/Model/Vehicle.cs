using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register
{
    public class Vehicle
    {

        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;


        public Vehicle(Type vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        public virtual Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    if (value.Length == 6)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorrekt registreringsnummer: De första tre tecknen måste vara bokstäver.");
                        }

                        for (int i = 3; i < 6; i++)
                        {
                            if (i < 5)
                            {
                                if (!char.IsDigit(value[i]))
                                    throw new ArgumentException("Inkorrekt registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                            }
                            else
                            {
                                if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                    throw new ArgumentException("Inkorrekt registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken.");
                    }
                }
                else
                {
                    throw new ArgumentException("Registreringsnummer får inte vara tomt.");
                }

                registrationNumber = value.ToUpper();
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tillverkare får inte vara tomt.");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Tillverkare måste vara minst 2 tecken långt.");
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Tillverkare får inte vara längre än 50 tecken.");
                }


                if (!Regex.IsMatch(value, @"^[a-zA-ZåäöÅÄÖ\s]+$"))
                {
                    throw new ArgumentException("Tillverkare får bara innehålla bokstäver och mellanslag.");
                }

                string trimmedValue = value.Trim();
                manufacturer = char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1).ToLower();
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Modell får inte vara tomt.");
                }

                if (value.Length < 1)
                {
                    throw new ArgumentException("Modell måste vara minst 1 tecken långt.");
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Modell får inte vara längre än 50 tecken.");
                }

                if (!Regex.IsMatch(value, @"^[a-zA-ZåäöÅÄÖ0-9\s]+$"))
                {
                    throw new ArgumentException("Modell får bara innehålla bokstäver, siffror och mellanslag.");
                }

                model = value.Trim();
            }
        }

        public string YearModel
        {
            get { return yearModel; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Årsmodell får inte vara tomt.");
                }

                if (!Regex.IsMatch(value, @"^(19[0-9]{2}|20[0-9]{2})$"))
                {
                    throw new ArgumentException("Årsmodell måste vara ett fyrsiffrigt år mellan 1900 och " + (DateTime.Now.Year + 1));
                }

                int year = int.Parse(value);
                int currentYear = DateTime.Now.Year;

                if (year < 1900 || year > currentYear + 1)
                {
                    throw new ArgumentException($"Årsmodell måste vara mellan 1900 och {currentYear + 1}.");
                }

                yearModel = value;
            }
        }

        public override string ToString()
        {
            string yearDisplay = string.IsNullOrEmpty(yearModel) ? "Ej angivet" : yearModel;
            return $"{registrationNumber}\t{vehicleType}\t{manufacturer}\t{model}\t{yearDisplay}";
        }

        public string ToFormattedString()
        {
            string yearDisplay = string.IsNullOrEmpty(yearModel) ? "Ej angivet" : yearModel;
            return $"Reg: {registrationNumber} | Typ: {vehicleType} | Tillverkare: {manufacturer} | Modell: {model} | Årsmodell: {yearDisplay}";
        }
    }
}