using PrecoDoProduto.WithChain.Domain.Base;

namespace PrecoDoProduto.WithChain.Domain.Clientes.Builders
{
    public class ClienteBuilder : Builder<Cliente>
    {
        private string Nome { get; set; }

        public override Cliente Build()
        {
            return new Cliente(Codigo, Nome);
        }

        public ClienteBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }
    }
}