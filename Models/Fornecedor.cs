using CadastroCS.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CadastroCS.Models
{
	public class Fornecedor
	{
        public int Id { get; set; }

        [StringLength(100, ErrorMessage ="O nome não pode exceder 100 caractéres.")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Range(10000000000000, 99999999999999, ErrorMessage = "Um CNPJ deve ter exatamente 14 dígitos.")]
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public ulong Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Segmento é obrigatório.")]
        public Segmento Segmento { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [Range(10000000, 99999999, ErrorMessage = "Um CEP deve ter exatamente 8 dígitos.")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "O campo Endereco é obrigatório.")]
        [StringLength(255, ErrorMessage = "O endereço não pode ter mais que 255 caractéres.")]
        public string Endereco { get; set; }

        public string Foto { get; set; } = "";

    }
}
