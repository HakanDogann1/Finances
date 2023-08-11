using Finances.BusinessLayer.Abstract;
using Finances.DataAccessLayer.Abstract;
using Finances.DataAccessLayer.UnitOfWork;
using Finances.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;
        private readonly IUowDal _uowDal;

        public TeamManager(ITeamDal teamDal, IUowDal uowDal)
        {
            _teamDal = teamDal;
            _uowDal = uowDal;
        }

        public void TAdd(Team entity)
        {
            _teamDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Team entity)
        {
            _teamDal.Delete(entity);
            _uowDal.Save();
        }

        public Team TGetByID(int id)
        {
            return _teamDal.GetByID(id);
        }

        public List<Team> TGetList()
        {
            return _teamDal.GetList();
        }

        public void TMultiUpdate(List<Team> entities)
        {
            _teamDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Team entity)
        {
            _teamDal.Update(entity);
            _uowDal.Save();
        }
    }
}
