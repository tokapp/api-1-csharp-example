using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokappAPIClient
{
    /// <summary>
    /// Data for messages received on <c>getmessages</c> command.
    /// </summary>
    public class GetMessagesResponse
    {

        /// <summary>
        /// date/time in which message was received by system.
        /// </summary>
        public DateTime time { get; set; }

        /// <summary>
        /// Sender's TokApp user-name.
        /// </summary>
        public string sender { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// If this message is a response to another one previously sent to this contact in which response was solicited, this is the message ID provided in <c>send</c> command.
        /// </summary>
        public string responseId { get; set; }

        /// <summary>
        /// Creates an array with messages received.
        /// </summary>
        /// <param name="response">Instance of response received.</param>
        /// <returns>Array with messages.</returns>
        internal static GetMessagesResponse[] CreateArray(ResponseBase response)
        {
            var resul = new List<GetMessagesResponse>();
            foreach (dynamic message in response.data)
            {
                string timeString = message.time;
                var msg = new GetMessagesResponse
                {
                    time = DateTime.ParseExact(timeString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToLocalTime(),
                    sender = message.sender,
                    text = message.text,
                    responseId = message.responseId
                };
                resul.Add(msg);
            }

            return resul.ToArray();
        }
    }
}
