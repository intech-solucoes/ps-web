﻿/*Config
	RetornaLista
	Retorno
		-PatrocinadoraEntidade
*/

SELECT 
	FI_PATROCINADORA.*, 
	FI_PESSOA.NO_PESSOA
FROM FI_PATROCINADORA
INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = FI_PATROCINADORA.CD_PESSOA_PATR