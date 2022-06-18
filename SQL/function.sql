create function Mercado.obterFuncionarios() returns table 
as 
	return (select * from funcionarios)
go