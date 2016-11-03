using System;
using System.Collections.Generic;
using System.Linq;
using unitusk_cs.Markov;

namespace unitusk_cs
{
    public class Hivemind
    {
        private EndpointManager manager;
        private Chain _markov;

        public Hivemind(int chainLength)
        {
            manager = new EndpointManager();
            _markov = new Chain(chainLength);
        }

        public void UpdateAndFeed()
        {
            _markov.Feed(string.Join("\n", manager.GatherUpdates().Select(update => update.Text)));
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
