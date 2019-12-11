using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokappAPIClient
{
    /// <summary>
    /// Data for a problem reported by <c>getdeliverystatus</c> command.
    /// </summary>
    public class GetDeliveryStatusProblem
    {
        /// <summary>
        /// Message ID provided by client in send command.
        /// </summary>
        public int id;

        /// <summary>
        /// Contact's user-name associated with problem or empty if it's irrelevant.
        /// </summary>
        public string contact;

        /// <summary>
        /// Error code registered as detailed on error codes table.
        /// </summary>
        public int error;

        /// <summary>
        /// Problem description in English.
        /// </summary>
        public string message;
    }
}
