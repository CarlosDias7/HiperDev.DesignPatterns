using PrecoDoProduto.WithChain.Domain.Orcamentos.Itens;
using PrecoDoProduto.WithChain.Services.DescontosDoProduto.Tipos;
using System;

namespace PrecoDoProduto.WithChain.Services.DescontosDoProduto.Chain
{
    public class DescontoDoProdutoChain : IDescontoDoProdutoChain
    {
        private readonly IDescontoDoProduto _descontoPorPromocao;
        private readonly IDescontoDoProduto _descontoPorQuantidadeMaiorQueCinco;
        private readonly IDescontoDoProduto _descontoPorQuantidadeMaiorQueTres;
        private readonly IPromocaoServices _promocaoServices;

        public DescontoDoProdutoChain(IPromocaoServices promocaoServices)
        {
            _promocaoServices = promocaoServices;

            _descontoPorPromocao = new DescontoPorPromocao(_promocaoServices);
            _descontoPorQuantidadeMaiorQueTres = new DescontoPorQuantidadeMaiorQueTres();
            _descontoPorQuantidadeMaiorQueCinco = new DescontoPorQuantidadeMaiorQueCinco();

            // Definição da Hierarquia
            _descontoPorPromocao.SetProximo(_descontoPorQuantidadeMaiorQueTres);
            _descontoPorQuantidadeMaiorQueTres.SetProximo(_descontoPorQuantidadeMaiorQueCinco);
        }

        public void Calcular(Produto produto)
        {
            _descontoPorPromocao.Executa(produto);
            Console.WriteLine(produto.ToString());
        }
    }
}