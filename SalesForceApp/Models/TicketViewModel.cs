// TicketViewModel.cs
using System.ComponentModel.DataAnnotations;

public class TicketViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Mobile { get; set; }

    [Required]
    public string Problem { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string StatusCode { get; set; }

    [Required]
    public long UserId { get; set; }
}
