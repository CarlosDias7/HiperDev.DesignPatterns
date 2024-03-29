﻿using PrecoDoProduto.NoPattern.Domain.Clientes.Builders;
using PrecoDoProduto.NoPattern.Domain.Orcamentos.Itens;
using PrecoDoProduto.NoPattern.Domain.Orcamentos.Itens.Builders;
using PrecoDoProduto.NoPattern.Domain.PedidosDeVenda;
using PrecoDoProduto.NoPattern.Domain.PedidosDeVenda.Builders;
using PrecoDoProduto.NoPattern.Services;
using System;
using System.Collections.Generic;

namespace PrecoDoProduto.NoPattern
{
    internal class Program
    {
        private static PedidoDeVenda GetPedido()
        {
            var cliente = new ClienteBuilder()
                .WithNome("Cepo")
                .WithCodigo(1)
                .Build();

            var produto1 = new ProdutoBuilder()
                .WithCancelado(false)
                .WithNome("Abacate")
                .WithQuantidade(1.00m)
                .WithValorUnitarioBruto(50.00m)
                .WithCodigo(1)
                .Build();

            var produto2 = new ProdutoBuilder()
                .WithCancelado(false)
                .WithNome("Abacaxi")
                .WithQuantidade(4.00m)
                .WithValorUnitarioBruto(60.00m)
                .WithCodigo(9)
                .Build();

            var produto3 = new ProdutoBuilder()
                .WithCancelado(false)
                .WithNome("Carambola")
                .WithQuantidade(10.00m)
                .WithValorUnitarioBruto(70.00m)
                .WithCodigo(10)
                .Build();

            var produtos = new List<Produto> { produto1, produto2, produto3 };

            return new PedidoDeVendaBuilder()
                .WithCliente(cliente)
                .WithItens(produtos)
                .WithCodigo(1)
                .Build();
        }

        private static void Main(string[] args)
        {
            var pedido = GetPedido();

            IPromocaoServices promocaoServices = new PromocaoServices();
            IDefinirPrecoDosProdutosDoPedidoDeVendaServices definirPrecoDosProdutosDoPedidoDeVendaServices = new DefinirPrecoDosProdutosDoPedidoDeVendaServices(promocaoServices);

            definirPrecoDosProdutosDoPedidoDeVendaServices.DefinirPrecoDosProdutosDoPedidoDeVenda(pedido);

            Console.ReadKey();
        }
    }
}