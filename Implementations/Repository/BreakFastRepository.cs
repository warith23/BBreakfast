using BuberBreakfast.Context;
using BuberBreakfast.DTO;
using BuberBreakfast.Contracts.Repository;
using BuberBreakfast.Entities;
using System.Xml.Linq;

namespace BuberBreakfast.Implementations.Repository
{
    public class BreakFastRepository : IBreakFastRepository
    {
        private readonly ApplicationContext  _context;
        public BreakFastRepository(ApplicationContext context) 
        {
            _context = context;
        }
       

        public bool BreakFastExist(int id)
        {
            return _context.BreakFasts.Any(bf => bf.Id == id);
        }

        public bool BreakFastExist(string name)
        {
            return _context.BreakFasts.Any(bf => bf.Name == name);
        }

        public BreakFast Create(BreakFast breakfast)
        {
            _context.BreakFasts.Add(breakfast);
            _context.SaveChanges();
            return breakfast;
        }

        public bool Delete(int id)
        {
            var breakfast = GetById(id);
            _context.BreakFasts.Remove(breakfast);
            return true;
        }

        public BreakFast FindBreakFast(int id)
        {
            var breakfast = _context.BreakFasts.Find(id);
            return breakfast;
        }

        public List<BreakFast> PrintAllBreakFast()
        {
            var breakfasts = _context.BreakFasts.Select(user => new BreakFast
            {
                Id = user.Id,
                Name = user.Name,
                Description = user.Description
            }).ToList();
            return breakfasts;
        }

        public BreakFast GetById(int id)
        {
            var breakfast = _context.BreakFasts.SingleOrDefault(User => User.Id == id);
            return breakfast;
        }

        public BreakFast Update(int id)
        {
            var breakfast = GetById(id);
            _context.BreakFasts.Update(breakfast);
            _context.SaveChanges();
            return breakfast;
        }
    }
}
