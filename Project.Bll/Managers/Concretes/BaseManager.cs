using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : BaseDto where U : class, IEntity
    {
        readonly IRepository<U> _repository;
        readonly protected IMapper _mapper;

        protected BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = Entities.Enums.DataStatus.Inserted;

            U domainEntity = _mapper.Map<U>(entity);
            await _repository.CreateAsync(domainEntity);

        }

        public async Task CreateRangeAsync(List<T> list)
        {
            foreach (T item in list) await CreateAsync(item);
        }

        public List<T> GetActives()
        {
            IQueryable<U> values = _repository.Where(x => x.Status != Entities.Enums.DataStatus.Deleted);
            List<U> valueList = values.ToList();
            return _mapper.Map<List<T>>(valueList);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<U> values = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(value);
        }

        public List<T> GetModifieds()
        {
            IQueryable<U> values = _repository.Where(x => x.Status == Entities.Enums.DataStatus.Updated);
            List<U> valueList = values.ToList();
            return _mapper.Map<List<T>>(valueList);
        }

        public List<T> GetPassives()
        {
            IQueryable<U> values = _repository.Where(x => x.Status == Entities.Enums.DataStatus.Deleted);
            List<U> valueList = values.ToList();
            return _mapper.Map<List<T>>(valueList);
        }

        public async Task MakePassiveAsync(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Status = Entities.Enums.DataStatus.Deleted;
            U newValue = _mapper.Map<U>(entity);
            U originalValue = await _repository.GetByIdAsync(newValue.Id);
            await _repository.UpdateAsync(originalValue, newValue);
        }

        public async Task<string> RemoveAsync(T entity)
        {
            //Once silinmek istenen verinin pasife cekilip cekilmedigini kontrol edecegiz. Sadece pasife cekilmis veriler silinecek.
            if (entity.Status != Entities.Enums.DataStatus.Deleted)
            {
                return "Silme islemi sadece pasif veriler uzerinden yapilir.";
            }
            U originalValue = await _repository.GetByIdAsync(entity.Id);
            await _repository.RemoveAsync(originalValue);
            return $"Silme islemi gerceklestirildi. Silinen id : {entity.Id}";
        }

        public async Task<string> RemoveRangeAsync(List<T> list)
        {
            if (list.Any(x => x.Status != Entities.Enums.DataStatus.Deleted))
            {
                return "Listenizdeki statusu pasif olmayan veriler bulunmektadir. Lutfen kontrol ediniz";
            }

            foreach (T item in list) await RemoveAsync(item);

            return "Liste silinmistir";
        }

        public async Task UpdateAsync(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.Status = Entities.Enums.DataStatus.Updated;
            U newValue = _mapper.Map<U>(entity);
            U originalValue = await _repository.GetByIdAsync(newValue.Id);
            await _repository.UpdateAsync(originalValue, newValue);
        }

        public async Task UpdateRangeAsync(List<T> list)
        {
            foreach (T item in list) await UpdateAsync(item);
        }
    }
}
