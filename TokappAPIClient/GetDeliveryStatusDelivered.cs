using System;

namespace TokappAPIClient
{
    public class GetDeliveryStatusDelivered
    {
        public DateTime delivered { get; internal set; }
        public int id { get; internal set; }
        public string username { get; internal set; }
    }
}