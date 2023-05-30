using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace lp_task.Models;

public class FavoriteMovie
{
    [Key]
    [Column(Order = 1)]
    public string IdUser { get; set; }
    
    [Key]
    [Column(Order = 2)]
    public string IdMovie { get; set; }

    [ForeignKey("IdUser")]
    public virtual VodUser User { get; set; }

    [ForeignKey("IdMovie")]
    public virtual Movie Movie { get; set; }
}