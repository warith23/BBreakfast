using BuberBreakfast.DTO;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Models.Response
{
    public class BreakFastsResponseModel : BaseResponseModel
    {
        public IList<BreakFastDto> Data { get; set; }
    }
}