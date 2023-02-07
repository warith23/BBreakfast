using System;
using System.Collections.Generic;
using System.Linq;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Models.Response
{
    public class BreakFastsResponseModel : BaseResponseModel
    {
        public IList<BreakFast> Data { get; set; }
    }
}