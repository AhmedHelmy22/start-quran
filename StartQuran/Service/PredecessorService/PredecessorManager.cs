using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartQuran.Service.PredecessorService
{
    public class PredecessorManager
    {
        private readonly IRepository<Predecessor> _Predecessor;

        public PredecessorManager(IRepository<Predecessor> Predecessor)
        {
            _Predecessor = Predecessor;

        }

        #region Predecessor
        //---------Predecessor--------------
        #region Get

        public IEnumerable<Predecessor> GetAll()
        {
            return _Predecessor.GetAll(c => c.IsDeleted == false,"Teacher");
        }

        public Predecessor Get(Guid Id)
        {
            return _Predecessor.FirstOrDefault(c => c.IsDeleted == false && c.ID == Id).Result;
        }
        #endregion


        public async Task<Predecessor> Predecessor_Create(Predecessor model)
        {
            model.ID = Guid.NewGuid();
            await _Predecessor.Add(model);
            return model;
        }

        public async Task<Predecessor> Predecessor_Update(Predecessor model)
        {
            var Predecessor = _Predecessor.FirstOrDefault(c => c.ID == model.ID).Result;
            Predecessor.EditDate = DateTime.Now;
            Predecessor.TeacherId = model.TeacherId;
            Predecessor.Cash = model.Cash;
            Predecessor.Note = model.Note;
            Predecessor.Date = model.Date;

            await _Predecessor.Update(Predecessor);
            return Predecessor;
        }

        public async Task<Predecessor> Predecessor_Delete(Guid id)
        {
            var Predecessor = _Predecessor.FirstOrDefault(c => c.ID == id).Result;
            Predecessor.DeleteDate = DateTime.Now;
            Predecessor.IsDeleted = true;
            await _Predecessor.Remove(Predecessor);
            return Predecessor;
        }
        #endregion
    }
}
