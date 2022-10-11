using System.ComponentModel.DataAnnotations.Schema;
using Common.Query;

namespace Shop.Query._Context.Models;

[Table("Users", Schema = "user")]
class UserQueryModel : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
}