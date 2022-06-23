create trigger Mercado.checkAddFunc on Mercado.Funcionario
after insert, update
as
	set nocount on;
	declare @NIF as char(9);
	declare @SSN as char(11);
	select @NIF = NIF from inserted;
	select @SSN = SSN from inserted;

	if len(@NIF) <> 9
	begin
		raiserror('NIF mal inserido!', 16, 1);
		rollback tran;
	end
	if len(@SSN) <> 11
	begin
		raiserror('SSN mal inserido!', 16, 1);
		rollback tran;
	end
go