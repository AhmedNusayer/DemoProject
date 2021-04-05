using System;

namespace EntityProject
{
    public class EmployerMail : IMailInfo
    {
        private readonly string _email;

        public EmployerMail(string email)
        {
            _email = email;
            VerificationCode.verificationCodeEmployer = new Random().Next(100000).ToString();
        }

        public string GetBody()
        {
            return "<p>To finish setting up your Job Portal account, we just need to make sure " +
                        "that you are a representative of this company. <br> To verify your company use this verification code: </p>" +
                        " <b style='color: #2672ec; font-size: 35px'>" + VerificationCode.verificationCodeEmployer + "</b>" +
                        "<p>If you didn't request this" +
                        " code, you can safely ignore this email. Someone else might have " +
                        "select your company by mistake. <br> <br> Thanks, <br> The Job Portal account team";
        }

        public string GetFromAddress()
        {
            return "webproject.test123@gmail.com";
        }

        public string GetSubject()
        {
            return "Verify your company for Job Portal";
        }

        public string GetToAddress()
        {
            return _email;
        }
    }
}
