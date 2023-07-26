using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.MarketerService;
using StartQuran.Service.MarketerService.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tarteel.Service.RegisterService
{
    public class RegisterManager
    {

        private readonly IRepository<RegistrationFamily> _RegistrationFamily;
        private readonly MarketerManager _MarketerManager;
        public RegisterManager(IRepository<RegistrationFamily> RegistrationFamily, MarketerManager MarketerManager)
        {
            _RegistrationFamily = RegistrationFamily;
            _MarketerManager = MarketerManager;

        }

        #region RegistrationFamily
        //---------RegistrationFamily--------------
        #region Get

        public IEnumerable<RegistrationFamily> GetAll()
        {
            return _RegistrationFamily.GetAll(x=>x.FullName!=null,"");
        }

        
        public RegistrationFamily Get(Guid Id)
        {
            return _RegistrationFamily.FirstOrDefault(c => c.ID == Id).Result;
        }
        #endregion


        public async Task<RegistrationFamily> RegistrationFamily_Create(RegistrationFamily model)
        {


            try
            {
                model.ID = Guid.NewGuid();
                await _RegistrationFamily.Add(model);

                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
            
        }

        public async Task<RegistrationFamily> RegistrationFamily_Update(RegistrationFamily model)
        {
            var RegistrationFamily = _RegistrationFamily.FirstOrDefault(c => c.ID == model.ID).Result;
            RegistrationFamily.FullName = model.FullName;
            RegistrationFamily.PhoneNumber = model.PhoneNumber;
            RegistrationFamily.WhatsApp = model.WhatsApp;
            RegistrationFamily.state = model.state;
            RegistrationFamily.Message = model.Message;
            RegistrationFamily.CountryCode = model.CountryCode;
            await _RegistrationFamily.Update(RegistrationFamily);
            return RegistrationFamily;
        }

        public async Task<RegistrationFamily> RegistrationFamily_Delete(Guid id)
        {
            var RegistrationFamily = _RegistrationFamily.FirstOrDefault(c => c.ID == id).Result;
            await _RegistrationFamily.Remove(RegistrationFamily);
            return RegistrationFamily;
        }


        public async Task<RegistrationFamily> RegistrationFamily_read(Guid id)
        {
            var RegistrationFamily = _RegistrationFamily.FirstOrDefault(c => c.ID == id).Result;
            RegistrationFamily.Read = true;
            await _RegistrationFamily.Update(RegistrationFamily);
            return RegistrationFamily;
        }

        #endregion

        #region Helper

 
      
        #endregion
    }
}
