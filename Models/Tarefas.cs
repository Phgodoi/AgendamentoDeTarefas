
using System.ComponentModel.DataAnnotations;

namespace AgendamentoDeTarefas.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        [StringLength(1)]
        [RegularExpression(@"^$|\*")]
        public string D_E_L_E_T_ { get; set; } = "";

        public EnumStatusTarefa Status { get; set; }
    }
}
