drop function Mercado.obterFuncionarios
go
create function Mercado.obterFuncionarios() returns table 
as 
	return (select * from Mercado.Funcionario)
go

drop function Mercado.obterChefeLoja
go
create function Mercado.obterChefeLoja() returns table
as 
	return (select * from Mercado.Chefe_Loja_atual
			union
			select * from Mercado.Chefe_Loja_antigo)
go

drop function Mercado.obterRespOp
go
create function Mercado.obterRespOp() returns table
as 
	return (select * from Mercado.Resp_Op_atual
			union
			select * from Mercado.Resp_Op_antigo)
go

drop function Mercado.obterOpCaixa
go
create function Mercado.obterOpCaixa() returns table
as 
	return (select * from Mercado.Op_Caixa_atual
			union
			select * from Mercado.Op_Caixa_antigo)
go

drop function Mercado.obterAtendCliente
go
create function Mercado.obterAtendCliente() returns table
as 
	return (select * from Mercado.Atend_Cliente_atual
			union
			select * from Mercado.Atend_Cliente_antigo)
go

drop function Mercado.obterReposicao
go
create function Mercado.obterReposicao() returns table
as 
	return (select * from Mercado.Reposicao_atual
			union
			select * from Mercado.Reposicao_antigo)
go

drop function Mercado.obterCaixas
go
create function Mercado.obterCaixas() returns table
as 
	return (select * from Mercado.Caixa)
go

drop function Mercado.obterBalcao
go
create function Mercado.obterBalcao() returns table
as 
	return (select * from Mercado.Balcao)
go

drop function Mercado.obterArmazem
go
create function Mercado.obterArmazem() returns table
as 
	return (select * from Mercado.Armazem)
go

drop function Mercado.obterSeccao
go
create function Mercado.obterSeccao() returns table
as 
	return (select * from Mercado.Seccao)
go

drop function Mercado.obterProdutos
go
create function Mercado.obterProdutos() returns table
as 
	return (select * from Mercado.Produto)
go

drop function Mercado.obterRepoe
go
create function Mercado.obterRepoe() returns table
as 
	return (select * from Mercado.Repoe)
go


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