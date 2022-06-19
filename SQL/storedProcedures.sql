drop proc Mercado.addFunc
go
create proc Mercado.addFunc(@NIF char(9), @SSN char(11), @Email varchar(150), @Morada varchar(150), @Nome varchar(150), @Telemovel char(9))
as
	begin
		declare @ID as int;
		select @ID = Mercado.maxID();
		insert into Mercado.Funcionario values (@ID, @NIF, @SSN, @Email, @Morada, @Nome, @Telemovel);
	end
go

