using System;
using System.Collections.Generic;
using System.Linq;

namespace unitusk_cs
{
    public class Hivemind
    {
        private EndpointManager manager;

        public Hivemind()
        {
            manager = new EndpointManager();
        }

        public void UpdateAndFeed()
        {
            throw new NotImplementedException();
        }

        public void QueueToAll(Message message)
        {
            manager.QueueToAll(message);
        }

        public IEnumerable<Exception> Errors()
        {
            return manager.Endpoints.SelectMany(man => man.Errors());
        }

        public void AddEndpoint(IEndpointProvider endpoint)
        {
            manager.AddEndpoint(endpoint);
        }

        public void RemoveEndpoint(IEndpointProvider endpoint)
        {
            manager.RemoveEndpoint(endpoint);
        }
    }
}
