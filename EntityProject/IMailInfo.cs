namespace EntityProject
{
    public interface IMailInfo
    {
        public string GetFromAddress();

        public string GetToAddress();

        public string GetSubject();

        public string GetBody();
    }
}
