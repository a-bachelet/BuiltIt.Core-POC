namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericCreateViewModel<T> where T : class, new()
    {
        public T Data { get; set; }
    }
}