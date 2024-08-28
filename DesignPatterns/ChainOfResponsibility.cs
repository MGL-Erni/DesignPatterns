namespace DesignPatterns
{
    internal class ChainOfResponsibility
    {
        // purpose : allows a REQUEST to pass through a chain of request handlers. Each handler decides whether to handle the request, or to pass it to the next handler.

        public void Demo()
        { 
            ISupportHandler l1Handler = new Level1SupportHandler();
            ISupportHandler l2Handler = new Level2SupportHandler();

            // l1 has l2 as next handler
            l1Handler.SetNextHandler(l2Handler);

            // handle basic request with l1
            l1Handler.HandleRequest(new Request(Priority.Basic));

            // urgent request, escalate l1 -> l2
            l1Handler.HandleRequest(new Request(Priority.Urgent));  
        }
    }

    // this determines what level of support handle will handle a request
    public enum Priority
    {
        Basic,
        Urgent
    }

    // the request to be handled
    public class Request
    {
        private Priority _priority;

        public Request(Priority priority)
        {
            _priority = priority;
        }

        public Priority GetPriority()
        {
            return _priority;
        }
    }

    // interface for support handlers of all levels to implement
    public interface ISupportHandler
    {
        void HandleRequest(Request request);
        void SetNextHandler(ISupportHandler nextHandler);
    }

    // L1 support handles all basic issues
    public class Level1SupportHandler : ISupportHandler
    {
        private ISupportHandler? _nextHandler;

        public void SetNextHandler(ISupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(Request request)
        {
            if (request.GetPriority() == Priority.Basic)
            {
                Console.WriteLine("Level 1 support handled the request.");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("Request escalated to level 2.");
                _nextHandler.HandleRequest(request);
            }
        }
    }

    // pretend that L2 support is the last level in this chain
    public class Level2SupportHandler : ISupportHandler
    {
        private ISupportHandler? _nextHandler;

        // there is no next handler
        public void SetNextHandler(ISupportHandler nextHandler)
        {
            _nextHandler = null;
        }

        public void HandleRequest(Request request)
        {
            if (request.GetPriority() == Priority.Urgent)
            {
                Console.WriteLine("Level 2 support handled the request.");
            }
            else
            {
                Console.WriteLine("Level 2 support could not handle the request.");
            }
        }
    }
}



