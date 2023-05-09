using System.ComponentModel.DataAnnotations.Schema;

namespace BetaStore.Domain.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
