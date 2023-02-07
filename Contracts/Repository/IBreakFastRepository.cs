using BuberBreakfast.Entities;

namespace BuberBreakfast.Contracts.Repository
{
    public interface IBreakFastRepository
    {
        BreakFast Create(BreakFast breakfast);
        BreakFast GetById(int id);
       List<BreakFast> PrintAllBreakFast();
        BreakFast FindBreakFast(int id);
        BreakFast Update(int id);
        bool Delete(int id);
        bool BreakFastExist(int id);
        bool BreakFastExist(string name);
    }
}
