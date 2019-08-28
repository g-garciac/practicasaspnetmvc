using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMvc.Models
{
    public class CapturaProductoVm
    {
        [DisplayName("Identificador")]
        public string Id { get; set; }//Propiedades o Atributos de la clase

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.1, 100_000_000)]
        public decimal Precio { get; set; }

        [DisplayName("Categoría")]
        public string Categoria { get; set; }

    }
}
