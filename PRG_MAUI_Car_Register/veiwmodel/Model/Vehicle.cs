using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register.veiwmodel.Model
{
abstract class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearmodel = string.Empty;

        // Konstruktor (en metod med samma namn som klassen, som  ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorret registreringsnummer: De första tre tecknen måste vara bokstäver.");
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registrationNumber = value.ToUpper();
            }
        }
        public string Yearmodel
        {
            get { return yearmodel; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Årsmodellen kan ej vara tom, detta fält måste fyllas i");
                }
                else if (!Regex.IsMatch(value, @"^\d{4}$"))
                {
                    throw new ArgumentException("Årsmodellen ska bestå av fyra siffror, t.ex. 1989");
                }

                int year = int.Parse(value);
                if (year < 1886 || year > DateTime.Now.Year)
                {
                    throw new ArgumentException("Årsmodellen måste vara mellan 1886 och innevarande år");
                }

                yearmodel = value;
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public string Manufacturer
        {
            get { return manufacturer; }
            set {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tillverkarnamnet kan ej vara tomt, detta fält måste fyllas i");

                }

                    
                if (value.Any(char.IsDigit)){
                    throw new ArgumentException("Tillverkarnamnet kan ej innehålla siffror");
                }
                string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                foreach (var item in specialChar)
                {
                    if (value.Contains(item))
                    {
                        throw new ArgumentException("Tillverkarnamnet kan ej innehålla specialtecken");
                    }

                }
            


                manufacturer = value.ToUpper();
            }
        }
        public Type VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }


        public string Model
        {
            get { return model; }
            set {
                if(string.IsNullOrWhiteSpace(value))
                {
                  
                  throw new ArgumentException("Modelnamnet kan ej vara tomt, detta fält måste fyllas i");

                }
                string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                foreach (var item in specialChar)
                {
                    if (value.Contains(item))
                    {
                        throw new ArgumentException("Modelnamnet" +
                            " kan ej innehålla specialtecken");
                    }

                }

                model = value; }
        }

      





        // Klassens  eventuella övriga metoder brukar finnas här, här en override av ToString(). And gärna RegEx.Match()

        //TODO Modifiera overriden på ToString() så att allt visas som önskat i UIs listBox
        public override string ToString()
        {
            return registrationNumber + "\t" + yearmodel + "\t" + vehicleType + "\t" + manufacturer + "\t" + model;
        }
    }
}
