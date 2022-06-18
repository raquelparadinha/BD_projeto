-- Chefe de Loja
insert into Mercado.Chefe_Loja values ('1', '548058844', '39572624308', 'zhischke2@state.tx.us', '172 Kinsman Parkway', 'Zolly Hischke', '939935190', 1993.05, '2000-01-01', '2008-12-27');
insert into Mercado.Chefe_Loja values ('2', '061631522', '68967519341', 'sbracken1@google.es', '01090 Pond Road', 'Shelbi Bracken', '937163174', 1897.05, '2008-12-27', '2022-02-20');
insert into Mercado.Chefe_Loja values ('5', '941502109', '48476885705', 'hbeastall0@pinterest.com', '89723 Hudson Alley', 'Hurlee Beastall', '931609671', 1560.22, '2022-02-20', null);

-- Responsável de operações
insert into Mercado.Resp_Op values ('2', '061631522', '68967519341', 'sbracken1@google.es', '1', '01090 Pond Road', 'Shelbi Bracken', '937163174', 1051.31, 'Atendimento', '2000-01-01', '2008-12-27'); -- aten
insert into Mercado.Resp_Op values ('3', '992965365', '55321293107', 'sisakovitch0@so-net.ne.jp', '1', '0878 Bayside Junction', 'Stephan Isakovitch', '934932497', 1306.85, 'Caixa', '2000-01-01', '2006-08-04'); -- caixa
insert into Mercado.Resp_Op values ('4', '342973196', '90445203621', 'colyunin2@mozilla.org', '5', '19 Lien Trail', 'Clarisse Olyunin', '936643871', 1023.0, 'Reposição', '2000-01-01', null); -- rep atual
insert into Mercado.Resp_Op values ('5', '941502109', '48476885705', 'hbeastall0@pinterest.com', '2', '89723 Hudson Alley', 'Hurlee Beastall', '931609671', 1027.6, 'Caixa', '2006-08-04', '2022-02-20'); -- caixa
insert into Mercado.Resp_Op values ('6', '931326712', '12561969830', 'jclarkewilliams0@toplist.cz', '5', '230 Kings Drive', 'Josh Clarke-Williams', '931893927', 1286.65, 'Atendimento', '2008-12-27', null); -- atend atual
insert into Mercado.Resp_Op values ('21', '229930912', '91592154981', 'janshell1@scribd.com', '5', '422 Main Center', 'Juliane Anshell', '938454867', 1361.24, 'Caixa', '2022-02-20', null); -- caixa atual

-- Caixa
insert into Mercado.Caixa values ('1', '794676', '123');
insert into Mercado.Caixa values ('2', '573671', '456');
insert into Mercado.Caixa values ('3', '634745', '789');

-- Operador de Caixa
insert into Mercado.Op_Caixa values ('5', '941502109', '48476885705', 'hbeastall0@pinterest.com', '3', '89723 Hudson Alley', 'Hurlee Beastall', '931609671', 902.01, '1', '794676', '2000-01-01', '2006-08-04'); 
insert into Mercado.Op_Caixa values ('10', '005443353', '61352424492', 'dpartkya4@usatoday.com', '3', '025 Nova Street', 'Dacia Partkya', '933918517', 958.54, '2', '573671', '2000-06-19', '2003-08-17');
insert into Mercado.Op_Caixa values ('11', '681763268', '85223121467', 'lleake8@netvibes.com', '5', '21 Daystar Terrace', 'Lenee Leake', '938251077', 768.50, '1', '794676', '2000-07-10', '2013-12-23');
insert into Mercado.Op_Caixa values ('12', '150333153', '96555668181', 'tfranciskiewicz9@jiathis.com', '5', '97 Grayhawk Plaza', 'Tessi Franciskiewicz', '932999876', 785.05, '3', '634745', '2001-04-28', '2011-11-19');
insert into Mercado.Op_Caixa values ('15', '775251927', '11759943643', 'bohms0@bluehost.com', '5', '14831 Meadow Ridge Drive', 'Brice Ohms', '933273629', 874.06, '2', '573671', '2003-02-01', '2015-10-09');
insert into Mercado.Op_Caixa values ('18', '138969514', '60423765168', 'astelle2@bravesites.com', '21', '27483 Thompson Avenue', 'Aggy Stelle', '935507811', 871.69, '1', '794676', '2005-07-12', null);
insert into Mercado.Op_Caixa values ('21', '229930912', '91592154981', 'janshell1@scribd.com', '5', '422 Main Center', 'Juliane Anshell', '938454867', 966.46, '3', '634745', '2010-05-23','2022-02-20'); 
insert into Mercado.Op_Caixa values ('23', '825517058', '00796806198', 'dmilesap6@gnu.org', '21', '9744 Spenser Lane', 'Denys Milesap', '934446410', 800.43, '2', '573671', '2011-07-12', null);
insert into Mercado.Op_Caixa values ('24', '053014787', '77748373348', 'adanhel7@typepad.com', '21', '060 Pearson Road', 'Addia Danhel', '933917682', 867.10, '1', '794676', '2013-12-23', null);
insert into Mercado.Op_Caixa values ('25', '947279757', '54295045182', 'abeagrie5@youtube.com', '21', '33 David Avenue', 'Aland Beagrie', '936439885', 990.72, '3', '634745', '2014-02-03', null);
insert into Mercado.Op_Caixa values ('26', '243936224', '91848275852', 'nmicklewicz1@google.co.uk', '21', '70667 Boyd Drive', 'Natassia Micklewicz', '935525329', 948.47, '3', '634745', '2014-04-07', null);
insert into Mercado.Op_Caixa values ('29', '311582972', '46859413183', 'rcurman3@odnoklassniki.ru', '21', '4 International Trail', 'Rickert Curman', '934374371', 966.43, '2', '573671', '2017-07-05', null);

