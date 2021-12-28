using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreCRUDAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCRUDAjax.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDBContext context;

        public TransactionController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await context.Transactions.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Transaction());

            var transaccion = await context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (transaccion == null)
                return NotFound();

            return View(transaccion);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(int id, [FromForm] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                //insert
                if (id == 0)
                {
                    transaction.TransactionDate = DateTime.Now;
                    context.Transactions.Add(transaction);
                    await context.SaveChangesAsync();
                }
                //update
                else
                {
                    context.Transactions.Update(transaction);                    
                    await context.SaveChangesAsync();
                }
            }
            return View(transaction);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var transaccion = await context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (transaccion == null)
                return NotFound();

            return View(transaccion);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var transaccion = await context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            if (transaccion == null)
                return NotFound();

            context.Transactions.Remove(transaccion);
            await context.SaveChangesAsync();
            return View("Index",await context.Transactions.ToListAsync());
        }

    }
}
