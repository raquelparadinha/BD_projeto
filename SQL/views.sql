-- Chefe de Loja atual
drop view Mercado.Chefe_Loja_atual
go 
create view Mercado.Chefe_Loja_atual as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, C.Salario, C.DInicio, C.DFim
	from Mercado.Chefe_Loja as C
	join Mercado.Funcionario as F on C.ID = F.ID
	where C.DFim is null;
go

-- Chefes de Loja antigos
drop view Mercado.Chefe_Loja_antigo
go 
create view Mercado.Chefe_Loja_antigo as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, C.Salario, C.DInicio, C.DFim
	from Mercado.Chefe_Loja as C
	join Mercado.Funcionario as F on C.ID = F.ID
	where C.DFim is not null;
go

-- Resp op atual
drop view Mercado.Resp_Op_atual
go 
create view Mercado.Resp_Op_atual as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, R.IDSup, R.Salario, R.Categoria, R.DInicio, R.DFim
	from Mercado.Resp_Op as R
	join Mercado.Funcionario as F on R.ID = F.ID
	where R.DFim is null;
go

---- Resp op antigos
drop view Mercado.Resp_Op_antigo
go 
create view Mercado.Resp_Op_antigo as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, R.IDSup, R.Salario, R.Categoria, R.DInicio, R.DFim
	from Mercado.Resp_Op as R
	join Mercado.Funcionario as F on R.ID = F.ID
	where R.DFim is not null;
go

-- Op_Caixa atual
drop view Mercado.Op_Caixa_atual
go 
create view Mercado.Op_Caixa_atual as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, C.IDSup, C.Salario, C.IDCaixa, C.CodAcesso, C.DInicio, C.DFim
	from Mercado.Op_Caixa as C
	join Mercado.Funcionario as F on C.ID = F.ID
	where C.DFim is null;
go

-- Op_Caixa antigos
drop view Mercado.Op_Caixa_antigo
go 
create view Mercado.Op_Caixa_antigo as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, C.IDSup, C.Salario, C.IDCaixa, C.CodAcesso, C.DInicio, C.DFim
	from Mercado.Op_Caixa as C
	join Mercado.Funcionario as F on C.ID = F.ID
	where C.DFim is not null;
go

-- Atend_Cliente atual
drop view Mercado.Atend_Cliente_atual
go 
create view Mercado.Atend_Cliente_atual as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, C.IDSup, C.Salario, C.ExtTelefone, C.DInicio, C.DFim
	from Mercado.Atend_Cliente as C
	join Mercado.Funcionario as F on C.ID = F.ID
	where C.DFim is null;
go

-- Atend_Cliente antigos
drop view Mercado.Atend_Cliente_antigo
go 
create view Mercado.Atend_Cliente_antigo as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, C.IDSup, C.Salario, C.ExtTelefone, C.DInicio, C.DFim
	from Mercado.Atend_Cliente as C
	join Mercado.Funcionario as F on C.ID = F.ID
	where C.DFim is not null;
go

 
 -- Reposicao atual
drop view Mercado.Reposicao_atual
go 
create view Mercado.Reposicao_atual as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, R.IDSup, R.Salario, R.CodArmazem, R.DInicio, R.DFim
	from Mercado.Reposicao as R
	join Mercado.Funcionario as F on R.ID = F.ID
	where R.DFim is null;
go

-- Reposicao antigos
drop view Mercado.Reposicao_antigo
go 
create view Mercado.Reposicao_antigo as 
	select  F.ID, F.NIF, F.SSN, F.Email, F.Morada, F.Nome, F.Telemovel, R.IDSup, R.Salario, R.CodArmazem, R.DInicio, R.DFim
	from Mercado.Reposicao as R
	join Mercado.Funcionario as F on R.ID = F.ID
	where R.DFim is not null;
go