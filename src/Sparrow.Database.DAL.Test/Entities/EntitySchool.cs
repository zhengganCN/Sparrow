using Sparrow.Database.EntityInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sparrow.Database.DAL.Test.Entities
{
    internal class EntitySchool : Entity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
