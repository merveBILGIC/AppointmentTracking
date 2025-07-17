using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.ConsultantProfiles.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Handlers
{
    public class GetAllConsultantProfilesHandler
    : IRequestHandler<GetAllConsultantProfilesQuery, Result<List<ConsultantProfileDto>>>
    {
        private readonly IConsultantProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetAllConsultantProfilesHandler(IConsultantProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ConsultantProfileDto>>> Handle(GetAllConsultantProfilesQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _repository.GetAllAsync(cancellationToken);
            var dtoList = _mapper.Map<List<ConsultantProfileDto>>(profiles);
            return Result<List<ConsultantProfileDto>>.Ok(dtoList);
        }
    }
}
