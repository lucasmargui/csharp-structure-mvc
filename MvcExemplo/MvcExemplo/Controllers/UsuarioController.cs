using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MvcExemplo.Models;

namespace MvcExemplo.Controllers
{
	public class UsuarioController : Controller
	{


		private static Usuarios _usuarios = new Usuarios();

		// GET: Teste
		public ActionResult Index()
		{
			return View(_usuarios.listaUsuarios);
		}

		// GET: Teste/Details/5
		public ActionResult Details(int id)
		{
			return View(_usuarios.GetUsuario(id));
		}

		// GET: Teste/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Teste/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		public ActionResult Create(UsuarioModel _usuarioModel)
		{
			try
			{
				_usuarios.CriaUsuario(_usuarioModel);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Teste/Edit/5
		public ActionResult Edit(int id)
		{
			return View(_usuarios.GetUsuario(id));
		}

		// POST: Teste/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		public ActionResult Edit(UsuarioModel _usuarioModel)
		{
			try
			{
				_usuarios.AtualizaUsuario(_usuarioModel);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: Teste/Delete/5
		public ActionResult Delete(int id)
		{

			return View(_usuarios.GetUsuario(id));
		}

		// POST: Teste/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		//public ActionResult DeleteConfirmed(int id, IFormCollection collection)

		public ActionResult Delete(UsuarioModel _usuarioModel)
		{
			try
			{
				_usuarios.DeletarUsuario(_usuarioModel.Id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
