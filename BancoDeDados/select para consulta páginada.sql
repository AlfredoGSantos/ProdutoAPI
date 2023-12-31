USE Autoglass
GO

DECLARE @CodigoProduto INT, @CodigoFornecedor INT, @Descricao VARCHAR(MAX), @DescricaoFornecedor VARCHAR(255),
	@Pagina INT = 1, @ItensPagina INT = 10, @OrdenarPor VARCHAR(100), @OrdenacaoCrescente BIT

SELECT 
	Produto.idProduto,
	Produto.strDescricao,
	Status.idStatus,
	Status.strDescricao AS strDescricaoStatus,
	Produto.dtFabricacao,
	Produto.dtValidade,
	Fornecedor.idFornecedor,
	Fornecedor.strNome,
	Fornecedor.strCNPJ
FROM Produtos.Produtos				Produto				WITH (NOLOCK)
INNER JOIN Produtos.Status			Status				WITH (NOLOCK)
		ON Status.idStatus			= Produto.idStatus
LEFT JOIN Fornecedores.Fornecedores	Fornecedor			WITH (NOLOCK)
		ON Fornecedor.idFornecedor	= Produto.idFornecedor
WHERE 
	Status.idStatus = 1
AND (@CodigoProduto IS NULL OR (@CodigoProduto IS NOT NULL AND Produto.idProduto = @CodigoProduto))
AND (@CodigoFornecedor IS NULL OR (@CodigoFornecedor IS NOT NULL AND Fornecedor.idFornecedor = @CodigoFornecedor))
AND (@Descricao IS NULL OR (@Descricao IS NOT NULL AND Produto.strDescricao LIKE '%' + @Descricao + '%'))
AND (@DescricaoFornecedor IS NULL OR (@DescricaoFornecedor IS NOT NULL AND Fornecedor.strNome LIKE '%' + @DescricaoFornecedor + '%'))
ORDER BY 
	CASE WHEN @OrdenarPor IS NULL AND @OrdenacaoCrescente IS NULL THEN Produto.idProduto END ASC,
	CASE WHEN (@OrdenarPor IS NULL OR @OrdenarPor = 'CodigoProduto') AND @OrdenacaoCrescente = 1 THEN Produto.idProduto END ASC,
	CASE WHEN (@OrdenarPor IS NULL OR @OrdenarPor = 'CodigoProduto') AND @OrdenacaoCrescente = 0 THEN Produto.idProduto END DESC,
	CASE WHEN @OrdenarPor = 'Descricao' AND @OrdenacaoCrescente = 0 THEN Produto.strDescricao END ASC,
	CASE WHEN @OrdenarPor = 'Descricao' AND @OrdenacaoCrescente = 1 THEN Produto.strDescricao END DESC,
	CASE WHEN @OrdenarPor = 'DataFabricacao' AND @OrdenacaoCrescente = 0 THEN Produto.dtFabricacao END ASC,
	CASE WHEN @OrdenarPor = 'DataFabricacao' AND @OrdenacaoCrescente = 1 THEN Produto.dtFabricacao END DESC,
	CASE WHEN @OrdenarPor = 'DataValidade' AND @OrdenacaoCrescente = 0 THEN Produto.dtValidade END ASC,
	CASE WHEN @OrdenarPor = 'DataValidade' AND @OrdenacaoCrescente = 1 THEN Produto.dtValidade END DESC,
	CASE WHEN @OrdenarPor = 'CodigoFornecedor' AND @OrdenacaoCrescente = 0 THEN Fornecedor.idFornecedor END ASC,
	CASE WHEN @OrdenarPor = 'CodigoFornecedor' AND @OrdenacaoCrescente = 1 THEN Fornecedor.idFornecedor END DESC,
	CASE WHEN @OrdenarPor = 'DescricaoFornecedor' AND @OrdenacaoCrescente = 0 THEN Fornecedor.strNome END ASC,
	CASE WHEN @OrdenarPor = 'DescricaoFornecedor' AND @OrdenacaoCrescente = 1 THEN Fornecedor.strNome END DESC,
	CASE WHEN @OrdenarPor = 'CNPJ' AND @OrdenacaoCrescente = 0 THEN Fornecedor.strCNPJ END ASC,
	CASE WHEN @OrdenarPor = 'CNPJ' AND @OrdenacaoCrescente = 1 THEN Fornecedor.strCNPJ END DESC
OFFSET (@Pagina - 1) * @ItensPagina ROWS FETCH NEXT @ItensPagina ROWS ONLY

SELECT 
	COUNT(Produto.idProduto) AS NumeroRegistros
FROM Produtos.Produtos				Produto				WITH (NOLOCK)
INNER JOIN Produtos.Status			Status				WITH (NOLOCK)
		ON Status.idStatus			= Produto.idStatus
LEFT JOIN Fornecedores.Fornecedores	Fornecedor			WITH (NOLOCK)
		ON Fornecedor.idFornecedor	= Produto.idFornecedor
WHERE 
	Status.idStatus = 1
AND (@CodigoProduto IS NULL OR (@CodigoProduto IS NOT NULL AND Produto.idProduto = @CodigoProduto))
AND (@CodigoFornecedor IS NULL OR (@CodigoFornecedor IS NOT NULL AND Fornecedor.idFornecedor = @CodigoFornecedor))
AND (@Descricao IS NULL OR (@Descricao IS NOT NULL AND Produto.strDescricao LIKE '%' + @Descricao + '%'))
AND (@DescricaoFornecedor IS NULL OR (@DescricaoFornecedor IS NOT NULL AND Fornecedor.strNome LIKE '%' + @DescricaoFornecedor + '%'))