using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityProject
{
    public class MailFactory
    {
        private readonly string _action;
        private readonly List<string> _addresses;

        public MailFactory(string action, string addresses)
        {
            _action = action;
            _addresses = addresses.Split(" ").ToList();
        }

        public List<IMailInfo> GetMails()
        {
            if(_action == "verifyuser")
            {
                return new List<IMailInfo>(){
                    new UserMail(_addresses[0]) 
                };
            }
            else if(_action == "verifycompany")
            {
                return new List<IMailInfo>(){
                    new CompanyMail(_addresses[0])
                };
            }
            else if(_action == "verifyemployer")
            {
                return new List<IMailInfo>(){
                    new UserMail(_addresses[0]),
                    new EmployerMail(_addresses[1])
                };
            }
            else
            {
                return new List<IMailInfo>();
            }
        }

    }
}
