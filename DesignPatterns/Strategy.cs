namespace DesignPatterns
{
    internal class Strategy
    {
        // purpose : easily switch between low-level implementations for a specific task, without becoming too reliant on their details

        public void Demo()
        {
            // send an async request using Internet Explorer
            new WebClient(BrowserType.InternetExplorer).SendAsyncRequestToServer();

            // send an async request using Google Chrome
            new WebClient(BrowserType.GoogleChrome).SendAsyncRequestToServer();

            // send an async request using Mozilla Firefox
            new WebClient(BrowserType.MozillaFirefox).SendAsyncRequestToServer();

            Console.WriteLine();
        }
    }

    class WebClient
    {
        private BrowserType _browserType;

        public WebClient(BrowserType browserType)
        {
            _browserType = browserType;
        }

        public void SendAsyncRequestToServer()
        {
            switch (_browserType)
            {
                case BrowserType.InternetExplorer:
                    new XmlHttpRequestApi().SendRequest();
                    return;

                case BrowserType.GoogleChrome:
                case BrowserType.MozillaFirefox:
                    new FetchApi().SendRequest();
                    return;

                default:
                    throw new NotImplementedException();
            }
        }
    }

    interface IAsyncRequestStrategy
    {
        public void SendRequest();
    }

    class XmlHttpRequestApi : IAsyncRequestStrategy
    {
        public void SendRequest()
        {
            Console.WriteLine("Sent request using XMLHttpRequest API.");
        }
    }

    class FetchApi : IAsyncRequestStrategy
    {
        public void SendRequest()
        {
            Console.WriteLine("Sent request using Fetch API.");
        }
    }

    enum BrowserType
    {
        InternetExplorer,
        GoogleChrome,
        MozillaFirefox
    }



}
