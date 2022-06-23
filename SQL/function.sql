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


/* VERIFICAR QUAL FOI O ÚLTIMO ID DE FUNCIONÁRIO ADICIONADO */
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

/* VERIFICAR QUAL FOI O ÚLTIMO ID DE CAIXA ADICIONADO */
drop function Mercado.nextIDCaixa
go
create function Mercado.nextIDCaixa() returns int
as
	begin
		declare @ID as int;
		select @ID = max(ID) + 1 from Mercado.Caixa;
		return @ID;
	end
go

/* VERIFICAR SE O NIF NÃO ESTÁ REPETIDO */
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

/* VERIFICAR SE O SSN NÃO ESTÁ REPETIDO */
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

/* VERIFICAR SE O CÓDIGO DE PRODUTO NÃO ESTÁ REPETIDO */
drop function Mercado.checkCodProd
GO
CREATE FUNCTION Mercado.checkCodProd (@CodProd char(3)) RETURNS int
AS
	BEGIN
		DECLARE @counter INT
		SELECT @counter = COUNT(1) FROM Mercado.Produto as P WHERE P.CodProd=@CodProd
		RETURN @counter
	END
GO

/* OBTER O CÓDIGO DE UMA CAIXA ATRAVÉS DO SEU ID */
drop function Mercado.getCodCaixaFromID
go
create function Mercado.getCodCaixaFromID (@IDCaixa int) returns char(6)
as
	begin
		declare @cod char(6);
		select @cod = CodAcesso from Mercado.Caixa where ID = @IDCaixa;
		return @cod;
	end
go

/* OBTER O CÓDIGO DE UMA SECÇÃO ATRAVÉS DA SUA DESIGNAÇÃO */
drop function Mercado.getCodSeccaoFromDesignacao
go
create function Mercado.getCodSeccaoFromDesignacao (@Designacao varchar(50)) returns char(6)
as
	begin
		declare @cod char(6);
		select @cod = Codigo from Mercado.Seccao where Designacao = @Designacao;
		return @cod;
	end
go

drop function Mercado.getProdutosSeccao
go
create function Mercado.getProdutosSeccao (@Designacao varchar(50)) returns @produtos table (
	CodProd                 char(3),  
    Preco                   decimal(5, 2)               not null,
    Marca                   varchar(150),   
    Nome                    varchar(150),
	Stock                   int)
as 
	begin 
		declare @CodProd as char(3);
		declare @Preco   as decimal(5, 2);
		declare @Marca   as varchar(150);  
		declare @Nome    as varchar(150);
		declare @Desgn	 as varchar(50);
		declare @Stock   as int;

		declare c cursor
		for select CodProd, Preco, Marca, Nome, Designacao, Stock from Mercado.Produto;

		open c;
		fetch c into @CodProd, @Preco, @Marca, @Nome, @Desgn, @Stock;

		while @@FETCH_STATUS = 0
			begin
				if @Desgn = @Designacao
					begin 
						insert into @produtos values (@CodProd, @Preco, @Marca, @Nome, @Stock);
					end
				fetch c into @CodProd, @Preco, @Marca, @Nome, @Desgn, @Stock;
			end

		close c;
		deallocate c;
		return;
	end
go