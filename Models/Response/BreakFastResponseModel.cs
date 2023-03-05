using BuberBreakfast.DTO;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Models.Response
{
    public class BreakFastResponseModel : BaseResponseModel
    {
        public BreakFastDto Data { get; set; }
    }
}
