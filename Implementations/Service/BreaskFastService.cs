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

        public BreaskFastService(IBreakFastRepository breakFastRepository)
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
           
            _breakFastRepository.Delete(id);
            return new BreakFastResponseModel
            { 
                Message = "BreakFast Succesfully deleted",
                Status = true
            };
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
           
            return new BreakFastResponseModel
            {
                Data = new BreakFastDto
                {
                    BreakFastId = breakfast.Id,
                    Name = breakfast.Name,
                    Description = breakfast.Description,
                    StartDateTime = breakfast.StartDateTime,
                    EndDateTime = breakfast.EndDateTime
                },
                Status = true,
                Message = "BreakFast successfully retrieved"
            };
           
        }

        public BreakFastsResponseModel PrintAllBreakFast()
        {
            var breakfast = _breakFastRepository.PrintAllBreakFast();
            var response = new BreakFastsResponseModel();
            if (breakfast == null)
            {
                return new BreakFastsResponseModel
                {
                    Status = false,
                    Message = "Breakfast Not Found",
                };
            }
            response.Data = breakfast.Select(b => new BreakFastDto
            {
                BreakFastId = b.Id,
                Name = b.Name,
                Description = b.Description
            }).ToList();
            response.Status  = true;
            response.Message = "Breakfast Sucessfully retrieved";
            return response;
            // return new BreakFastsResponseModel
            // {
            //     Data = breakfast,
            //     Status = true,
            //     Message = "Breakfast Sucessfully retrieved",
            // };
        }

        public BreakFastResponseModel RegisterBreakFast(BreakFastDto request)
        {
            var checkId = _breakFastRepository.GetById(request.BreakFastId);
            var response = new BreakFastResponseModel();
            if (checkId != null)
            {
                // return new BreakFastResponseModel
                // {
                //     Status = false,
                //     Message = "Breafast exists",
                // };
                response.Message = "Breafast exists";
                return response;
            }
            
            var breakfast = new BreakFast
            {
                Id = request.BreakFastId,
                Name = request.Name,
                Description = request.Description,
                StartDateTime = request.StartDateTime,
                EndDateTime = request.EndDateTime
            };
            try
            {
                _breakFastRepository.Create(breakfast);
            }
            catch (Exception e)
            {
                response.Message = $"An Error occurred: {e.Message}";
                return response;
            }
            response.Message = "Breakfast created Succesfully";
            response.Status = true;
            return response;
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

        //_breakFastRepository.Create(breakfast);
            // return new BreakFastResponseModel
            // {
            //     Data = new BreakFastDto
            //     {
            //         Name = breakfast.Name,
            //         Description = breakfast.Description,
            //         StartDateTime = breakfast.StartDateTime,
            //         EndDateTime = breakfast.EndDateTime,
            //     },
            //     Status = true,
            //     Message = "Breakfast Registered Successfully",
            // };
    }
}