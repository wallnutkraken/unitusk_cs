using System;
using System.Collections.Generic;

namespace unitusk_cs
{
    public class SendQueue
    {
        private Queue<Message> _msgQueue;

        public SendQueue()
        {
            Clear();
        }

        public void Clear()
        {
            _msgQueue = new Queue<Message>();
        }

        public void Add(Message msg)
        {
            _msgQueue.Enqueue(msg);
        }

        ///<exception cref="InvalidOperationException"></exception>
        internal Message Take()
        {
            return _msgQueue.Dequeue();
        }
    }
}
