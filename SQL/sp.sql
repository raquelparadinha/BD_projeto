use p8g2;

drop proc Mercado.addFunc
go
create proc Mercado.addFunc(@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @newID int output)
as
	begin
		declare @count int;
		set @count = (select Mercado.checkNIF(@NIF));
		if (@count >= 1)
			raiserror ('O NIF inserido já se encontra registado! Não foi possível adicionar funcionário.', 16, 1);
		else 
			set @count = (select Mercado.checkSSN(@SSN));
			if (@count >= 1)
				raiserror ('O SSN inserido já se encontra registado! Não foi possível adicionar funcionário.', 16, 1);
			else
				begin
					begin try
						begin tran
							declare @ID as int;
							select @ID = Mercado.nextID();
							insert into Mercado.Funcionario values (@ID, @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel);
							set @newID = @ID;
						commit tran
					end try
					begin catch
						rollback tran
						raiserror('Funcionario não inserido! Algum dado está incorreto.', 16, 1);
					end catch
				end
	end
go

drop proc Mercado.addChefe
go
create proc Mercado.addChefe(
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @Salario decimal(6, 2), @DInicio date, @DFim date)
as
	begin 
		begin try
			begin tran
				declare @newID int;
				exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
				insert into Mercado.Chefe_Loja values (@newID, @Salario, @DInicio, @DFim);
			commit tran
		end try
		begin catch
			rollback tran
			raiserror('Funcionario não inserido! Algum dado está incorreto.', 16, 1);
		end catch
	end
go

drop proc Mercado.addResp
go
create proc Mercado.addResp(
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @Salario decimal(6, 2), @Categoria varchar(50), @DInicio date, @DFim date)
as
	begin 
		begin try
			begin tran
				declare @newID int;
				declare @IDSup int;
				set @IDSup = (select ID from Mercado.Chefe_Loja_atual);
				exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
				insert into Mercado.Resp_Op values (@newID, @IDSup, @Salario, @Categoria, @DInicio, @DFim);
			commit tran
		end try
		begin catch
			rollback tran
			raiserror('Funcionario não inserido! Algum dado está incorreto.', 16, 1);
		end catch
	end
go

drop proc Mercado.addOpCaixa
go
create proc Mercado.addOpCaixa(
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @Salario decimal(6, 2), @IDCaixa int, @DInicio date, @DFim date)
as
	begin 
		begin try
			begin tran
				declare @newID int;
				declare @IDSup int;
				declare @CodAcesso char(6);
				set @IDSup = (select ID from Mercado.Resp_Op_atual where Categoria = 'Caixa');
				set @CodAcesso = (Mercado.getCodCaixaFromID(@IDCaixa));
				exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
				insert into Mercado.Op_Caixa values (@newID, @IDSup, @Salario, @IDCaixa, @CodAcesso, @DInicio, @DFim);
			commit tran
		end try
		begin catch
			rollback tran
			raiserror('Funcionario não inserido! Algum dado está incorreto.', 16, 1);
		end catch
	end
go

drop proc Mercado.addAtendCliente
go
create proc Mercado.addAtendCliente (
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @Salario decimal(6, 2), @ExtTelefone char(3), @DInicio date, @DFim date)
as
	begin 
		begin try
			begin tran
				declare @newID int;
				declare @IDSup int;
				set @IDSup = (select ID from Mercado.Resp_Op_atual where Categoria = 'Atendimento');
				exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
				insert into Mercado.Atend_Cliente values (@newID, @IDSup, @Salario, @ExtTelefone, @DInicio, @DFim);
			commit tran
		end try
		begin catch
			rollback tran
			raiserror('Funcionario não inserido! Algum dado está incorreto.', 16, 1);
		end catch
	end
go

drop proc Mercado.addReposicao
go
create proc Mercado.addReposicao(
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), 
@Salario decimal(6, 2), @DInicio date, @DFim date)
as
	begin 
		begin try
			begin tran
				declare @newID int;
				declare @IDSup int;
				declare @CodArmazem char(6);
				set @IDSup = (select ID from Mercado.Resp_Op_atual where Categoria = 'Reposicao');
				set @CodArmazem = (select CodAcesso from Mercado.Armazem);
				exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
				insert into Mercado.Reposicao values (@newID, @IDSup, @Salario, @CodArmazem, @DInicio, @DFim);
			commit tran
		end try
		begin catch
			rollback tran
			raiserror('Funcionario não inserido! Algum dado está incorreto.', 16, 1);
		end catch
	end
go

drop proc Mercado.addCaixa
go
create proc Mercado.addCaixa (@CodAcesso char(6), @ExtTelefone char(3))
as
	begin
		begin try
			begin tran
				declare @newID int;
				set @newID = (select Mercado.nextIDCaixa());
				insert into Mercado.Caixa values(@newID, @CodAcesso, @ExtTelefone);
			commit tran
		end try
		begin catch
			rollback tran
			raiserror('Caixa não inserida! Algum dado está incorreto.', 16, 1);
		end catch
	end
go	

drop proc Mercado.addProduto
go
create proc Mercado.addProduto (@CodProd char(3), @Preco decimal(5, 2), @Marca varchar(150), @Nome varchar(150), @Designacao varchar(50), @Stock int)
as
	begin
		declare @count int;
		declare @codSec char(6);
		set @codSec = (select Mercado.getCodSeccaoFromDesignacao(@Designacao));
		set @count = (select Mercado.checkCodProd(@CodProd)); 
		if (@count >= 1)
			raiserror ('O produto inserido já se encontra registado! Não foi possível adicionar produto.', 16, 1);
		else 
			begin
				begin try
					begin tran
						insert into Mercado.Produto values (@CodProd, @Preco, @Marca, @Nome, @codSec, @Designacao, @Stock);
					commit tran
				end try
				begin catch
					rollback tran
					raiserror('Produto não inserido! Algum dado está incorreto.', 16, 1);
				end catch
			end
	end
go

drop proc Mercado.deleteProduto
go
create proc Mercado.deleteProduto @CodProd char(3)
as
	begin
		begin tran
			delete from Mercado.Produto where  CodProd = @CodProd;
		commit
	end
go