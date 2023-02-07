using BuberBreakfast.Context;
using BuberBreakfast.Contracts.Repository;
using BuberBreakfast.Contracts.Service;
using BuberBreakfast.DTO;
using BuberBreakfast.Entities;
using BuberBreakfast.Implementations.Repository;
using BuberBreakfast.Models.Response;

namespace BuberBreakfast.Implementations.Service
{
    public class BreaskFastService : IBreakFastService
    {
        private readonly IBreakFastRepository _breakFastRepository;

        public BreaskFastService(ApplicationContext context,IBreakFastRepository breakFastRepository)
        {
            _breakFastRepository = breakFastRepository;
        }
        public BreakFastResponseModel DeleteBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if(breakfast == null)
            {
                return new BreakFastResponseModel
                { 
                    Message = "Breakfast Not found!!",
                    Status = false
                };
            }
            else
            {
                _breakFastRepository.Delete(id);
                return new BreakFastResponseModel
                { Message = "BreakFast Succesfully deleted",
                  Status = true
                };

            }
        }

        public BreakFastResponseModel GetBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if (breakfast == null )
            {
                return new BreakFastResponseModel
                {
                    Message = "BreakFast not found!!",
                    Status = false
                };
            }
            else
            {
                return new BreakFastResponseModel
                {
                    Data = new BreakFastDto
                    {
                        BreakFastId = breakfast.Id,
                        Name = breakfast.Name,
                        Description = breakfast.Description
                    },
                    Status = true,
                    Message = "BreakFast successfully retrieved"
                };
            }
        }

        public BreakFastsResponseModel PrintAllBreakFast()
        {
            var breakfast = _breakFastRepository.PrintAllBreakFast();
            if (breakfast == null)
            {
                return new BreakFastsResponseModel
                {
                    Status = false,
                    Message = "Breakfast Not Found",
                };
            }
            return new BreakFastsResponseModel
            {
                Data = breakfast,
                Status = true,
                Message = "Breakfast Sucessfully retrieved",
            };
        }

        public BreakFastResponseModel RegisterBreakFast(BreakFastDto request)
        {
            // var checkId = _breakFastRepository.FindBreakFast(request.BreakFastId);
            // if (checkId == null)
            // {
            //     return new BreakFastResponseModel
            //     {
            //         Status = false,
            //         Message = "Breafast not found"
            //     };
            // }
            
            var breakfast = new BreakFast
            {
                Id = request.BreakFastId,
                Name = request.Name,
                Description = request.Description,
                StartDateTime = request.StartDateTime,
                EndDateTime = request.EndDateTime
            };
            _breakFastRepository.Create(breakfast);
            return new BreakFastResponseModel
            {
                Data = new BreakFastDto
                {
                    BreakFastId = breakfast.Id,
                    Name = breakfast.Name,
                    Description = breakfast.Description,
                    StartDateTime = request.StartDateTime,
                    EndDateTime = request.EndDateTime,
                },
                Status = true,
                Message = "Breakfast Registered Successfully",
            };
        }

        public BreakFastResponseModel UpdateBreakFast(int id, UpdateBreakFastDto updateBreakFastDto)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if(breakfast == null)
            {
                return new BreakFastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = true
                };
            }
            else
            {
                breakfast.Id = updateBreakFastDto.Id;
                breakfast.Name = updateBreakFastDto.Name;
                breakfast.Description = updateBreakFastDto.Description;
                _breakFastRepository.Update(id);
                return new BreakFastResponseModel
                {
                  Message= "BreakFast successfully updated",
                  Status =  true
                };
            }
        }
    }
}
