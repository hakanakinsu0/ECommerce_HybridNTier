using Project.Bll.DtoClasses;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IManager<T,U> where T : BaseDto where U : class,IEntity
    {
        //Busines Logic For Queries
        Task<List<T>> GetAllAsync(); //Butun verileri getiren
        Task<T> GetByIdAsync(int id); //Id'e gore getiren sistem
        List<T> GetActives(); //Aktifleri getiren sistem
        List<T> GetPassives(); //Pasifleri getiren sistem
        List<T> GetModifieds(); //Guncellenmis olanlari getiren sistem

        //Business Logic For Commands
        Task CreateAsync(T entity); //ekle
        Task UpdateAsync(T entity); //guncelle
        Task<string> RemoveAsync(T entity); //sil ve geriye string dondur.
        Task MakePassiveAsync(T entity); //Pasife ceke.

        Task CreateRangeAsync(List<T> list);
        Task UpdateRangeAsync(List<T> list);
        Task<string> RemoveRangeAsync(List<T> list);
    }
}
