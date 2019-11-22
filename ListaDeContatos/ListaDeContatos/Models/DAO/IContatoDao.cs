using ListaDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeContatos.Service
{
    public interface IContatoDao
    {
        void Adicionar(Contato contato);
        Contato BuscarPorId(int contato);
        List<Contato> BuscarPorNome(string nome);
        List<Contato> BuscarTodos();
        void Remover(Contato contato);
    }
}
