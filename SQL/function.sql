use p8g2

/* OBTER A LISTA DE FUNCIONÁRIOS */
drop function Mercado.obterFuncionarios
go
create function Mercado.obterFuncionarios() returns table 
as 
	return (select * from Mercado.Funcionario)
go

/* OBTER A LISTA DE FUNCIONÁRIOS ATUAIS */
drop function Mercado.obterFuncionariosAtuais
go
create function Mercado.obterFuncionariosAtuais() returns table 
as 
	return (select ID, NIF, SSN, Email, Morada, Nome, Telemovel from Mercado.Chefe_Loja_atual
			union
			select ID, NIF, SSN, Email, Morada, Nome, Telemovel from Mercado.Resp_Op_atual
			union
			select ID, NIF, SSN, Email, Morada, Nome, Telemovel from Mercado.Op_Caixa_atual
			union
			select ID, NIF, SSN, Email, Morada, Nome, Telemovel from Mercado.Atend_Cliente_atual
			union
			select ID, NIF, SSN, Email, Morada, Nome, Telemovel from Mercado.Reposicao_atual)
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


/* OBTER A LISTA DE RESPONSÁVEIS */
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

/* OBTER A LISTA DE BALCÕES */
drop function Mercado.obterBalcao
go
create function Mercado.obterBalcao() returns table
as 
	return (select * from Mercado.Balcao)
go

/* OBTER A LISTA DE ARMAZÉNS */
drop function Mercado.obterArmazem
go
create function Mercado.obterArmazem() returns table
as 
	return (select * from Mercado.Armazem)
go

/* OBTER A LISTA DE SECÇÕES */
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

/* OBTER A LISTA DE FUNCIONÁRIOS QUE REPÕE CADA SECÇÃO */
drop function Mercado.obterRepoe
go
create function Mercado.obterRepoe() returns table
as 
	return (select * from Mercado.Repoe)
go


/* VERIFICAR QUAL FOI O ÚLTIMO ID ADICIONADO */
drop function Mercado.nextID
go
create function Mercado.nextID() returns int
as
	begin
		declare @ID as int;
		select @ID = max(ID) + 1 from Mercado.Funcionario;
		return @ID;
	end
go

drop function Mercado.checkNIF
GO
CREATE FUNCTION Mercado.checkNIF (@NIF char(9)) RETURNS int
AS
	BEGIN
		DECLARE @counter INT
		SELECT @counter = COUNT(1) FROM Mercado.Funcionario as F WHERE F.NIF=@NIF
		RETURN @counter
	END
GO

drop function Mercado.checkSSN
GO
CREATE FUNCTION Mercado.checkSSN (@SSN char(11)) RETURNS int
AS
	BEGIN
		DECLARE @counter INT
		SELECT @counter = COUNT(1) FROM Mercado.Funcionario as F WHERE F.SSN=@SSN
		RETURN @counter
	END
GO