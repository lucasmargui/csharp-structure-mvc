# Projeto: C# MVC Estrutura

## Criação do template

Selecione o template Aplicativo Web do Asp.NET Core (MVC)

<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202481816699928616/image.png?ex=65cd9d76&is=65bb2876&hm=eb395af06d2b8a30b128c530471e96012e3e22cedea85488c6990271b1e38f94&" alt="">

## Criação do Models

### Classe UsuarioModel.cs

Clique com o botão direito em Models, clique em Add Class e adicione uma classe chamada UsuarioModel.cs com a seguinte estrutura

<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202482675751985192/image.png?ex=65cd9e42&is=65bb2942&hm=cfb838ce2331a1d2cfd9f5f753783d7e53eee5e65ccd885f566ec38fc037ddce&" alt="">

 ```
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcExemplo.Models
{
	public class UsuarioModel
	{


		[Key]
		public int Id { get; set; }

		[DisplayName("Primeiro Nome")]
		[StringLength(50, ErrorMessage = "O campo Nome permite no máximo 50 caracteres!")]
		public string nome { get; set; }
		[Required]
		public string sobrenome { get; set; }
		public string endereco { get; set; }
		[StringLength(50)]
		[Required(ErrorMessage = "Informe o Email")]
		[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
		public string email { get; set; }
		[DataType(DataType.Date)]
		public DateTime nascimento { get; set; }
	}
}
 ```

### Classe Usuario.cs

Clique com o botão direito em Models, clique em Add Class e adicione uma classe chamada Usuario.cs com a seguinte estrutura

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcExemplo.Models
{
	public class Usuarios
	{
		public List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

		public Usuarios()
		{
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 1,
				nome = "Lucas",
				sobrenome = "Martins",
				endereco = "Rua Projetada , 100",
				email = "lucas@yahoo.com",
				nascimento = Convert.ToDateTime("05/09/1975")
			});
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 2,
				nome = "Bruno Andre",
				sobrenome = "Ribeiro",
				endereco = "Rua Mirassol , 50",
				email = "Bruno@bol.com.br",
				nascimento = Convert.ToDateTime("13/08/1992")
			});
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 3,
				nome = "Andre Lima",
				sobrenome = "Morais",
				endereco = "Rua Peru , 10",
				email = "Andrema@hotmail.com",
				nascimento = Convert.ToDateTime("15/07/1990")
			});
		}
		public void CriaUsuario(UsuarioModel usuarioModelo)
		{
			listaUsuarios.Add(usuarioModelo);
		}

		public void AtualizaUsuario(UsuarioModel usuarioModelo)
		{
			foreach (UsuarioModel usuario in listaUsuarios)
			{
				if (usuario.Id == usuarioModelo.Id)
				{
					listaUsuarios.Remove(usuario);
					listaUsuarios.Add(usuarioModelo);
					break;
				}
			}
		}
		public UsuarioModel GetUsuario(int id)
		{
			UsuarioModel _usuarioModel = null;

			foreach (UsuarioModel _usuario in listaUsuarios)
				if (_usuario.Id == id)
					_usuarioModel = _usuario;

			return _usuarioModel;
		}

		public void DeletarUsuario(int id)
		{
			foreach (UsuarioModel _usuario in listaUsuarios)
			{
				if (_usuario.Id == id)
				{
					listaUsuarios.Remove(_usuario);

					break;
				}
			}
		}
	}
}

```

## Criação do Controller

Clique com o botão direito no Controller e Adicionar -> Controlador
Com nome de UsuarioController e adicione a seguinte estrutura

<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202486012941443172/image.png?ex=65cda15e&is=65bb2c5e&hm=2eb2eceb67a47e3254a79eeae79f41d2fceeb10e4c0d47b8f800f7181183768f&" alt="">

 ```
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

 ```

## Criação das Views

Criar as views a partir dos métodos do controlador. Clique com o botão direito sobre o método Index() e selecione Add View;
E repetir o processo para criar uma view para cada método do CRUD 

*	Index() do controlador UsuarioController 
*	Create() do controlador UsuarioController 
*	Details() do controlador UsuarioController 
*	Delete() do controlador UsuarioController
*	Edit() do controlador UsuarioController 


### Selecione os metódos do controlador
<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202486816024961065/image.png?ex=65cda21e&is=65bb2d1e&hm=fb6c2c510f4843e99cc8319e7b061c6e04406ec03dfb36c939052dffe776022a&" alt="">

### Exibição Razor
<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202486862552371220/image.png?ex=65cda229&is=65bb2d29&hm=a0a927a61a94d7cc040ffe4fea8baa46b22f82b7c46f04742d5547688d7b23c0&" alt="">

### Configuração
<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202486955296956426/image.png?ex=65cda23f&is=65bb2d3f&hm=2e23f5f2feb2e6c428b1e40efc7c00a3d071cf78328277120030fd6f808db23d&" alt="">


## Alteração de Links

### Adicionar link de criação no Index
<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202488964582473788/image.png?ex=65cda41e&is=65bb2f1e&hm=55268133aa032214325579ee9aa05ba5c372adb9355d5bdb4ac33ddd660bae67&" alt="">

### Alteração dos link de cada item
<img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202489363036901396/image.png?ex=65cda47d&is=65bb2f7d&hm=dda6da4f959f73c1a7f28b893039bd8293d3f9ddef2633f569a080b227b7c8cd&" alt="">

## Alteração Shared
Antes de executar o projeto vamos alterar o arquivo _Layout.chstml da pasta /Shared incluindo a linha destacada em azul abaixo no arquivo:
```
<ul id="menu">
 <li>@Html.ActionLink("Home", "Index", "Home")</li>
 <li>@Html.ActionLink("About", "About", "Home")</li>
 <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
 <li>@Html.ActionLink("Usuario", "Index", "Usuario")</li>
</ul>
```

## Resultado

### Index
  <img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202490212052369498/image.png?ex=65cda547&is=65bb3047&hm=ee9ce047449dd9a3d8bc2c1f8842eea6cdd0d5f8a93dae644d5f9ef829009c69&" alt="">
  
### Lista de Usuários
  <img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202490250723860531/image.png?ex=65cda550&is=65bb3050&hm=e9276947d80d461027f59d459534bac7307508cb8a6c99402b2c28bb89bb9382&" alt="">
  
### Criação de Usuário
  <img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202490314598645780/image.png?ex=65cda560&is=65bb3060&hm=f34281300c9a2088a17d257bbc95d99b00407777cf1b14fcc8cdc3fe29479eb5&" alt="">
  
### Editar Usuário
  <img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202490353811329065/image.png?ex=65cda569&is=65bb3069&hm=b08a6878f65ec612cb94b4acd522c84ea4f4140bbf993363f95321a2628bc1a3&" alt="">
  
### Deletar Usuário
  <img src="https://cdn.discordapp.com/attachments/1046824853015113789/1202490385411342376/image.png?ex=65cda571&is=65bb3071&hm=c2a1b2d6199e36c40d48271d096daeecc3ea155138229345e1a7c16801125ec2&" alt="">


