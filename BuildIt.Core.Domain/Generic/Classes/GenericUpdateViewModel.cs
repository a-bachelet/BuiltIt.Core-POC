namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericUpdateViewModel<T> where T : class, new()
    {
        public T Data { get; set; }
    }
}