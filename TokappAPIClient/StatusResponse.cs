using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TokappAPIClient
{
    /// <summary>
    /// Data returned by a <c>status</c> command.
    /// </summary>
    public class StatusResponse
    {
        /// <summary>
        /// Maximun number of different contacts that you can send messages within the actual natural month.
        /// </summary>
        public int maxContacts { get; set; }

        /// <summary>
        /// Maximun number of messages that you may send in the actual natural day. A zero value indicates that there are no limit.
        /// </summary>
        public int maxMessages { get; set; }

        /// <summary>
        /// Number of different contacts at which was sent messages in the actual natural month.
        /// </summary>
        public int contactsSent { get; set; }

        /// <summary>
        /// Number of messages sent today.
        /// </summary>
        public int messagesSent { get; set; }

        /// <summary>
        /// Shows by false or true if it is possible to send more than one message per petition by send command.
        /// </summary>
        public bool multiSend { get; set; }

        /// <summary>
        /// Shows by false or true if <c>getcontacts</c> command is available.
        /// </summary>
        public bool getContacts { get; set; }

        /// <summary>
        /// Shows by false or 1 true if service is available.
        /// </summary>
        public bool available { get; set; }

        /// <summary>
        /// Create an instance of <see cref="StatusResponse"/> from a response object.
        /// </summary>
        /// <param name="response">Response object.</param>
        /// <returns>Instance created.</returns>
        public static StatusResponse CreateInstance(ResponseBase response) {
            var instance = new StatusResponse()
            {
                maxContacts = response.data.maxContacts,
                maxMessages = response.data.maxMessages,
                contactsSent = response.data.contactsSent,
                messagesSent = response.data.messagesSent,
                multiSend = (response.data.multiSend == 1),
                getContacts = (response.data.getContacts == 1),
                available = (response.data.available == 1)
            };
            return instance;
        }
    }
}
