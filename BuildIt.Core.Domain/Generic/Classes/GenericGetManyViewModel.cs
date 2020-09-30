using System.Collections.Generic;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericGetManyViewModel<T> where T : class, new()
    {
        public int Page { get; set; }

        public int Count { get; set; }

        public ICollection<T> Data { get; set; }
    }
}