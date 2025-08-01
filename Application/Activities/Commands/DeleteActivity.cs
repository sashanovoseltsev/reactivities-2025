using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class DeleteActivity
    {
        public class Command : IRequest
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activityToDelete = await context.Activities.FindAsync(
                    [request.Id],
                    cancellationToken
                );

                if (activityToDelete == null)
                    return;

                context.Activities.Remove(activityToDelete);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
