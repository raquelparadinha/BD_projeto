USE p8g2
GO

CREATE FUNCTION Mercado.checkIfIDExists (@ID INT) RETURNS INT
AS
	BEGIN
		DECLARE @counter INT
		SELECT @counter=COUNT(1) FROM Mercado.Chefe_Loja WHERE ID=@ID
		IF(@ID IS NULL)
			SELECT @counter=COUNT(1) FROM Mercado.Resp_Op WHERE ID=@ID
		IF(@ID IS NULL)
			SELECT @counter=COUNT(1) FROM Mercado.Atend_Cliente WHERE ID=@ID
		IF(@ID IS NULL)
			SELECT @counter=COUNT(1) FROM Mercado.Op_caixa WHERE ID=@ID
		IF(@ID IS NULL)
			SELECT @counter=COUNT(1) FROM Mercado.Reposicao WHERE ID=@ID

			PRINT(@counter)
		RETURN @counter
	END
GO

select Mercado.Chefe_Loja.ID from 