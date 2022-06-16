-- Chefe de Loja
--insert into Mercado.Chefe_Loja (ID, NIF, SSN, Email, Morada, Nome, Telemovel, Salario, DInicio, DFim) values ('1', '548058844', '39572624308', 'zhischke2@state.tx.us', '172 Kinsman Parkway', 'Zolly Hischke', '939935190', 2000.0, '2000-01-01', '2008-12-27');
--insert into Mercado.Chefe_Loja (ID, NIF, SSN, Email, Morada, Nome, Telemovel, Salario, DInicio, DFim) values ('2', '061631522', '68967519341', 'sbracken1@google.es', '01090 Pond Road', 'Shelbi Bracken', '937163174', 2000.0, '2008-12-27', '2022-02-20');
--insert into Mercado.Chefe_Loja (ID, NIF, SSN, Email, Morada, Nome, Telemovel, Salario, DInicio, DFim) values ('3', '941502109', '48476885705', 'hbeastall0@pinterest.com', '89723 Hudson Alley', 'Hurlee Beastall', '931609671', 1500.0, '2022-02-20', null);

-- Responsável de operações
--insert into Mercado.Resp_Op (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, Categoria, DInicio, DFim) values ('2', '061631522', '68967519341', 'sbracken1@google.es', '1', '01090 Pond Road', 'Shelbi Bracken', '937163174', 2000.0, 'Atendimento', '2000-01-01', '2008-12-27'); -- aten
--insert into Mercado.Resp_Op (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, Categoria, DInicio, DFim) values ('4', '992965365', '55321293107', 'sisakovitch0@so-net.ne.jp', '1', '0878 Bayside Junction', 'Stephan Isakovitch', '934932497', 2000.0, 'Caixa', '2000-01-01', '2006-08-04'); -- caixa
--insert into Mercado.Resp_Op (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, Categoria, DInicio, DFim) values ('5', '342973196', '90445203621', 'colyunin2@mozilla.org', '3', '19 Lien Trail', 'Clarisse Olyunin', '936643871', 2000.0, 'Reposição', '2000-01-01', null); -- rep
--insert into Mercado.Resp_Op (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, Categoria, DInicio, DFim) values ('3', '941502109', '48476885705', 'hbeastall0@pinterest.com', '2', '89723 Hudson Alley', 'Hurlee Beastall', '931609671', 1500.0, 'Caixa', '2006-08-04', '2022-02-20'); -- caixa
--insert into Mercado.Resp_Op (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, Categoria, DInicio, DFim) values ('6', '931326712', '12561969830', 'jclarkewilliams0@toplist.cz', '3', '230 Kings Drive', 'Josh Clarke-Williams', '931893927', 2000.0, 'Atendimento', '2008-12-27', null); -- atend atual
--insert into Mercado.Resp_Op (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, Categoria, DInicio, DFim) values ('7', '229930912', '91592154981', 'janshell1@scribd.com', '3', '422 Main Center', 'Juliane Anshell', '938454867', 2000.0, 'Caixa', '2022-02-20', null); -- caixa atual

-- Caixa
--insert into Mercado.Caixa (ID, CodAcesso, ExtTelefone) values ('1', '794676', '123');
--insert into Mercado.Caixa (ID, CodAcesso, ExtTelefone) values ('2', '573671', '456');
--insert into Mercado.Caixa (ID, CodAcesso, ExtTelefone) values ('3', '634745', '789');

