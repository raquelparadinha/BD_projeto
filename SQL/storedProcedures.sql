use p8g2
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
				declare @ID as int;
				select @ID = Mercado.nextID();
				insert into Mercado.Funcionario values (@ID, @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel);
				set @newID = @ID;
	end
go

drop proc Mercado.addChefe
go
create proc Mercado.addChefe(
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @Salario decimal(6, 2), @DInicio date, @DFim date)
as
	begin 
		declare @newID int;
		exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
		insert into Mercado.Chefe_Loja values (@newID, @Salario, @DInicio, @DFim);
	end
go

drop proc Mercado.addResp
go
create proc Mercado.addChefe(
@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9), @Salario decimal(6, 2), @DInicio date, @DFim date)
as
	begin 
		declare @newID int;
		exec Mercado.addFunc @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel, @newID output;
		insert into Mercado.Chefe_Loja values (@newID, @Salario, @DInicio, @DFim);
	end
go