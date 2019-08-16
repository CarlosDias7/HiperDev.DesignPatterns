using PrecoDoProduto.NoPattern.Domain.Base;
using System;

namespace PrecoDoProduto.NoPattern.Domain.Clientes
{
    public class Cliente : Entity
    {
        public Cliente(int codigo, string nome)
        {
            SetCodigo(codigo);
            SetNome(nome);
        }

        public string Nome { get; private set; }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new InvalidOperationException();
            Nome = nome;
        }
    }
}