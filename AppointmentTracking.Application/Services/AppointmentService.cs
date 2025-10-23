using AppointmentTracking.Application.DTOs;
using AppointmentTracking.Application.Interfaces;
using AppointmentTracking.Domain.Entities;
using AppointmentTracking.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTracking.Application.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<Guid>> CreateAsync(CreateAppointmentRequest req, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = new Appointment
                {
                    Id = Guid.NewGuid(),
                    ClientId = req.ClientId,
                    ConsultantId = req.ConsultantId,
                    ServiceId = req.ServiceId,
                    StartTime = req.StartTime,
                    EndTime = req.EndTime,
                    Price = req.Price,
                    Notes = req.Notes
                };

                await _repo.AddAsync(entity, cancellationToken);
                return Result<Guid>.Ok(entity.Id, "Randevu başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                return Result<Guid>.Fail("Randevu oluşturulurken hata oluştu.", new List<string> { ex.Message });
            }
        }

        public async Task<Result<List<AppointmentDto>>> GetAllAsync()
        {
            try
            {
                var items = await _repo.GetAllAsync();

                var dtos = items.Cast<Appointment>().Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    ClientName = a.Client.FullName,
                    ConsultantName = a.Consultant.Name,
                    ServiceName = a.Service.Name,
                    StartTime = a.StartTime,
                    Price = a.Price
                }).ToList();

                return Result<List<AppointmentDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                return Result<List<AppointmentDto>>.Fail("Randevular alınırken hata oluştu.", new List<string> { ex.Message });
            }
        }
    }
}
