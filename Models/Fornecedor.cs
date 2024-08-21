using CadastroCS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroCS.Models
{
	public class Fornecedor
	{
        public int Id { get; set; }

        [StringLength(100, ErrorMessage ="O nome não pode exceder 100 caractéres.")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "Um CNPJ deve ter exatamente 14 dígitos.")]
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public int Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Segmento é obrigatório.")]
        public Segmento Segmento { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Um CEP deve ter exatamente 8 dígitos.")]
        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        public int Cep { get; set; }

        [StringLength(255, ErrorMessage = "O endereço não pode ter mais que 255 caractéres.")]
        [Required(ErrorMessage = "O campo Endereco é obrigatório.")]
        public string Endereco { get; set; }

        public string Perfil { get; set; }

    }
}
