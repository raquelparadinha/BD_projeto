drop function Mercado.obterFuncionarios
go
create function Mercado.obterFuncionarios() returns table 
as 
	return (select * from funcionarios)
go

select * from Mercado.obterFuncionarios()