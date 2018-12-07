using System.Collections.Generic;

namespace Associado.Domain
{
    public class Associad
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string ceep { get; set; }
        public string cpf { get; set; }
        public string descProblema { get; set; }
        public List<Dependente> dependente {get; set;}  
    }
}