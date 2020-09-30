using System;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class AbstractEntityDTO
    {
        public Guid Guid { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime LastUpdated { get; set; }
    }
}