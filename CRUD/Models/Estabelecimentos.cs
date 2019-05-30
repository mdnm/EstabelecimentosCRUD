using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Estabelecimentos //: IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Razão\u00a0Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome\u00a0Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string CNPJ { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor insira um Email válido!")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Telefone { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Por favor insira uma data válida!")]
        [Display(Name = "Data\u00a0de\u00a0Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        [Display(Name = "Categorias")]
        public int? CategoriaId { get; set; }

        public string Status { get; set; }

        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        public string Conta { get; set; }

        [NotMapped]
        public List<Categorias> categoriasList { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        public bool CheckTelefone()
        {
            if (categoriasList.Find(x=>x.Id==CategoriaId).Nome.Equals("Supermercado") && Telefone == null)
            {
                return false;
            }
            return true;
        }
    }
}
