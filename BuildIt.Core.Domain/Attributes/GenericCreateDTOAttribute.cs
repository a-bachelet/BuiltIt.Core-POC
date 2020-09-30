using System;

namespace BuildIt.Core.Domain.Attributes
{
    public class GenericCreateDTOAttribute : Attribute
    {
        public GenericCreateDTOAttribute(Type dtoType)
        {
            DTOType = dtoType;
        }
        
        public Type DTOType { get; set; }
    }
}