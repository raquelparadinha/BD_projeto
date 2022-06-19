--create schema Mercado;
--go

/* Destroy dependencies and tables */

alter table Mercado.Repoe drop constraint Repoe_ID_FK;
alter table Mercado.Repoe drop constraint Repoe_Cod_FK
alter table Mercado.Produto drop constraint Produto_Cod_FK;
alter table Mercado.Seccao drop constraint Seccao_IDResp_FK;
alter table Mercado.Reposicao drop constraint Reposicao_Armazem_CodArmazem_FK;
alter table Mercado.Reposicao drop constraint Reposicao_IDSup_FK;
alter table Mercado.Reposicao drop constraint Reposicao_ID_FK;
alter table Mercado.Atend_Cliente drop constraint Atend_Client_Balcao_ExtTelefone_FK;
alter table Mercado.Atend_Cliente drop constraint Atend_Cliente_IDSup_FK;
alter table Mercado.Atend_Cliente drop constraint Atend_Cliente_ID_FK;
alter table Mercado.Op_Caixa drop constraint Op_Caixa_Caixa_IDcaixa_FK;
alter table Mercado.Op_Caixa drop constraint Op_Caixa_IDSup_FK;
alter table Mercado.Op_Caixa drop constraint Op_Caixa_ID_FK;
alter table Mercado.Resp_Op drop constraint Resp_Op_IDSup_FK;
alter table Mercado.Resp_Op drop constraint Resp_Op_ID_FK;
alter table Mercado.Chefe_Loja drop constraint Chefe_Loja_ID_FK;

drop table Mercado.Funcionario;
drop table Mercado.Chefe_Loja;
drop table Mercado.Resp_Op;
drop table Mercado.Caixa;
drop table Mercado.Op_Caixa;
drop table Mercado.Balcao;
drop table Mercado.Atend_Cliente;
drop table Mercado.Armazem;
drop table Mercado.Reposicao;
drop table Mercado.Seccao;
drop table Mercado.Produto;
drop table Mercado.Repoe;


/* Create tables */
create table Mercado.Funcionario (
	ID                      int,    
	NIF						char(9)						not null,
	SSN						char(11)					not null,
	Email                   varchar(150),  
    Morada                  varchar(150),            
    Nome                    varchar(150)					not null,            
    Telemovel               char(9),            
	primary key (ID),
	unique (NIF), unique (SSN)
);

create table Mercado.Chefe_Loja (
	ID                      int,
	Salario                 decimal(6, 2)				not null,
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID)
);

alter table Mercado.Chefe_Loja add constraint Chefe_Loja_ID_FK foreign key (ID) references Mercado.Funcionario (ID);

create table Mercado.Resp_Op (
    ID                      int,   
    IDSup                   int							not null, 
	Salario                 decimal(6, 2)				not null,
    Categoria               varchar(50)                 not null, 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID)
);

alter table Mercado.Resp_Op add constraint Resp_Op_ID_FK foreign key (ID) references Mercado.Funcionario (ID);
alter table Mercado.Resp_Op add constraint Resp_Op_IDSup_FK foreign key (IDSup) references Mercado.Funcionario (ID);

create table Mercado.Caixa (
    ID                      int, 
    CodAcesso               char(6)                     not null,  
    ExtTelefone             char(3)                     not null,   
    primary key (ID, CodAcesso),
);

create table Mercado.Op_Caixa (
    ID                      int, 
    IDSup                   int, 
	Salario                 decimal(6, 2)				not null,
    IDCaixa                 int,  
    CodAcesso               char(6), 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID)
);

alter table Mercado.Op_Caixa add constraint Op_Caixa_ID_FK foreign key (ID) references Mercado.Funcionario (ID);
alter table Mercado.Op_Caixa add constraint Op_Caixa_IDSup_FK foreign key (IDSup) references Mercado.Funcionario (ID);
alter table Mercado.Op_Caixa add constraint Op_Caixa_Caixa_IDcaixa_FK foreign key (IDCaixa, CodAcesso) references Mercado.Caixa (ID, CodAcesso);

create table Mercado.Balcao ( 
    ExtTelefone             char(3),   
    primary key (ExtTelefone),
);

create table Mercado.Atend_Cliente (
    ID                      int,
    IDSup                   int, 
	Salario                 decimal(6, 2)				not null,
    ExtTelefone             char(3),
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID)
);

alter table Mercado.Atend_Cliente add constraint Atend_Cliente_ID_FK foreign key (ID) references Mercado.Funcionario (ID);
alter table Mercado.Atend_Cliente add constraint Atend_Cliente_IDSup_FK foreign key (IDSup) references Mercado.Funcionario (ID);
alter table Mercado.Atend_Cliente add constraint Atend_Client_Balcao_ExtTelefone_FK foreign key (ExtTelefone) references Mercado.Balcao (ExtTelefone);

create table Mercado.Armazem (
    CodAcesso               char(6),     
    primary key (CodAcesso),
);

create table Mercado.Reposicao (
    ID                      int,   
    IDSup                   int,            
	Salario                 decimal(6, 2)				not null,
    CodArmazem              char(6)                     not null, 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID)
);

alter table Mercado.Reposicao add constraint Reposicao_ID_FK foreign key (ID) references Mercado.Funcionario (ID);
alter table Mercado.Reposicao add constraint Reposicao_IDSup_FK foreign key (IDSup) references Mercado.Funcionario (ID);
alter table Mercado.Reposicao add constraint Reposicao_Armazem_CodArmazem_FK foreign key (CodArmazem) references Mercado.Armazem (CodAcesso);

create table Mercado.Seccao (
    Codigo                  char(6),  
    Designacao              varchar(50),
    IDResp                  int,   
    primary key (Codigo, Designacao),
);

alter table Mercado.Seccao add constraint Seccao_IDResp_FK foreign key (IDResp) references Mercado.Resp_Op (ID);

create table Mercado.Produto (
    CodProd                 char(3),  
    Preco                   decimal(5, 2)               not null,
    Marca                   varchar(150),   
    Nome                    varchar(150),
    CodSeccao				char(6),
    Designacao              varchar(50),     
	Stock                   int,
    primary key (CodProd),
);

alter table Mercado.Produto add constraint Produto_Cod_FK foreign key (CodSeccao, Designacao) references Mercado.Seccao (Codigo, Designacao);

create table Mercado.Repoe (
    Codigo                  char(6),  
    Designacao              varchar(50),
    IDReposicao             int,   
    primary key (Codigo, Designacao, IDReposicao),
);

alter table Mercado.Repoe add constraint Repoe_Cod_FK foreign key (Codigo, Designacao) references Mercado.Seccao (Codigo, Designacao);
alter table Mercado.Repoe add constraint Repoe_ID_FK foreign key (IDReposicao) references Mercado.Reposicao (ID);