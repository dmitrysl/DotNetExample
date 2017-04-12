using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace DotNetExample.WebApi.Controllers
{
    internal class ChallengeResult : IHttpActionResult
    {
        private string provider;
        private AccountController accountController;

        public ChallengeResult(string provider, AccountController accountController)
        {
            this.provider = provider;
            this.accountController = accountController;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}