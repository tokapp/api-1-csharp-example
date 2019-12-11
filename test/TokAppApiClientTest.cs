using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class TokAppApiClientTest
    {
        /// <summary>
        /// Client API key
        /// </summary>
        private const string API_KEY = "";  //  TODO: Insert here your API Key.

        /// <summary>
        /// Server's host
        /// </summary>
        private const string HOST = "https://api.tokapp.net/";

        private TokappAPIClient.Client _client;
        /// <summary>
        /// Gets the singleton instance of Client object.
        /// </summary>
        private TokappAPIClient.Client client
        {
            get
            {
                if (_client == null)
                {
                    _client = new TokappAPIClient.Client(HOST, API_KEY);
                }
                return _client;
            }
        }

        [TestMethod]
        public void Status()
        {
            var response = client.CheckStatus();
            Assert.IsTrue(response.available);
        }

        [TestMethod]
        public void GetContacts()
        {
            //  TODO: Fill in here the phones and emails you want to find.
            string[] phones = {  };
            string[] emails = {  };
            var contacts = client.GetContacts(phones, emails);
            //  TODO: Put a breakpoint here to inspect contacts object.
            Assert.IsTrue(contacts != null);
        }

        [TestMethod]
        public void Send()
        {
            //  TODO: Fill in here the usernames of people that you want to send messages. 
            string[] recipients = {  };
            dynamic[] messages = {
                new {
                    id = 1,
                    text = "TokAppApiSampleCSharp sample message",
                    response = 0,
                    contacts = recipients
                }
            };
            var messageId = client.Send(messages);
            Assert.IsFalse(string.IsNullOrWhiteSpace(messageId));

            var deliveryStatus = client.GetDeliveryStatus(messageId);
            //  TODO: Put a breakpoint here to inspect deliveryStatus object.
            Assert.IsTrue(deliveryStatus != null);
        }

        [TestMethod]
        public void SendMultiple()
        {
            //  TODO: Fill in here the usernames of people that you want to send messages. 
            string[] recipients = {  };
            for (var i = 0; i < 2; i++)
            {
                string[] contacts = { recipients[i] };
                dynamic[] messages = {
                    new {
                        id = 1,
                        text = "TokAppApiSampleCSharp sample message",
                        response = 0,
                        contacts = contacts
                    }
                };
                var messageId = client.Send(messages);
                Assert.IsFalse(string.IsNullOrWhiteSpace(messageId));

                var deliveryStatus = client.GetDeliveryStatus(messageId);
                //  TODO: Put a breakpoint here to inspect deliveryStatus object.
                Assert.IsTrue(deliveryStatus != null);
            }
        }

        [TestMethod]
        public void GetMessages()
        {
            var msgs = client.GetMessages();
            //  TODO: Put a breakpoint here to inspect msgs object.
            Assert.IsTrue(msgs != null);
        }

        [TestMethod]
        public void SetLogo()
        {
            //  TODO: Fill in here the complete path to a image file to set as sender's logo.
            var path = @"";
            client.SetLogo(path);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetName()
        {
            // TODO: Fill in here the name that you want to assign to sender.
            string name = "";
            client.SetName(name);
            Assert.IsTrue(true);
        }
    }
}
