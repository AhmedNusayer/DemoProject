using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Hubs
{

    public class ChatHub : Hub
    {
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        static string aa = "1";
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void OnConnect(string userid, string username, string name)
        {
            var id = Context.ConnectionId;
            userid = userid;
            ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserID=userid, UserName=username, Name=name});
            
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string clientId = Context.ConnectionId;
            var connecteduser = ConnectedUsers.Find(x => x.ConnectionId == clientId);
            ConnectedUsers.Remove(connecteduser);
            return base.OnDisconnectedAsync(exception);
        }


        public void SendPrivateMessage(string toUserId, string user, string message)
        {
            var targetlist = getconnectionID(toUserId);
            foreach (var targetid in targetlist)
            {
                Clients.Clients(targetid.ConnectionId).SendAsync("ReceiveMessage", user, message);
            }
        }

        private List<UserDetail> getconnectionID(string toUserId)
        {
            return ConnectedUsers.FindAll(x => x.UserID == toUserId);
        }
        /*
public void RequestLastMessage(string FromUserID, string ToUserID)
{
   List<MessageDetail> CurrentChatMessages = (from u in CurrentMessage where ((u.FromUserID == FromUserID && u.ToUserID == ToUserID) || (u.FromUserID == ToUserID && u.ToUserID == FromUserID)) select u).ToList();
   //send to caller user
   Clients.Caller.GetLastMessages(ToUserID, CurrentChatMessages);
}

public void SendUserTypingRequest(string toUserId)
{
   string strfromUserId = (ConnectedUsers.Where(u => u.ConnectionId == Context.ConnectionId).Select(u => u.UserID).FirstOrDefault()).ToString();

   List<UserDetail> ToUsers = ConnectedUsers.Where(x => x.UserID == toUserId).ToList();

   foreach (var ToUser in ToUsers)
   {
       // send to                                                                                            
       Clients.Client(ToUser.ConnectionId).ReceiveTypingRequest(strfromUserId);
   }
}

public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
{
   var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
   if (item != null)
   {
       ConnectedUsers.Remove(item);
       if (ConnectedUsers.Where(u => u.UserID == item.UserID).Count() == 0)
       {
           var id = item.UserID.ToString();
           Clients.All.onUserDisconnected(id, item.UserName);
       }
   }
   return base.OnDisconnected(stopCalled);
}

private void AddMessageinCache(MessageDetail _MessageDetail)
{
   CurrentMessage.Add(_MessageDetail);
   if (CurrentMessage.Count > 100)
       CurrentMessage.RemoveAt(0);
}*/
    }
}
