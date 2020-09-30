using System;
using System.ComponentModel.DataAnnotations;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class AbstractEntity
    {
        [Key] public Guid Guid { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}