namespace EshopApi.Domain.Exceptions
{
    public class AppBaseException : Exception
    {
        public AppBaseException()
        : base()
        {
        }

        public AppBaseException(string message)
        : base(message)
        {
        }

        public AppBaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
