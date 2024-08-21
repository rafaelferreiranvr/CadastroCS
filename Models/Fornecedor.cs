using CadastroCS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroCS.Models
{
	public class Fornecedor
	{
        public int Id { get; set; }

        [StringLength(100, ErrorMessage ="O nome não pode exceder 100 caractéres.")]
        public string Name { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "Um CNPJ deve ter exatamente 14 dígitos.")]
        public int Cnpj { get; set; }

        public Segmento Segmento { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Um CEP deve ter exatamente 8 dígitos.")]
        public int Cep { get; set; }

        [StringLength(255, ErrorMessage = "O endereço não pode ter mais que 255 caractéres.")]
        public string Endereco { get; set; }

        public string Perfil { get; set; }

    }
}
