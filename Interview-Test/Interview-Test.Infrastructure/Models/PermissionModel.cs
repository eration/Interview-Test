using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview_Test.Models;

[Table("PermissionTb")]
public class PermissionModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PermissionId { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string PermissionName { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }
    public ICollection<RoleModel>? Roles { get; set; }
}