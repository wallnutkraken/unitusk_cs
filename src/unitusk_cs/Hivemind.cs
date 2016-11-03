using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public Thread StartSendThread(TimeSpan sendMessagePeriod)
        {
            Thread sendThread = new Thread(SendLoop);
            sendThread.Start(sendMessagePeriod);
            return sendThread;
        }

        private void SendLoop(object timespan)
        {
            TimeSpan msgPeriod = (TimeSpan) timespan;

            while (true)
            {
                Thread.Sleep(msgPeriod);
                foreach (IEndpointProvider endpointProvider in manager.Endpoints)
                {
                    try
                    {
                        Message msg = endpointProvider.Queue.Take();
                        endpointProvider.Send(msg);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
