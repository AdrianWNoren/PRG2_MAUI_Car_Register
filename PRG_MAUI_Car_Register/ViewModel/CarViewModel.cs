using System.Collections.ObjectModel;

namespace PRG_MAUI_Car_Register.ViewModel
{
    public class CarViewModel : BaseViewModel
    {
        private ObservableCollection<Vehicle> _allVehicles;
        private ObservableCollection<Vehicle> _cars;

        public CarViewModel(ObservableCollection<Vehicle> allVehicles)
        {
            _allVehicles = allVehicles;
            _cars = new ObservableCollection<Vehicle>(
                _allVehicles.Where(v => v.VehicleType == Vehicle.Type.Bil));

            _allVehicles.CollectionChanged += (s, e) =>
            {
                Cars = new ObservableCollection<Vehicle>(
                    _allVehicles.Where(v => v.VehicleType == Vehicle.Type.Bil));
            };
        }

        public ObservableCollection<Vehicle> Cars
        {
            get => _cars;
            set => SetProperty(ref _cars, value);
        }
    }
}