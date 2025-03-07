
CREATE TABLE Cliente 
(
pk_id_cliente int identity primary key ,
nome_cliente varchar(100)  ,
tipo_cliente varchar(15) ,
tel_cliente numeric(15) ,
status_cliente varchar(15) ,
fav_cliente varchar(15) ,
endereco_cliente varchar(300) ,
documento_cliente varchar(20)  
)

SELECT *  FROM Cliente 

CREATE TABLE Equipamento 
(
 pk_id_equipamento int identity primary key ,
nome_equipamento varchar(100) not null,
descricao_equipamento varchar(200),
tipo_equipamento varchar(20) ,
valor_equipamento DECIMAL(20, 2) 
)

SELECT *  FROM Equipamento

CREATE TABLE Ordem_de_Servico
(
pk_id_servico int identity primary key ,
fk_id_cliente int,
data_servico DATE,
status_servico varchar(15) ,
forma_pagamento_servico varchar(25) ,
valor_servico DECIMAL(20, 2) ,
valor_pago DECIMAL(20,2),
valor_deve as valor_servico - valor_pago PERSISTED,
FOREIGN KEY (fk_id_cliente) REFERENCES Cliente (pk_id_cliente)
)

SELECT * FROM Ordem_de_Servico

CREATE TABLE Aluguel
(
pk_id_aluguel int identity primary key,
fk_id_ordemServico int,
fk_id_equipamento int,
quant_aluguel numeric(6),
valor_equipamento_aluguel DECIMAL(20, 2)
FOREIGN KEY (fk_id_ordemServico) REFERENCES Ordem_de_Servico (pk_id_servico),
FOREIGN KEY (fk_id_equipamento) REFERENCES Equipamento ( pk_id_equipamento)
)

SELECT *  FROM Aluguel

CREATE TABLE Conecte(
pk_id_user int identity primary key,
nome_user varchar(20) unique not null,
senha_user varchar(64) not null,
email_user varchar(100) unique not null,
habilitado BIT
)

CREATE TABLE Orcamentos (
    Id_Orcamentos INT PRIMARY KEY IDENTITY,
    Nome_Orcamentos NVARCHAR(100),
    Arquivo_Orcamentos VARBINARY(MAX)
)

CREATE TABLE Registros (
    Id_Registros INT PRIMARY KEY IDENTITY,
	 Hora_Registros VARCHAR(100),
    Nome_Registros NVARCHAR(100),
    Arquivo_Registros VARBINARY(MAX)
);

select * from Registros

INSERT INTO Conecte (nome_user, senha_user,email_user,habilitado)
VALUES ('vitin','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3','vcordeirosilva79@gmail.com',1)
  SELECT *  FROM Conecte
INSERT INTO Cliente (nome_cliente, tipo_cliente, tel_cliente, status_cliente, fav_cliente, endereco_cliente, documento_cliente)
VALUES 
('Carlos Silva', 'Fisica', 11999998888, 'Ativo', 'Sim', 'Rua Exemplo, 123, SP', '12345678901'),
('Maria Souza', 'Juridica', 21988887777, 'Ativo', 'Não', 'Av. Central, 456, RJ', '98765432100'),
('Pedro Rocha', 'Fisica', 31977776666, 'Arquivado', 'Sim', 'Rua das Palmeiras, 789, MG', '45678912301'),
('João Lima', 'Juridica', 41966665555, 'Ativo', 'Não', 'Alameda Santos, 321, PR', '23456789001'),
('Ana Oliveira', 'Fisica', 51955554444, 'Arquivado', 'Sim', 'Rua das Flores, 987, RS', '34567890123'),
('Fernanda Alves', 'Juridica', 61944443333, 'Ativo', 'Sim', 'Rua do Comércio, 111, DF', '11223344556'),
('Juliana Pereira', 'Fisica', 11933332222, 'Ativo', 'Não', 'Rua dos Pinheiros, 222, SP', '55667788900'),
('Gustavo Ramos', 'Juridica', 21922221111, 'Ativo', 'Sim', 'Av. das Américas, 333, RJ', '66778899001'),
('Lucas Menezes', 'Fisica', 31911110000, 'Arquivado', 'Não', 'Rua da Liberdade, 444, MG', '77889900112'),
('Sofia Machado', 'Juridica', 41999998877, 'Ativo', 'Sim', 'Av. Brasil, 555, PR', '88990011223'),
('Rafael Martins', 'Fisica', 51988887766, 'Ativo', 'Não', 'Rua Jardim, 666, RS', '99001122334'),
('Eduardo Nogueira', 'Juridica', 61977776655, 'Arquivado', 'Sim', 'Rua Principal, 777, DF', '00112233445'),
('Helena Costa', 'Fisica', 11966665544, 'Ativo', 'Sim', 'Rua das Laranjeiras, 888, SP', '11223344567'),
('André Cardoso', 'Juridica', 21955554433, 'Ativo', 'Não', 'Av. Atlântica, 999, RJ', '22334455678'),
('Larissa Fernandes', 'Fisica', 31944443322, 'Arquivado', 'Sim', 'Rua Nova, 1000, MG', '33445566789'),
('Ricardo Alves', 'Juridica', 41933332211, 'Ativo', 'Sim', 'Rua Velha, 1111, PR', '44556677890'),
('Tiago Oliveira', 'Fisica', 51922221100, 'Ativo', 'Não', 'Rua Alegre, 1222, RS', '55667788901'),
('Camila Borges', 'Juridica', 61911110099, 'Arquivado', 'Sim', 'Av. Boa Vista, 1333, DF', '66778899012'),
('Felipe Moreira', 'Fisica', 11999998877, 'Ativo', 'Não', 'Rua Bonita, 1444, SP', '77889900123'),
('Beatriz Lima', 'Juridica', 21988887766, 'Ativo', 'Sim', 'Rua dos Coqueiros, 1555, RJ', '88990011234'),
('Gabriel Teixeira', 'Fisica', 31977776655, 'Arquivado', 'Sim', 'Rua Estrela, 1666, MG', '99001122345'),
('Vinícius Mendes', 'Juridica', 41966665544, 'Ativo', 'Não', 'Av. Solar, 1777, PR', '00112233456'),
('Isabela Santos', 'Fisica', 51955554433, 'Ativo', 'Sim', 'Rua Pôr do Sol, 1888, RS', '11223344578'),
('Rodrigo Xavier', 'Juridica', 61944443322, 'Arquivado', 'Sim', 'Rua Esperança, 1999, DF', '22334455689'),
('Mariana Costa', 'Fisica', 11933332211, 'Ativo', 'Não', 'Rua da Paz, 2000, SP', '33445566790'),
('Leonardo Souza', 'Juridica', 21922221100, 'Ativo', 'Sim', 'Rua da Lua, 2111, RJ', '44556677801'),
('Aline Castro', 'Fisica', 31911110099, 'Arquivado', 'Sim', 'Rua do Sol, 2222, MG', '55667788912'),
('Bruno Gomes', 'Juridica', 41999998888, 'Ativo', 'Não', 'Av. das Palmeiras, 2333, PR', '66778899023'),
('Letícia Dias', 'Fisica', 51988887777, 'Ativo', 'Sim', 'Rua Alegre, 2444, RS', '77889900134'),
('Diego Albuquerque', 'Juridica', 61977776666, 'Arquivado', 'Não', 'Rua Central, 2555, DF', '88990011245');

SELECT *  FROM Cliente 


