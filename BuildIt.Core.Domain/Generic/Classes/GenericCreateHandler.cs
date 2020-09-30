using System.Threading;
using System.Threading.Tasks;
using BuildIt.Core.Domain.Database;
using MediatR;

namespace BuildIt.Core.Domain.Generic.Classes
{
    public class GenericCreateHandler<TCommand, T> : IRequestHandler<TCommand, GenericCreateViewModel<T>>
        where TCommand : GenericCreateCommand<T>
        where T : class, new()
    {
        private readonly GenericDbContext _context;

        public GenericCreateHandler(GenericDbContext context)
        {
            _context = context;
        }

        public async Task<GenericCreateViewModel<T>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var data = request.Data;

            await _context.Set<T>().AddAsync(data, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.Run(() => new GenericCreateViewModel<T>
            {
                Data = data
            }, cancellationToken);
        }
    }
}