using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokappAPIClient
{
    /// <summary>
    /// Data for each contact returned by command <c>getcontacts</c>.
    /// </summary>
    public class GetContactsResponse
    {

        /// <summary>
        /// Phone number as sent in petition.
        /// </summary>
        public string phone { get; set; }

        /// <summary>
        /// Email address as sent in petition.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Corresponding user-name.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Creates an array with data returned from command <c>getcontacts</c>
        /// </summary>
        /// <param name="response">Response object with data returned</param>
        internal static GetContactsResponse[] CreateArray(ResponseBase response)
        {
            List<GetContactsResponse> list = new List<GetContactsResponse>();
            foreach (dynamic elem in response.data)
            {
                var contact = new GetContactsResponse() {
                    phone = elem.phone,
                    email = elem.email,
                    username = elem.username
                };
                list.Add(contact);
            }

            return list.ToArray();
        }
    }
}
