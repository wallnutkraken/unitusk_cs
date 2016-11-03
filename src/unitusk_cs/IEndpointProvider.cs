using System;
using System.Collections.Generic;

namespace unitusk_cs
{
    public interface IEndpointProvider
    {
        /// <summary>
        /// Gets new messages from this endpoint
        /// </summary>
        IEnumerable<Message> GetMessages();
        /// <summary>
        /// Returns a reference to this endpoint's SendQueue
        /// </summary>
        SendQueue Queue { get; }
        /// <summary>
        /// Returns all the errors that have occurred from Send() being called.
        /// Do note that your code has to store errors from Send() in-object, and
        /// retrieve them here.
        /// </summary>
        IEnumerable<Exception> Errors();
    }
}
