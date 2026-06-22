using System.ComponentModel.DataAnnotations;

namespace HiSUP.Models;

public class AcademicProgram
{
    [Key]
    public int ProgramID { get; set; }

    [Required]
    [StringLength(100)]
    public string ProgramName { get; set; } = "";

    [Required]
    [StringLength(20)]
    public string ProgramCode { get; set; } = "";

    public int DepartmentID { get; set; }

    [StringLength(20)]
    public string? DegreeLevel { get; set; }

    public int? DurationYears { get; set; }

    public int? TotalCreditHours { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? CreatedAt { get; set; }
}