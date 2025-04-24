using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_KOZ_LAB1.Models;
using WPF_KOZ_LAB1.ViewModels;

namespace WPF_KOZ_LAB1
{
    public partial class MainWindow : Window
    {
        private readonly IStorage _storage;

        public ObservableCollection<Bron> Brons { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Inventory> Inventories { get; set; }
        public ObservableCollection<Skidka> Skidkas { get; set; }
        public ObservableCollection<Type_t> Types { get; set; }
        public ObservableCollection<Zakaz> Zakazs { get; set; }
        public ObservableCollection<ZakazSkidka> ZakazSkidkas { get; set; }

        public MainWindow() : this(new ApplicationStorage(new Laba1Context()))
        {
        }

        public MainWindow(IStorage storage)
        {
            InitializeComponent();
            DataContext = this;
            _storage = storage;

            Brons = new ObservableCollection<Bron>();
            Clients = new ObservableCollection<Client>();
            Inventories = new ObservableCollection<Inventory>();
            Skidkas = new ObservableCollection<Skidka>();
            Types = new ObservableCollection<Type_t>();
            Zakazs = new ObservableCollection<Zakaz>();
            ZakazSkidkas = new ObservableCollection<ZakazSkidka>();

            LoadData();
        }

        private void LoadData()
        {
            Brons.Clear();
            Clients.Clear();
            Inventories.Clear();
            Skidkas.Clear();
            Types.Clear();
            Zakazs.Clear();
            ZakazSkidkas.Clear();

            foreach (var bron in _storage.BronRepository.GetAll())
            {
                Brons.Add(bron);
            }

            foreach (var client in _storage.ClientRepository.GetAll())
            {
                Clients.Add(client);
            }

            foreach (var inventory in _storage.InventoryRepository.GetAll())
            {
                Inventories.Add(inventory);
            }

            foreach (var skidka in _storage.SkidkaRepository.GetAll())
            {
                Skidkas.Add(skidka);
            }

            foreach (var typ in _storage.TypeRepository.GetAll())
            {
                Types.Add(typ);
            }

            foreach (var zakaz in _storage.ZakazRepository.GetAll())
            {
                Zakazs.Add(zakaz);
            }

            foreach (var zakazSkidka in _storage.ZakazSkidkaRepository.GetAll())
            {
                ZakazSkidkas.Add(zakazSkidka);
            }
        }


    }

}