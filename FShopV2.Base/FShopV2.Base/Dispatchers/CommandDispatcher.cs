using System.Threading.Tasks;
using Autofac;
using FShopV2.Base.Handlers;
using FShopV2.Base.Messages;
//using FShopV2.Base.RabbitMq;

namespace FShopV2.Base.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command);
    }
}