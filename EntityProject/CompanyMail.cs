using System;

namespace EntityProject
{
    public class CompanyMail : IMailInfo
    {
        private readonly string _email;

        public CompanyMail(string email)
        {
            _email = email;
            VerificationCode.verificationCodeCompany = new Random().Next(100000).ToString();
        }

        public string GetBody()
        {
            return "<p>To finish setting up your Job Portal account, we just need to make sure " +
                        "this email address belongs to your company. <br> To verify your email address use this verification code: </p>" +
                        " <b style='color: #2672ec; font-size: 35px'>" + VerificationCode.verificationCodeCompany + "</b>" +
                        "<p>If you didn't request this" +
                        " code, you can safely ignore this email. Someone else might have " +
                        "typed your email address by mistake. <br> <br> Thanks, <br> The Job Portal account team";
        }

        public string GetFromAddress()
        {
            return "webproject.test123@gmail.com";
        }

        public string GetSubject()
        {
            return "Verify your company email for Job Portal";
        }

        public string GetToAddress()
        {
            return _email;
        }
    }
}