-- Balcao
insert into Mercado.Balcao values ('372');

-- Atendimento
insert into Mercado.Atend_Cliente values ('6', '931326712', '12561969830', 'jclarkewilliams0@toplist.cz', '2', '230 Kings Drive', 'Josh Clarke-Williams', '931893927', 990.10, '372', '2000-01-01', '2008-12-27');
insert into Mercado.Atend_Cliente values ('9', '092377448', '12467129242', 'dparramore3@t.co', '6', '76 Thackeray Park', 'Durant Parramore', '938446789', 812.79, '372', '2000-05-08', '2011-10-30');
insert into Mercado.Atend_Cliente values ('14', '501607013', '72361679438', 'rchevolleau2@indiatimes.com', '6', '91 Lyons Junction', 'Rooney Chevolleau', '934122665', 768.38, '372', '2002-07-21', '2009-06-29');
insert into Mercado.Atend_Cliente values ('20', '664782796', '04978406389', 'ddobbyn1@cloudflare.com', '6', '61 Schmedeman Hill', 'Daffie Dobbyn', '932062835', 832.3, '372', '2008-09-15', null);
insert into Mercado.Atend_Cliente values ('22', '332027386', '75175205421', 'gdavenell0@freewebs.com', '6', '5 Cordelia Way', 'Gerrie Davenell', '934072723', 805.54, '372', '2011-06-15', null);
insert into Mercado.Atend_Cliente values ('27', '208543644', '26265651654', 'berb4@hao123.com', '6', '305 Sunfield Junction', 'Bryan Erb', '930096409', 860.59, '372', '2015-03-28', null);

-- Armazem
insert into Mercado.Armazem values ('603692');

-- Reposição
insert into Mercado.Reposicao values ('7', '020721912', '75077058127', 'awharmby0@netlog.com', '4', '0840 Merrick Lane', 'Alfy Wharmby', '982336176', 853.12, '603692', '2000-01-01', '2021-12-29');
insert into Mercado.Reposicao values ('8', '815477594', '34368456458', 'cbocken2@usgs.gov', '4', '10460 Clove Terrace', 'Carleen Bocken', '908618450', 842.5, '603692', '2000-01-01', '2012-05-21');
insert into Mercado.Reposicao values ('13', '192483177', '26755940943', 'rmundall1@youku.com', '4', '7790 Annamark Court', 'Raviv Mundall', '909964940', 986.68, '603692', '2002-04-30', null);
insert into Mercado.Reposicao values ('16', '804647501', '67726195405', 'abartlosz3@xing.com', '4', '445 Bartillon Road', 'Artie Bartlosz', '943656859', 849.82, '603692', '2004-10-02', '2017-09-05');
insert into Mercado.Reposicao values ('17', '196814537', '60303140729', 'shinners5@reuters.com', '4', '4675 Melody Parkway', 'Stephanie Hinners', '969841800', 918.2, '603692', '2005-05-05', null);
insert into Mercado.Reposicao values ('19', '186125225', '48444064884', 'snelane4@seesaa.net', '4', '55883 Old Shore Pass', 'Shaina Nelane', '916755183', 947.93, '603692', '2005-07-16', null);
insert into Mercado.Reposicao values ('28', '042610145', '77459069617', 'scritchell6@printfriendly.com', '4', '1280 Mesta Trail', 'Scotty Critchell', '964337592', 978.19, '603692', '2016-03-20', null);

