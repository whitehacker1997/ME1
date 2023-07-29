using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.CountryServices
{
    public class CountryService :
        StatusGenericHandler,
        ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICountryRepository repository;

        public CountryService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.CountryRepository;
        }

        public PagedResult<CountryListDto> GetList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<CountryListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetAsSelectList()
            => repository.AllAsQueryable
                            .AsSelectList();

        public CountryDto GetCountry()
            => new CountryDto(); 

        public CountryDto GetCountryById(int Id)
        {
            var countryDto =
                repository.ById<CountryDto>(Id);

            CombineStatuses(repository);
            
            if (HasErrors)
                return null;

            return countryDto;
        }
        
        public HaveId<int> CreateCountry(CreateCountryDlDto dto)
        {
            var entity = 
                repository.Create(dto);

            CombineStatuses(repository);

            if (IsValid)
            {
                unitOfWork.Save();
                return HaveId.Create(entity.Id);
            }

            return null;
        }
        
        public void UpdateCountry(UpdateCountryDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();        
        }

        public void DeleteCountry(int Id)
        {
            try
            {
                repository.Delete(Id);
                CombineStatuses(repository);

                if (IsValid)
                    unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
