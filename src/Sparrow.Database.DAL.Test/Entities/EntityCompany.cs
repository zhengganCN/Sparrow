using Sparrow.Database.EntityInfo;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.Database.DAL.Test.Entities
{
    public class EntityCompany : Entity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
