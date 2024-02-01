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
