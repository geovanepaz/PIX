using Pix.Domain.DomainObjects;
using System;

namespace Pix.Domain
{
    public class Cliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public int QuantidadeItens { get; private set; }

        protected Cliente() { }
        public Cliente(string nome, string codigo, int quantidadeItens)
        {
            Nome = nome;
            Codigo = codigo;
            QuantidadeItens = quantidadeItens;
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeVazio(Codigo, "O campo Codigo não pode estar vazio");
        }
    }
}
