namespace AppointmentTracking.SharedKernel.Results;

public class FailResponse
{
    public string Message { get; set; } = "İşlem başarısız.";
    public List<string>? Errors { get; set; }
    public string? Code { get; set; }
}
