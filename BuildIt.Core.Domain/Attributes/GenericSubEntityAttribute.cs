using System;

namespace BuildIt.Core.Domain.Attributes
{
    [GenericSubEntity(Keys = new []{ "", "" })]
    public class GenericSubEntityAttribute : Attribute
    {
        public string[] Keys { get; set; }
    }
}