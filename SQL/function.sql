use p8g2

/* OBTER A LISTA DE FUNCION�RIOS */
drop function Mercado.obterFuncionarios
go
create function Mercado.obterFuncionarios() returns table 
as 
	return (select * from Mercado.Funcionario)
go

/* OBTER A LISTA DE CHEFES DE LOJA */
drop function Mercado.obterChefeLoja
go
create function Mercado.obterChefeLoja() returns table
as 
	return (select * from Mercado.Chefe_Loja_atual
			union
			select * from Mercado.Chefe_Loja_antigo)
go


/* OBTER A LISTA DE RESPONS�VEIS */
drop function Mercado.obterRespOp
go
create function Mercado.obterRespOp() returns table
as 
	return (select * from Mercado.Resp_Op_atual
			union
			select * from Mercado.Resp_Op_antigo)
go

/* OBTER A LISTA DE OP CAIXA */
drop function Mercado.obterOpCaixa
go
create function Mercado.obterOpCaixa() returns table
as 
	return (select * from Mercado.Op_Caixa_atual
			union
			select * from Mercado.Op_Caixa_antigo)
go

/* OBTER A LISTA DE ATEND CLIENTES */
drop function Mercado.obterAtendCliente
go
create function Mercado.obterAtendCliente() returns table
as 
	return (select * from Mercado.Atend_Cliente_atual
			union
			select * from Mercado.Atend_Cliente_antigo)
go

/* OBTER A LISTA DE REPOSITORES */
drop function Mercado.obterReposicao
go
create function Mercado.obterReposicao() returns table
as 
	return (select * from Mercado.Reposicao_atual
			union
			select * from Mercado.Reposicao_antigo)
go

/* OBTER A LISTA DE CAIXAS */
drop function Mercado.obterCaixas
go
create function Mercado.obterCaixas() returns table
as 
	return (select * from Mercado.Caixa)
go

/* OBTER A LISTA DE BALC�ES */
drop function Mercado.obterBalcao
go
create function Mercado.obterBalcao() returns table
as 
	return (select * from Mercado.Balcao)
go

/* OBTER A LISTA DE ARMAZ�NS */
drop function Mercado.obterArmazem
go
create function Mercado.obterArmazem() returns table
as 
	return (select * from Mercado.Armazem)
go

/* OBTER A LISTA DE SEC��ES */
drop function Mercado.obterSeccao
go
create function Mercado.obterSeccao() returns table
as 
	return (select * from Mercado.Seccao)
go

/* OBTER A LISTA DE PRODUTOS */
drop function Mercado.obterProdutos
go
create function Mercado.obterProdutos() returns table
as 
	return (select * from Mercado.Produto)
go

/* OBTER A LISTA DE FUNCION�RIOS QUE REP�E CADA SEC��O */
drop function Mercado.obterRepoe
go
create function Mercado.obterRepoe() returns table
as 
	return (select * from Mercado.Repoe)
go


/* VERIFICAR QUAL FOI O �LTIMO ID ADICIONADO */
drop function Mercado.maxID
go
create function Mercado.maxID() returns int
as
	begin
		declare @ID as int;
		select @ID = max(ID) + 1 from Mercado.Funcionario;
		return @ID;
	end
go