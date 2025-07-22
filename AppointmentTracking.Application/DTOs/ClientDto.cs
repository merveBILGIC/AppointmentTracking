namespace AppointmentTracking.Application.DTOs;

public record ClientDto(Guid Id, string FullName, string Email, string Phone);
