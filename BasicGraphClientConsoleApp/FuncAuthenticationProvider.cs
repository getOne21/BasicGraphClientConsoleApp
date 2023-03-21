namespace BasicGraphClientConsoleApp
{
    using Microsoft.Kiota.Abstractions;
    using Microsoft.Kiota.Abstractions.Authentication;
    using System.Collections.Generic;
    using System.Threading;

    public class FuncAuthenticationProvider : IAuthenticationProvider
    {
        private readonly Func<RequestInformation, Task> authenticateRequestAsync;

        public FuncAuthenticationProvider(Func<RequestInformation, Task> authenticateRequestAsync) 
            => this.authenticateRequestAsync = authenticateRequestAsync;

        public Task AuthenticateRequestAsync(
            RequestInformation request,
            Dictionary<string, object>? additionalAuthenticationContext = null,
            CancellationToken cancellationToken = default) 
            => this.authenticateRequestAsync(request);
    }
}
