using Sparrow.Database.EntityInfo;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.Database.DAL.Test.Entities
{
    public class EntitySchool : Entity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
