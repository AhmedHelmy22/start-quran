using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using System.Threading.Tasks;

namespace StartQuran.Service.TaxService
{
    public class TaxManager
    {
        private readonly IRepository<Tax> _Tax;

        public TaxManager(IRepository<Tax> Tax)
        {
            _Tax = Tax;
           
        }


        public Tax Get()
        {
            var tax = _Tax.FirstOrDefault(c => c.IsDeleted == false).Result;
            return tax ;
        }


        public async Task<Tax> Tax_Update(Tax model)
        {
            var Tax = _Tax.FirstOrDefault(c => c.ID == model.ID).Result;
            Tax.tax = model.tax;
            

            await _Tax.Update(Tax);
            return Tax;
        }

    }
}
