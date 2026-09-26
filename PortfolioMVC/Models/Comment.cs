using System.ComponentModel.DataAnnotations;

public class Comment
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Message { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}