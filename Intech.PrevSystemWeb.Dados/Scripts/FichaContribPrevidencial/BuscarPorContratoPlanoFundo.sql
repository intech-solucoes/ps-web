﻿/*Config
    RetornaLista
    Retorno
        -FichaContribPrevidencialEntidade
    Parametros
        -SQ_CONTRATO_TRABALHO:int
        -SQ_PLANO_PREVIDENCIAL:int
        -SQ_TIPO_FUNDO:int
*/

SELECT 
	FI_FICHA_CONTRIB_PREVIDENCIAL.*,
    FI_FUNDO_CONTRIBUICAO.DS_TIPO_FUNDO,
	FI_TIPO_COBRANCA.DS_TIPO_COBRANCA
FROM FI_FICHA_CONTRIB_PREVIDENCIAL 
INNER JOIN FI_FUNDO_CONTRIBUICAO ON FI_FUNDO_CONTRIBUICAO.SQ_TIPO_FUNDO = FI_FICHA_CONTRIB_PREVIDENCIAL.SQ_TIPO_FUNDO
INNER JOIN FI_TIPO_COBRANCA ON FI_TIPO_COBRANCA.SQ_TIPO_COBRANCA = FI_FICHA_CONTRIB_PREVIDENCIAL.SQ_TIPO_COBRANCA
WHERE FI_FICHA_CONTRIB_PREVIDENCIAL.SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO
  AND FI_FICHA_CONTRIB_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL
  AND FI_FICHA_CONTRIB_PREVIDENCIAL.SQ_TIPO_FUNDO = @SQ_TIPO_FUNDO
ORDER BY ID_CONTRIBUICAO