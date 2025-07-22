using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.Services.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.Services.Handlers
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, Result<List<ServiceDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllServicesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            var dtos = _mapper.Map<List<ServiceDto>>(services);

            return Result<List<ServiceDto>>.Ok(dtos);
        }
    }
}
