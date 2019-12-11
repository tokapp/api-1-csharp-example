using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokappAPIClient
{
    /// <summary>
    /// Data returned by <c>getdeliverystatus</c> command.
    /// </summary>
    public class GetDeliveryStatusResponse
    {

        /// <summary>
        /// If <c>true</c> is returned delivery was copleted. If <c>false</c> is returned sending is in course.
        /// </summary>
        public bool completed { get; set; }

        /// <summary>
        /// Array with problems detected.
        /// </summary>
        public GetDeliveryStatusProblem[] problems { get; set; }

        /// <summary>
        /// Array with deliveries registered
        /// </summary>
        public GetDeliveryStatusDelivered[] delivered { get; set; }

        /// <summary>
        /// Creates an instance from a generic response.
        /// </summary>
        /// <param name="response">Instancia of generic response.</param>
        /// <returns>New instance.</returns>
        internal static GetDeliveryStatusResponse CreateInstance(ResponseBase response)
        {
            List<GetDeliveryStatusProblem> problems = null;
            List<GetDeliveryStatusDelivered> delivered = null;
            GetDeliveryStatusProblem[] problemsArray = null;
            GetDeliveryStatusDelivered[] deliveredArray = null;
            if (response.data.problems != null) {
                problems = new List<GetDeliveryStatusProblem>();
                foreach (dynamic problem in response.data.problems) {
                    var obj = new GetDeliveryStatusProblem() {
                        id = problem.id,
                        contact = problem.contact,
                        error = problem.error,
                        message = problem.message
                    };
                    problems.Add(obj);
                }
                problemsArray = problems.ToArray();
            }
            if (response.data.delivered != null)
            {
                delivered = new List<GetDeliveryStatusDelivered>();
                foreach (dynamic item in response.data.delivered)
                {
                    var obj = new GetDeliveryStatusDelivered()
                    {
                        id = item.id,
                        username = item.username,
                        delivered = item.delivered
                    };
                    delivered.Add(obj);
                }
                deliveredArray = delivered.ToArray();
            }
            var resul = new GetDeliveryStatusResponse()
            {
                completed = response.data.completed == 1,
                problems = problemsArray,
                delivered = deliveredArray
            };
            return resul;
        }
    }
}
