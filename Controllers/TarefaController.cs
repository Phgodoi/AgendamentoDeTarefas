﻿using AgendamentoDeTarefas.Models;
using AgendamentoDeTarefas.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoDeTarefas.Controllers
{

    public class TarefaController : Controller
    {
        private readonly OrganizadorContext _context;
        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefa = _context.Tarefas.Where(s => s.D_E_L_E_T_ != "*").ToList();

            return View(tarefa);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
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

        [HttpPost]
        public IActionResult Delete(Tarefas tarefas)
        {
            var deletarTarefa = _context.Tarefas.Find(tarefas.Id);

            deletarTarefa.D_E_L_E_T_ = "*";

            _context.Update(deletarTarefa);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));

        }
    }

}
