--create schema Mercado;
--go

/* Destroy dependencies and tables */

alter table Mercado.Repoe drop constraint Repoe_ID_FK;
alter table Mercado.Repoe drop constraint Repoe_Cod_FK
alter table Mercado.Produto drop constraint Produto_Cod_FK;
alter table Mercado.Seccao drop constraint Seccao_IDResp_FK;
alter table Mercado.Reposicao drop constraint Reposicao_Armazem_CodArmazem_FK;
alter table Mercado.Reposicao drop constraint Reposicao_supID_FK;
alter table Mercado.Atend_Cliente drop constraint Atend_Client_Balcao_ExtTelefone_FK;
alter table Mercado.Atend_Cliente drop constraint Atend_Client_supID_FK;
alter table Mercado.Op_Caixa drop constraint Op_Caixa_Caixa_IDcaixa_FK;
alter table Mercado.Op_Caixa drop constraint Op_Caixa_supID_FK;
alter table Mercado.Resp_Op drop constraint Resp_Op_supID_FK;

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
create table Mercado.Chefe_Loja (
    ID                      int,    
	NIF						char(9)						not null,
	SSN						char(11)					not null,
	Email                   varchar(50),  
    Morada                  varchar(50),            
    Nome                    varchar(50)					not null,            
    Telemovel               char(9),            
    Salario                 decimal(6, 2)				not null,
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID),
	unique (NIF), unique (SSN),
);


create table Mercado.Resp_Op (
    ID                      int,   
	NIF						char(9)						not null,
	SSN						char(11)					not null,
	Email                   varchar(50),
    IDSup                   int							not null,            
    Morada                  varchar(50),            
    Nome                    varchar(50)					not null,            
    Telemovel               char(9),            
    Salario                 decimal(6, 2)				not null,
    Categoria               varchar(50)                 not null, 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID),
	unique (NIF), unique (SSN),
);

create table Mercado.Caixa (
    ID                      int, 
    CodAcesso               char(6)                     not null,  
    ExtTelefone             char(3)                     not null,   
    primary key (ID, CodAcesso),
);

create table Mercado.Op_Caixa (
    ID                      int, 
	NIF						char(9)						not null,
	SSN						char(11)					not null,
	Email                   varchar(50),
    IDSup                   int,            
    Morada                  varchar(50),            
    Nome                    varchar(50)					not null,            
    Telemovel               char(9),            
    Salario                 decimal(6, 2)               not null,
    IDCaixa                 int,  
    CodAcesso               char(6), 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID),
	unique (NIF), unique (SSN),
);

create table Mercado.Balcao ( 
    ExtTelefone             char(3),   
    primary key (ExtTelefone),
);

create table Mercado.Atend_Cliente (
    ID                      int,
	NIF						char(9)						not null,
	SSN						char(11)					not null,
	Email                   varchar(50),
    IDSup                   int,            
    Morada                  varchar(50),            
    Nome                    varchar(50)					not null,            
    Telemovel               char(9),            
    Salario                 decimal(6, 2)               not null,
    ExtTelefone             char(3), 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID),
	unique (NIF), unique (SSN),
);

create table Mercado.Armazem (
    CodAcesso               char(6),     
    primary key (CodAcesso),
);

create table Mercado.Reposicao (
    ID                      int,   
	NIF						char(9)						not null,
	SSN						char(11)					not null,
	Email                   varchar(50),
    IDSup                   int,            
    Morada                  varchar(50),            
    Nome                    varchar(50)					not null,            
    Telemovel               char(9),            
    Salario                 decimal(6, 2)               not null,
    CodArmazem              char(6)                     not null, 
    DInicio                 date                        not null,
    DFim                    date,                 
    primary key (ID),
	unique (NIF), unique (SSN),
);

/*
	Mercearia
	Peixaria e Talho
	Frutas e Legumes
	Padaria e Pastelaria
	Beleza e Higiene
	Limpeza
*/
create table Mercado.Seccao (
    Codigo                  char(6),  
    Designacao              varchar(50),
    IDResp                  int,   
    primary key (Codigo, Designacao),
);

create table Mercado.Produto (
    CodProd                 char(3),  
    Preco                   decimal(5, 2)               not null,
    Marca                   varchar(50),   
    Nome                    varchar(50),
    CodSeccao				char(6),
    Designacao              varchar(50),     
	Stock                   int,
    primary key (CodProd),
);

create table Mercado.Repoe (
    Codigo                  char(6),  
    Designacao              varchar(50),
    IDReposicao             int,   
    primary key (Codigo, Designacao, IDReposicao),
);

/* Define foreign keys */

alter table Mercado.Resp_Op add constraint Resp_Op_supID_FK foreign key (IDsup) references Mercado.Chefe_Loja (ID);
alter table Mercado.Op_Caixa add constraint Op_Caixa_supID_FK foreign key (IDsup) references Mercado.Resp_Op (ID);
alter table Mercado.Op_Caixa add constraint Op_Caixa_Caixa_IDcaixa_FK foreign key (IDCaixa, CodAcesso) references Mercado.Caixa (ID, CodAcesso);
alter table Mercado.Atend_Cliente add constraint Atend_Client_supID_FK foreign key (IDsup) references Mercado.Resp_Op (ID);
alter table Mercado.Atend_Cliente add constraint Atend_Client_Balcao_ExtTelefone_FK foreign key (ExtTelefone) references Mercado.Balcao (ExtTelefone);
alter table Mercado.Reposicao add constraint Reposicao_supID_FK foreign key (IDsup) references Mercado.Resp_Op (ID);
alter table Mercado.Reposicao add constraint Reposicao_Armazem_CodArmazem_FK foreign key (CodArmazem) references Mercado.Armazem (CodAcesso);
alter table Mercado.Seccao add constraint Seccao_IDResp_FK foreign key (IDResp) references Mercado.Resp_Op (ID);
alter table Mercado.Produto add constraint Produto_Cod_FK foreign key (CodSeccao, Designacao) references Mercado.Seccao (Codigo, Designacao);
alter table Mercado.Repoe add constraint Repoe_Cod_FK foreign key (Codigo, Designacao) references Mercado.Seccao (Codigo, Designacao);
alter table Mercado.Repoe add constraint Repoe_ID_FK foreign key (IDReposicao) references Mercado.Reposicao (ID);