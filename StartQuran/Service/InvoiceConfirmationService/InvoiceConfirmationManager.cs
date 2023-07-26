using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.InvoiceConfirmationService
{
    public class InvoiceConfirmationManager
    {
        private readonly IRepository<InvoiceConfirmation> _InvoiceConfirmation;

        public InvoiceConfirmationManager(IRepository<InvoiceConfirmation> InvoiceConfirmation)
        {
            _InvoiceConfirmation = InvoiceConfirmation;
           
        }

        #region InvoiceConfirmation
        //---------InvoiceConfirmation--------------
        #region Get
       
        public IEnumerable<InvoiceConfirmation> GetAll()
        {
            return _InvoiceConfirmation.Get(c => c.IsDeleted == false);
        }

        public InvoiceConfirmation Get(Guid Id)
        {
            return _InvoiceConfirmation.FirstOrDefault(c => c.IsDeleted == false&&c.ID==Id).Result;
        }
        #endregion


        public async Task<InvoiceConfirmation> InvoiceConfirmation_Create(InvoiceConfirmation model)
        {
            model.ID = Guid.NewGuid();
            await _InvoiceConfirmation.Add(model);
            return model;
        }

        public async Task<InvoiceConfirmation> InvoiceConfirmation_Update(InvoiceConfirmation model)
        {
            var InvoiceConfirmation = _InvoiceConfirmation.FirstOrDefault(c => c.ID == model.ID).Result;
            InvoiceConfirmation.EditDate = DateTime.Now;
            InvoiceConfirmation.InvoiceDate = model.InvoiceDate;
            await _InvoiceConfirmation.Update(InvoiceConfirmation);
            return InvoiceConfirmation;
        }

        public async Task<InvoiceConfirmation> InvoiceConfirmation_Delete(Guid id)
        {
            var InvoiceConfirmation = _InvoiceConfirmation.FirstOrDefault(c => c.ID == id).Result;
            InvoiceConfirmation.DeleteDate = DateTime.Now;          
            InvoiceConfirmation.IsDeleted = true;
            await _InvoiceConfirmation.Remove(InvoiceConfirmation);
            return InvoiceConfirmation;
        }
        #endregion
    }
}
