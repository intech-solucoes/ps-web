﻿/*Config
    RetornaLista
    Retorno
        -FichaContribPrevidencialEntidade
    Parametros
        -SQ_PLANO_PREVIDENCIAL:int
        -SQ_CONTRATO_TRABALHO:int
        -NATUREZA:string
*/

SELECT CO.SQ_PLANO_PREVIDENCIAL,
       FC.DS_TIPO_FUNDO,
       CO.IR_OPERACAO,
       SUM(CO.QT_COTA_CONTRIBUICAO) AS QT_COTA_CONTRIBUICAO          
  FROM fi_ficha_contrib_previdencial CO
       INNER JOIN fi_tipo_cobranca TC ON TC.SQ_TIPO_COBRANCA = CO.SQ_TIPO_COBRANCA
       INNER JOIN fi_fundo_contribuicao FC ON FC.SQ_TIPO_FUNDO = CO.SQ_TIPO_FUNDO AND FC.SQ_PLANO_PREVIDENCIAL = CO.SQ_PLANO_PREVIDENCIAL 
WHERE CO.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL
  AND CO.SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO
  AND TC.IC_NATUREZA_COBRANCA = @NATUREZA
GROUP BY CO.SQ_PLANO_PREVIDENCIAL,
       FC.DS_TIPO_FUNDO,
       FC.DS_TIPO_FUNDO,
       CO.IR_OPERACAO
ORDER BY CO.SQ_PLANO_PREVIDENCIAL, DS_TIPO_FUNDO, CO.IR_OPERACAO