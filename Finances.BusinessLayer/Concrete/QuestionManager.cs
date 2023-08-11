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
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;
        private readonly IUowDal _uowDal;

        public QuestionManager(IQuestionDal questionDal, IUowDal uowDal)
        {
            _questionDal = questionDal;
            _uowDal = uowDal;
        }

        public void TAdd(Question entity)
        {
            _questionDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Question entity)
        {
            _questionDal.Delete(entity);
            _uowDal.Save();
        }

        public Question TGetByID(int id)
        {
            return _questionDal.GetByID(id);

        }

        public List<Question> TGetList()
        {
            return _questionDal.GetList();
        }

        public void TMultiUpdate(List<Question> entities)
        {
            _questionDal.MultiUpdate(entities);
            _uowDal.Save();
        }

        public void TUpdate(Question entity)
        {
            _questionDal.Update(entity);
            _uowDal.Save();
        }
    }
}