---- Operador de Caixa
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('3', '941502109', '48476885705', 'hbeastall0@pinterest.com', '4', '89723 Hudson Alley', 'Hurlee Beastall', '931609671', 1500.0, '1', '794676', '2000-01-01', '2006-08-04'); 
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('7', '229930912', '91592154981', 'janshell1@scribd.com', '3', '422 Main Center', 'Juliane Anshell', '938454867', 2000.0, '3', '634745', '2010-05-23','2022-02-20'); 
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('8', '775251927', '11759943643', 'bohms0@bluehost.com', '3', '14831 Meadow Ridge Drive', 'Brice Ohms', '933273629', 2000.0, '2', '573671', '2003-02-01', '2015-10-09');
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('9', '243936224', '91848275852', 'nmicklewicz1@google.co.uk', '7', '70667 Boyd Drive', 'Natassia Micklewicz', '935525329', 2000.0, '3', '634745', '2014-04-07', null);
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('10', '138969514', '60423765168', 'astelle2@bravesites.com', '7', '27483 Thompson Avenue', 'Aggy Stelle', '935507811', 2000.0, '1', '794676', '2005-07-12', null);
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('11', '311582972', '46859413183', 'rcurman3@odnoklassniki.ru', '7', '4 International Trail', 'Rickert Curman', '934374371', 2000.0, '2', '573671', '2017-07-05', null);
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('12', '005443353', '61352424492', 'dpartkya4@usatoday.com', '3', '025 Nova Street', 'Dacia Partkya', '933918517', 2000.0, '2', '573671', '2000-06-19', '2003-08-17');
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('13', '947279757', '54295045182', 'abeagrie5@youtube.com', '7', '33 David Avenue', 'Aland Beagrie', '936439885', 2000.0, '3', '634745', '2014-02-03', null);
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('14', '825517058', '00796806198', 'dmilesap6@gnu.org', '7', '9744 Spenser Lane', 'Denys Milesap', '934446410', 2000.0, '2', '573671', '2011-07-12', null);
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('15', '053014787', '77748373348', 'adanhel7@typepad.com', '7', '060 Pearson Road', 'Addia Danhel', '933917682', 2000.0, '1', '794676', '2013-12-23', null);
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('16', '681763268', '85223121467', 'lleake8@netvibes.com', '3', '21 Daystar Terrace', 'Lenee Leake', '938251077', 2000.0, '1', '794676', '2000-07-10', '2013-12-23');
--insert into Mercado.Op_Caixa (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, IDCaixa, CodAcesso, DInicio, DFim) values ('17', '150333153', '96555668181', 'tfranciskiewicz9@jiathis.com', '3', '97 Grayhawk Plaza', 'Tessi Franciskiewicz', '932999876', 2000.0, '3', '634745', '2001-04-28', '2011-11-19');

-- Balcao
insert into Mercado.Balcao (ExtTelefone) values ('372');

-- Atendimento
insert into Mercado.Atend_Cliente (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, ExtTelefone, DInicio, DFim) values ('6', '931326712', '12561969830', 'jclarkewilliams0@toplist.cz', '2', '230 Kings Drive', 'Josh Clarke-Williams', '931893927', 2000.0, '372', '2000-01-01', '2008-12-27'); -- atend atual
insert into Mercado.Atend_Cliente (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, ExtTelefone, DInicio, DFim) values ('5', '332027386', '75175205421', 'gdavenell0@freewebs.com', '2', '5 Cordelia Way', 'Gerrie Davenell', '934072723', 805.54, '372', '2011-06-15', '2016-11-05');
insert into Mercado.Atend_Cliente (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, ExtTelefone, DInicio, DFim) values ('0', '664782796', '04978406389', 'ddobbyn1@cloudflare.com', '9', '61 Schmedeman Hill', 'Daffie Dobbyn', '932062835', 832.3, '372', '2010-09-15', '2015-10-14');
insert into Mercado.Atend_Cliente (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, ExtTelefone, DInicio, DFim) values ('8', '501607013', '72361679438', 'rchevolleau2@indiatimes.com', '6', '91 Lyons Junction', 'Rooney Chevolleau', '934122665', 768.38, '372', '2002-07-21', '2009-06-29');
insert into Mercado.Atend_Cliente (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, ExtTelefone, DInicio, DFim) values ('9', '092377448', '12467129242', 'dparramore3@t.co', '8', '76 Thackeray Park', 'Durant Parramore', '938446789', 812.79, '372', '2000-05-08', '2011-10-30');
insert into Mercado.Atend_Cliente (ID, NIF, SSN, Email, IDSup, Morada, Nome, Telemovel, Salario, ExtTelefone, DInicio, DFim) values ('2', '208543644', '26265651654', 'berb4@hao123.com', '5', '305 Sunfield Junction', 'Bryan Erb', '930096409', 860.59, '372', '2000-09-26', '2015-03-28');

select * from Mercado.Chefe_Loja
select * from Mercado.Resp_Op
select * from Mercado.Caixa
select * from Mercado.Op_Caixa