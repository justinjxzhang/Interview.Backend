namespace Interview.Backend.Data.Models;

public class Ticket {
    public Guid Id { get; set; }
    public Guid CompanyId { get; set;}
    public Guid ReporterId { get; set; }
    public string Description { get; set; } = string.Empty;
}