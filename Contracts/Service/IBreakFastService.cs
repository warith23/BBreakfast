using BuberBreakfast.DTO;
using BuberBreakfast.Entities;
using BuberBreakfast.Models.Response;

namespace BuberBreakfast.Contracts.Service
{
    public interface IBreakFastService
    {
        BreakFastResponseModel RegisterBreakFast(BreakFastDto request);
        BreakFastResponseModel GetBreakFast(int id);
        BreakFastResponseModel DeleteBreakFast(int id);
        BreakFastResponseModel UpdateBreakFast(int id, UpdateBreakFastDto updateBreakFastDto);
        BreakFastsResponseModel PrintAllBreakFast();
    }
}
