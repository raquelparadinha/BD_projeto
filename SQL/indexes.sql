use p8g2;

drop index searchNomeFuncionario on Mercado.Funcionario
drop index searchIDFuncionario on Mercado.Funcionario
drop index searchCodProduto on Mercado.Produto
drop index searchNomeProduto on Mercado.Produto

create index searchNomeFuncionario
	on Mercado.Funcionario (Nome)
go

create index searchIDFuncionario
	on Mercado.Funcionario (ID)
go

create index searchCodProduto
	on Mercado.Produto (CodProd)
go

create index searchNomeProduto
	on Mercado.Produto (Nome)
go