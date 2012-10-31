using System.Collections.Generic;
using System.Threading.Tasks;
using SignalR.Hubs;

namespace SignalRTutorial.Hubs
{
    [HubName("ourTagHub")]
    public class TagHub : Hub, IConnected, IDisconnect
    {
        static List<string> _tags = new List<string>();

        static TagHub()
        {
            _tags.Add("c#");
            _tags.Add(".NET");
            _tags.Add("SignalR");
        }

        public void getTags()
        {
            //Call the initTags method on the calling client
            Caller.initTags(_tags);
        }

        public void setTag(string tag)
        {
            //Add the new tag to the list of tags
            _tags.Add(tag);

            //Call the addTag method on all connected clients
            Clients.addTag(tag);
        }

        public Task Connect()
        {
            //Call the joined method on all connected clients
            return Clients.joined(Context.ConnectionId);
        }

        public Task Reconnect(IEnumerable<string> groups)
        {
            //Call the rejoined method on all connected clients
            return Clients.rejoined(Context.ConnectionId);
        }

        public Task Disconnect()
        {
            //Call the leave method on all connected clients
            return Clients.leave(Context.ConnectionId);
        }
    }
}