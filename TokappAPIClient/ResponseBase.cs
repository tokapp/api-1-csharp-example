using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokappAPIClient
{
    /// <summary>
    /// Base class for response data.
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Error code
        /// </summary>
        public int result { get; set; }

        /// <summary>
        /// Descriptive message
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Response data.
        /// </summary>
        public dynamic data { get; set; }
    }
}
