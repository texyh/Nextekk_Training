using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nextekk.MomPop.Core.Models.Entities;
using Nextekk.MomPop.Core.Services;
using Nextekk.MomPop.Web.Models;

namespace Nextekk.MomPop.Web.Controllers
{
    [Produces("application/json")]
    [EnableCors("myCorsPolicy")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;

        /// <summary>
        /// Construtor for the transaction controller
        /// </summary>
        /// <param name="transactionService"></param>
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("~/api/transaction/checkout")]
        public async Task Checkout([FromBody]IEnumerable<OrderItemViewModel> orderItems)
        {
            var orderEntities = orderItems.Select(x => x.ToEntity());
            await _transactionService.ProcessCheckout(orderEntities);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            return await _transactionService.GetOrders();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<OrderEntity> GetOrder(Guid id)
        {
            return await _transactionService.GetOrder(id);
        }
    }
}