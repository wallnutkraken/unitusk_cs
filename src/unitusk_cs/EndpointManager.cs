using System.Collections.Generic;
using System.Linq;

namespace unitusk_cs
{
    internal class EndpointManager
    {
        private List<IEndpointProvider> _providers;

        internal EndpointManager()
        {
            _providers = new List<IEndpointProvider>();
        }

        internal IEnumerable<IEndpointProvider> Endpoints => _providers;

        internal void QueueToAll(Message message)
        {
            _providers.ForEach(provider => provider.Queue.Add(message));
        }

        internal void AddEndpoint(IEndpointProvider endpoint)
        {
            _providers.Add(endpoint);
        }

        internal void RemoveEndpoint(IEndpointProvider endpoint)
        {
            _providers.Remove(endpoint);
        }

        internal IEnumerable<Message> GatherUpdates()
        {
            /* I fucking love LINQ */
            return _providers.SelectMany(prov => prov.GetMessages());
        }
    }
}
