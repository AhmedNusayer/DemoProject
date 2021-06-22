using EntityProject;
using InfrastructureProject;
using InfrastructureProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Hubs
{
    public class ChatHub : Hub
    {
        /*private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Message> _repository;*/
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        
        public ChatHub()//UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            /*this.userManager = userManager;
            _repository = new GenericRepository<Message>(context);*/
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void OnConnect(string userid, string username, string name)
        {
            var id = Context.ConnectionId;
            ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserID=userid, UserName=username, Name=name});
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string clientId = Context.ConnectionId;
            var connecteduser = ConnectedUsers.Find(x => x.ConnectionId == clientId);
            ConnectedUsers.Remove(connecteduser);
            return base.OnDisconnectedAsync(exception);
        }


        public async void SendPrivateMessage(string toUserId, string fromUserId, string message)
        {
            //ApplicationUser fromuser = await userManager.FindByIdAsync(fromUserId);
            //ApplicationUser touser = await userManager.FindByIdAsync(toUserId);

            /*Message newmessage = new Message()
            {
                MessageDetails = message,
                UserFrom = null,
                UserTo = null,
                Time = DateTime.Now
            };
*/
            List<UserDetail> targetlist = getconnectionID(toUserId);
            foreach (var targetid in targetlist)
            {
                await Clients.Clients(targetid.ConnectionId).SendAsync("ReceiveMessage", fromUserId, message);
            }
            
            //await _repository.Add(newmessage);
        }

        private List<UserDetail> getconnectionID(string userid)
        {
            return ConnectedUsers.FindAll(x => x.UserID == userid);
        }
    }
}
