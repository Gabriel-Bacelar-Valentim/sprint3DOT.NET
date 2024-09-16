namespace sprint3.NET.Repository
{
    public class Logger
    {
        private static readonly Lazy<Logger> _logger = new Lazy<Logger>(() => new Logger());

        public static Logger Instance
        {
            get { return _logger.Value; }
        }

        public void Message(string message)
        {
            SendToSplunk(message);

            Console.WriteLine(message);
        }

        public void Error(string message, Exception exception)
        {
            SendToSplunk(message);

            Error(exception);
        }

        public void Error(Exception exception)
        {
            SendToSplunk(exception.Message);

            Console.WriteLine(exception.Message);
        }

        private void SendToSplunk(string message)
        {

        }
    }
}
