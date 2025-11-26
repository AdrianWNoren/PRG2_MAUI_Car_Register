using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PRG_MAUI_Car_Register.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Vehicle> _vehicles;
        private ObservableCollection<Vehicle> _filteredVehicles;
        private string _registrationNumber;
        private string _manufacturer;
        private string _model;
        private string _yearModel;
        private int _selectedType;
        private string _searchRegistrationNumber;
        private string _searchResult;
        private string _selectedFilter = "All";

        public MainPageViewModel()
        {
            _vehicles = new ObservableCollection<Vehicle>();
            _filteredVehicles = new ObservableCollection<Vehicle>();
            SelectedType = 0;

            RegisterCommand = new Command(ExecuteRegisterCommand);
            SearchCommand = new Command(ExecuteSearchCommand);
        }


        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set => SetProperty(ref _vehicles, value);
        }

        public ObservableCollection<Vehicle> FilteredVehicles
        {
            get => _filteredVehicles;
            set => SetProperty(ref _filteredVehicles, value);
        }

        public string RegistrationNumber
        {
            get => _registrationNumber;
            set => SetProperty(ref _registrationNumber, value);
        }

        public string Manufacturer
        {
            get => _manufacturer;
            set => SetProperty(ref _manufacturer, value);
        }

        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        public string YearModel
        {
            get => _yearModel;
            set => SetProperty(ref _yearModel, value);
        }

        public int SelectedType
        {
            get => _selectedType;
            set => SetProperty(ref _selectedType, value);
        }

        public string SearchRegistrationNumber
        {
            get => _searchRegistrationNumber;
            set => SetProperty(ref _searchRegistrationNumber, value);
        }

        public string SearchResult
        {
            get => _searchResult;
            set => SetProperty(ref _searchResult, value);
        }

        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (SetProperty(ref _selectedFilter, value))
                {
                    UpdateFilteredVehicles();
                }
            }
        }


        public ICommand RegisterCommand { get; }
        public ICommand SearchCommand { get; }


        private void ExecuteRegisterCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(RegistrationNumber) ||
                    string.IsNullOrWhiteSpace(Manufacturer) ||
                    string.IsNullOrWhiteSpace(Model) ||
                    string.IsNullOrWhiteSpace(YearModel))
                {
                    ShowAlert("Varning", "Alla fält måste fyllas i.");
                    return;
                }

                Vehicle.Type vehicleType = (Vehicle.Type)SelectedType;

                Vehicle vehicle = new Vehicle(vehicleType);
                vehicle.RegistrationNumber = RegistrationNumber;
                vehicle.Manufacturer = Manufacturer;
                vehicle.Model = Model;
                vehicle.YearModel = YearModel;

                Vehicles.Add(vehicle);
                UpdateFilteredVehicles();
                ClearTextFields();
                ShowAlert("Lyckades", "Fordon registrerat!");
            }
            catch (ArgumentException ex)
            {
                ShowAlert("Valideringsfel", ex.Message);
            }
            catch (Exception ex)
            {
                ShowAlert("Fel", $"Ett oväntat fel uppstod: {ex.Message}");
            }
        }

        private void ExecuteSearchCommand()
        {
            if (string.IsNullOrEmpty(SearchRegistrationNumber))
            {
                ShowAlert("Varning", "Ange ett registreringsnummer för att söka.");
                return;
            }

            var foundVehicle = Vehicles.FirstOrDefault(v =>
                v.RegistrationNumber?.Equals(SearchRegistrationNumber, StringComparison.OrdinalIgnoreCase) == true);

            if (foundVehicle != null)
            {
                SearchResult = $"Fordon hittat:\n" +
                             $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                             $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                             $"Modell: {foundVehicle.Model}\n" +
                             $"Årsmodell: {foundVehicle.YearModel}\n" +
                             $"Typ: {foundVehicle.VehicleType}";
            }
            else
            {
                ShowAlert("Sökresultat", "Inget fordon hittades med det registreringsnumret.");
            }
        }

        private void UpdateFilteredVehicles()
        {
            var filtered = SelectedFilter switch
            {
                "Cars" => Vehicles.Where(v => v.VehicleType == Vehicle.Type.Bil),
                "MC" => Vehicles.Where(v => v.VehicleType == Vehicle.Type.MC),
                "Trucks" => Vehicles.Where(v => v.VehicleType == Vehicle.Type.Lastbil),
                _ => Vehicles.AsEnumerable()
            };

            FilteredVehicles = new ObservableCollection<Vehicle>(filtered);
        }


        private void ClearTextFields()
        {
            RegistrationNumber = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            YearModel = string.Empty;
        }

        private void ShowAlert(string title, string message)
        {
            MessagingCenter.Send(this, "ShowAlert", new AlertMessage { Title = title, Message = message });
        }
    }

    public class AlertMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}