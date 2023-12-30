using AgendamentoDeTarefas.Models;
using AgendamentoDeTarefas.Models.Context;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AgendamentoDeTarefas.Controllers
{

    public class TarefaController : Controller
    {
        private readonly OrganizadorContext _context;
        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        public IActionResult Index( string tituloPesquisa, string descricaoPesquisa, int? status, DateTime? dataPesquisa)
        {
         

            IQueryable<Tarefas> query = _context.Tarefas.Where(x => x.D_E_L_E_T_ != "*");

            if (!string.IsNullOrWhiteSpace(tituloPesquisa))
            {
                query = query.Where(x => x.Titulo.Contains(tituloPesquisa));
            }

            if (dataPesquisa != null)
            {
                query = query.Where(x => x.Data.Date == (dataPesquisa));
            }

            if (!string.IsNullOrWhiteSpace(descricaoPesquisa))
            {
                query = query.Where(x => x.Descricao.Contains(descricaoPesquisa));
            }

            if (status != null)
            {
                var statusEnum = (EnumStatusTarefa)status;
                query = query.Where(x => x.Status == statusEnum);
            }

            var resultados = query.ToList();

            return View(resultados);
        }






        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Create(Tarefas tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(tarefa);
        }

       public IActionResult Edit(int Id)
       {
            var tarefa = _context.Tarefas.Find(Id);

            if (tarefa == null) 
                    return RedirectToAction(nameof(Index));
            return View(tarefa);
       }

        [HttpPost, ActionName("Edit")]
        public IActionResult Edit(Tarefas tarefas)
        {
            var editarTarefa = _context.Tarefas.Find(tarefas.Id);

            editarTarefa.Titulo = tarefas.Titulo;
            editarTarefa.Descricao = tarefas.Descricao;
            editarTarefa.Data = tarefas.Data;
            editarTarefa.Status = tarefas.Status;

            _context.Tarefas.Update(editarTarefa);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var tarefa = _context.Tarefas.Find(Id);

            if (tarefa == null)
                return RedirectToAction(nameof(Index));
            return View(tarefa);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Tarefas tarefas)
        {
            var deletarTarefa = _context.Tarefas.Find(tarefas.Id);

            deletarTarefa.D_E_L_E_T_ = "*";

            _context.Update(deletarTarefa);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));

        }

        //public IActionResult Search(string nomePesquisa)
        //{
        //    var pesquisa = _context.Tarefas.Where(e => e.Titulo.Contains(nomePesquisa)).ToList();

        //    return View("Resultado", pesquisa);
        //}

    }

}
