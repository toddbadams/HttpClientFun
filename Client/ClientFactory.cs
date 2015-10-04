using System.Net.Http;

namespace Client
{
    public class ClientFactory
    {
        public HttpClient Create()
        {
            return new HttpClient(); //new MessageHandler());
        }
    }
}