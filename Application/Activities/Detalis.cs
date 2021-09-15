namespace Application.Activities
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using MediatR;
    using Persistance;
    public class Detalis
    {
        public class Query : IRequest<Activity>
        {
        public Guid Id { get; set; }
        }

        public class Hand : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;

            public Hand(DataContext context)
            {
                this._context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this._context.Activities.FindAsync(request.Id);
            }
        }
    }
}
