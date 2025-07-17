using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Features.ConsultantProfiles.Queries;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.SharedKernel.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Features.ConsultantProfiles.Handlers
{
    public class GetConsultantProfileByConsultantIdHandler
    : IRequestHandler<GetConsultantProfileByConsultantIdQuery, Result<ConsultantProfileDto>>
    {
        private readonly IConsultantProfileRepository _repository;
        private readonly IMapper _mapper;

        public GetConsultantProfileByConsultantIdHandler(IConsultantProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ConsultantProfileDto>> Handle(GetConsultantProfileByConsultantIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _repository.GetByConsultantIdAsync(request.ConsultantId, cancellationToken);
            if (profile is null)
                return Result<ConsultantProfileDto>.Fail("Profil bulunamadı.");

            var dto = _mapper.Map<ConsultantProfileDto>(profile);
            return Result<ConsultantProfileDto>.Ok(dto);
        }
    }
}
