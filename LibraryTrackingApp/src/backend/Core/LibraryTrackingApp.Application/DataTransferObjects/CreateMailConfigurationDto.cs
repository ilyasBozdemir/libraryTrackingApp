﻿namespace LibraryTrackingApp.Application.DataTransferObjects;

public record CreateMailConfigurationDto : BaseAuditableDTO<Guid>
{
    public string Owner { get; set; }
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public string SenderEmail { get; set; }
    public string SenderName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
