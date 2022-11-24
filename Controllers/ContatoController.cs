using Microsoft.AspNetCore.Mvc;
using exemploAPI2.Context;
using exemploAPI2.Models;

namespace exemploAPI2.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context){

            _context = context;

        }
        public IActionResult Index(){

            var contatos = _context.Contatos.ToList();
            return View(contatos);

        }

        public IActionResult Criar(){

            return View();

        }

        [HttpPost]
        public IActionResult Criar(Contato contato){

            if(ModelState.IsValid){

                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(contato);

        }

        public IActionResult Editar(int id){

            var contato = _context.Contatos.Find(id);

            if(contato == null){

                return NotFound();

            }
            return View(contato);

        }

        [HttpPost]
        public IActionResult Editar(Contato contato){

            var contatoBanco = _context.Contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Status = contato.Status;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhar(int id){

            var contato = _context.Contatos.Find(id);

            if(contato == null){
                return NotFound();
            }
            return View(contato);

        }

        public IActionResult Deletar(int id){

            var contato = _context.Contatos.Find(id);

            if(contato == null){
                return NotFound();
            }
            return View(contato);

        }

        [HttpPost]
        public IActionResult Deletar(Contato contato){

            var contatoBanco = _context.Contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Status = contato.Status;

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}