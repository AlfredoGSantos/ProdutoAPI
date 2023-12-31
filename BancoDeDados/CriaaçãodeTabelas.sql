USE Autoglass
GO

CREATE SCHEMA Fornecedores
AUTHORIZATION dbo
GO

CREATE SCHEMA Produtos
AUTHORIZATION dbo
GO

CREATE TABLE Fornecedores.Fornecedores
(
	idFornecedor		INT NOT NULL IDENTITY(1,1),
	strCNPJ				VARCHAR(14) NOT NULL,
	strNome				VARCHAR(255) NOT NULL,

	CONSTRAINT PK_Fornecedor PRIMARY KEY (idFornecedor) ON FG_Dados
) ON FG_Dados
GO

CREATE TABLE Produtos.Status 
(
	idStatus		INT,
	strDescricao	VARCHAR(400),

	CONSTRAINT PK_ProdutosStatus PRIMARY KEY (idStatus) ON FG_Dados
) ON FG_Dados
GO

CREATE TABLE Produtos.Produtos 
(
	idProduto			INT NOT NULL IDENTITY(1,1),
	strDescricao		VARCHAR(MAX) NOT NULL,
	idStatus			INT NOT NULL,
	dtFabricacao		DATETIME,
	dtValidade			DATETIME,
	idFornecedor		INT,

	CONSTRAINT PK_Produto PRIMARY KEY (idProduto) ON FG_Dados,

	CONSTRAINT FK_Produto_Status FOREIGN KEY (idStatus)
	REFERENCES Produtos.Status (idStatus),

	CONSTRAINT FK_Produto_Forncedor FOREIGN KEY (idFornecedor)
	REFERENCES Fornecedores.Fornecedores (idFornecedor)
)