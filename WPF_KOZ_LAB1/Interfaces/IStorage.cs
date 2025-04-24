using WPF_KOZ_LAB1.Models;
using WPF_KOZ_LAB1.ViewModels;

public interface IStorage
{
    IRepository<Bron> BronRepository { get; }
    IRepository<Client> ClientRepository { get; }
    IRepository<Inventory> InventoryRepository { get; }
    IRepository<Skidka> SkidkaRepository { get; }
    IRepository<Type_t> TypeRepository { get; }
    IRepository<Zakaz> ZakazRepository { get; }
    IRepository<ZakazSkidka> ZakazSkidkaRepository { get; }
}
