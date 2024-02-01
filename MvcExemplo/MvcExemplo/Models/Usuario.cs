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
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 4,
				nome = " Lima",
				sobrenome = "Moraless",
				endereco = "Rua 123 , 10",
				email = "And@hotmail.com",
				nascimento = Convert.ToDateTime("15/07/1990")
			});
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 5,
				nome = "Richard",
				sobrenome = "Morais",
				endereco = "Rua Mirassol , 10",
				email = "richardhotmail.com",
				nascimento = Convert.ToDateTime("15/07/1990")
			});
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 6,
				nome = "Lucas",
				sobrenome = "Martins",
				endereco = "Rua Projetada , 100",
				email = "lucas@yahoo.com",
				nascimento = Convert.ToDateTime("05/09/1975")
			});
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 7,
				nome = "Bruno Andre",
				sobrenome = "Ribeiro",
				endereco = "Rua Mirassol , 50",
				email = "Bruno@bol.com.br",
				nascimento = Convert.ToDateTime("13/08/1992")
			});
			listaUsuarios.Add(new UsuarioModel
			{
				Id = 8,
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
