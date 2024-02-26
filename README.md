# Projeto: C# MVC Estrutura






## Criação do Template

<details>
  <summary>Clique para mostrar conteúdo</summary>
Selecione o template Aplicativo Web do Asp.NET Core (MVC)

<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/bba2eb37-f962-4108-8369-b1d7a74ae2a0" style="width:90%">
</div>

 
</details>

## Criação do Models

<details>
  <summary>Clique para mostrar conteúdo</summary>
  
### Classe UsuarioModel.cs

<details>
  <summary>Clique para mostrar conteúdo UsuarioModel.cs</summary>

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

</details>

### Classe Usuario.cs

<details>
  <summary>Clique para mostrar conteúdo Usuario.cs</summary>
  
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

</details>


</details>

## Criação do Controller


<details>
  <summary>Clique para mostrar conteúdo</summary>
  
Clique com o botão direito no Controller e Adicionar -> Controlador
Com nome de UsuarioController e adicione a seguinte estrutura





<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/11172748-0c78-46b5-9b17-c16a94ae3f00" style="width:90%">
</div>

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

</details>



## Criação das Views

<details>
  <summary>Clique para mostrar conteúdo</summary>
  
Criar as views a partir dos métodos do controlador. Clique com o botão direito sobre o método Index() e selecione Add View;
E repetir o processo para criar uma view para cada método do CRUD 

*	Index() do controlador UsuarioController 
*	Create() do controlador UsuarioController 
*	Details() do controlador UsuarioController 
*	Delete() do controlador UsuarioController
*	Edit() do controlador UsuarioController 


### Selecione os metódos do controlador


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/f68e6cbe-a1e6-49a8-b463-fa9d95fc9d11" style="width:90%">
</div>

### Exibição Razor


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/3ab19956-a78a-4dd6-9280-a3acbc96e2d1" style="width:90%">
</div>

### Configuração



<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/99d49918-ab58-4794-8ec8-71e46a9fa12a" style="width:90%">
</div>

</details>




## Alteração de Links

<details>
  <summary>Clique para mostrar conteúdo</summary>
  
### Adicionar link de criação no Index


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/50197316-51d8-44cf-aa19-0562caa69c33" style="width:90%">
</div>

### Alteração dos link de cada item


<div align="center">
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/145c1fbd-e987-4292-8d91-ae99e47ab732" style="width:90%">
</div>


</details>


## Alteração Shared


<details>
  <summary>Clique para mostrar conteúdo</summary>
  
Antes de executar o projeto vamos alterar o arquivo _Layout.chstml da pasta /Shared incluindo a linha destacada em azul abaixo no arquivo:
```
<ul id="menu">
 <li>@Html.ActionLink("Home", "Index", "Home")</li>
 <li>@Html.ActionLink("About", "About", "Home")</li>
 <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
 <li>@Html.ActionLink("Usuario", "Index", "Usuario")</li>
</ul>
```

</details>



## Resultado


<div align="center">
<h3>Index<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/d4e793d0-b51c-4185-9249-4be8b90545df" style="width:70%">
</div>


<div align="center">
	<h3>Lista<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/5102bf6e-1ac2-4e8e-b699-0ff3409130e3" style="width:70%">
</div>
  

<div align="center">
	<h3>Criação<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/5b782f57-17dd-4b01-b463-eb0aa425bf5f" style="width:70%">
</div>
  



<div align="center">
	<h3>Editar<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/8731c5a5-2ce1-4139-889a-dc86357f1cdb" style="width:70%">
</div>
  


  <div align="center">
	  <h3>Deletar<h3>
<img src="https://github.com/lucasmargui/CSHARP_MVC_Estrutura/assets/157809964/1af5623f-33cc-4762-8cb8-f545dc3d5386" style="width:70%">
</div>


