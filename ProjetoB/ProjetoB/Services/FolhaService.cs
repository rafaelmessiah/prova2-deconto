using ProjetoB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoB.Services
{
    public class FolhaService
    {
        private List<Folha> _folhas = new List<Folha>();

        public List<Folha> Listar()
        {
            return _folhas;
        }

        public double Total()
        {
            var total = 0.00;

            foreach (var folha in _folhas)
            {
                total += folha.bruto;
            }

            return total;
        }

        public double Media()
        {
            var total = 0.00;

            foreach (var folha in _folhas)
            {
                total += folha.bruto;
            }

            return total / _folhas.Count;
        }

        public void Cadastrar(Folha folha)
        {
            _folhas.Add(folha);
        }
    }
}
