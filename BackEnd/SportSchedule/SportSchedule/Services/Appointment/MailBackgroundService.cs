namespace SportSchedule.Services.Appointment
{
    public class MailBackgroundService : BackgroundService
    {
        private readonly ILogger<MailBackgroundService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MailBackgroundService(ILogger<MailBackgroundService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Sending data at: { time}", DateTime.Now);
                using(var scope = _serviceScopeFactory.CreateScope())
                {
                    var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();
                    var appointments = await appointmentService.getAppointments();
                    if (appointments != null)
                    {
                        foreach (var appointment in appointments)
                        {
                            await appointmentService.SendEmailAsync(appointment?.Email!, appointment?.MatchId ?? 0);
                            await appointmentService.UpdateAppointment(appointment?.AppointmentId ?? 0);
                        }
                    }
                }
                
                await Task.Delay(TimeSpan.FromHours(5), stoppingToken);
            }
        }
    }
}
