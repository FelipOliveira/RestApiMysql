using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class Perfil
    {
        public int Id { get; set; }
        public string nomePerfil { get; set; }
        [JsonIgnore]
        public ICollection<Funcionario> funcionarios { get; set; }
    }
}
