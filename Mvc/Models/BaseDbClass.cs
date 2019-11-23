using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc.Models
{
    public class BaseDbClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}