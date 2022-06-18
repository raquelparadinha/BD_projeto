-- Lista todos os funcionários
drop view funcionarios
go
create view funcionarios as
(select ID, Nome from Mercado.Chefe_Loja
union
select ID, Nome from Mercado.Resp_Op
union
select ID, Nome from Mercado.Op_Caixa
union
select ID, Nome from Mercado.Atend_Cliente
union
select ID, Nome from Mercado.Reposicao)
go
