namespace Upside_downKittenGenerator.Dto
{
    public class UserTokens
    {
        public string Token
        {
            get;
            set;
        }
        public TimeSpan Validaty
        {
            get;
            set;
        }
        public Guid Id
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public Guid GuidId
        {
            get;
            set;
        }
        public DateTime ExpiredTime
        {
            get;
            set;
        }
    }
}