-- Seccção
insert into Mercado.Seccao values ('344312', 'Mercearia', '4');
insert into Mercado.Seccao values ('227853', 'Peixaria e Talho', '4');
insert into Mercado.Seccao values ('142815', 'Frutas e Legumes', '4');
insert into Mercado.Seccao values ('914671', 'Padaria e Pastelaria', '4');
insert into Mercado.Seccao values ('992369', 'Beleza e Higiene', '4');
insert into Mercado.Seccao values ('352480', 'Limpeza', '4');

--Produto
insert into Mercado.Produto values ('100', 1.33, 'Bom Petisco', 'Atum Posta em Azeite', '344312', 'Mercearia', 802);
insert into Mercado.Produto values ('101', 3.99, 'Gallo', 'Azeite Virgem Extra', '344312', 'Mercearia', 631);
insert into Mercado.Produto values ('102', 0.86, 'Milaneza', 'Massa Esparguete', '344312', 'Mercearia', 977);
insert into Mercado.Produto values ('103', 3.79, 'Buondi', 'Cápsulas de Café Original', '344312', 'Mercearia', 774);
insert into Mercado.Produto values ('104', 9.99, 'Iglo', 'Tranches de Salmão', '227853', 'Peixaria e Talho', 359);
insert into Mercado.Produto values ('105', 6.69, 'Prime Meat', 'Hambúrguer 100% Carne de Bovino', '227853', 'Peixaria e Talho', 886);
insert into Mercado.Produto values ('106', 5.53, 'Pescanova', 'Miolo de Camarão Grande', '227853', 'Peixaria e Talho', 963);
insert into Mercado.Produto values ('107', 1.99, 'Mercadão', 'Morango', '142815', 'Frutas e Legumes', 849);
insert into Mercado.Produto values ('108', 0.75, 'Mercadão', 'Cenoura Embalada', '142815', 'Frutas e Legumes', 955);
insert into Mercado.Produto values ('109', 1.79, 'Mercadão', 'Curgete Verde', '142815', 'Frutas e Legumes', 410);
insert into Mercado.Produto values ('110', 1.99, 'Mercadão', 'Pera Rocha', '142815', 'Frutas e Legumes', 191);
insert into Mercado.Produto values ('111', 2.19, 'Nespa', 'Mini Queques de Manteiga', '914671', 'Padaria e Pastelaria', 227);
insert into Mercado.Produto values ('112', 1.99, 'Museu do Pão', 'Broa de Milho de Serra da Estrela', '914671', 'Padaria e Pastelaria', 76);
insert into Mercado.Produto values ('113', 1.69, 'Bimbo', 'Pão de Forma sem Côdea', '914671', 'Padaria e Pastelaria', 944);
insert into Mercado.Produto values ('114', 5.99, 'Listerine', 'Elixir Dentes e Gengivas', '992369', 'Beleza e Higiene', 604);
insert into Mercado.Produto values ('115', 12.59, 'Garnier', 'Protetor Solar', '992369', 'Beleza e Higiene', 374);
insert into Mercado.Produto values ('116', 11.55, 'Garnier', 'Champô Ultra Suave Camomila', '992369', 'Beleza e Higiene', 206);
insert into Mercado.Produto values ('117', 17.24, 'Persil', 'Detergente Máquina Roupa', '352480', 'Limpeza', 903);
insert into Mercado.Produto values ('118', 1.29, 'Mercadão', 'Guardanapos 2 folhas', '352480', 'Limpeza', 148);
insert into Mercado.Produto values ('119', 3.32, 'Neoblanc', 'Lixívia Perfumada', '352480', 'Limpeza', 998);

-- Repoe
insert into Mercado.Repoe values ('344312', 'Mercearia', 13); 
insert into Mercado.Repoe values ('914671', 'Padaria e Pastelaria', 13); 
insert into Mercado.Repoe values ('227853', 'Peixaria e Talho', 17); 
insert into Mercado.Repoe values ('142815', 'Frutas e Legumes', 17); 
insert into Mercado.Repoe values ('992369', 'Beleza e Higiene', 19); 
insert into Mercado.Repoe values ('352480', 'Limpeza', 19); 
insert into Mercado.Repoe values ('227853', 'Peixaria e Talho', 28); 
insert into Mercado.Repoe values ('142815', 'Frutas e Legumes', 28); 
