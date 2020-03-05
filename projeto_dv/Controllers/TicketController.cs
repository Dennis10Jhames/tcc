using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projeto_dv.Models;
using projeto_dv.Repositorio;

namespace projeto_dv.Controllers
{
    public class TicketController : Controller
    {
        
        public ActionResult Index()
        {
            List<Ticket> ticket = new List<Ticket>();
            ticket = new BD().ListaTodos();
            return View(ticket);
           
        }
        public ActionResult Cadastro()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Cadastro(Ticket ticket)
        {

            if (ModelState.IsValid)
            {
                BD ObjBD = new BD();
                ObjBD.Inserir(ticket);
                return RedirectToAction("Index");

            }
            return View(ticket);
        }

            public ActionResult Detalhes(Ticket ticket)
        {

            var ticketPorId = new BD().ListaTodos().Single(a => a.Id == ticket.Id);
            return View(ticketPorId);


        }
        public ActionResult Editar(Ticket ticket)
        {
            var clientePorId = new BD().ListaTodos().Single(a => a.Id == ticket.Id);

            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(clientePorId);
        }

        [HttpPost, ActionName("Editar")]
        public ActionResult EditarConfirmado(Ticket ticket)
        {
            BD ObjBD = new BD();
            ObjBD.Editar (ticket);
            return RedirectToAction("Index");
        }
        public ActionResult Excluir(Ticket ticket)
        {
            var ticketPorId = new BD().ListaTodos().Single(a => a.Id == ticket.Id);

            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticketPorId);
        }
        [HttpPost, ActionName("Excluir")]

        public ActionResult ExcluirConfirmado(Ticket ticket)


        {
            var ticketPorId = new BD().ListaTodos().Single(a => a.Id == ticket.Id);
            BD ObjBD = new BD();
            ObjBD.Deletar(ticketPorId.Id);
            return RedirectToAction("Index");

        }


    }
}