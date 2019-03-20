/*Config
    RetornaLista
    Retorno
        -FichaFinancAssistidoEntidade
    Parametros
        -SQ_PROCESSO:int
        -DT_COMPETENCIA:DateTime
*/

SELECT FF.*,
       RU.DS_RUBRICA,
       CASE
            WHEN FF.IR_LANCAMENTO = 'P' THEN 'PROVENTO'
            WHEN FF.IR_LANCAMENTO = 'D' THEN 'DESCONTO'
       END AS DS_LANCAMENTO
FROM fi_ficha_financ_assistido FF
     INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA
     INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA
WHERE FF.SQ_PROCESSO = @SQ_PROCESSO
  AND FF.DT_COMPETENCIA = @DT_COMPETENCIA
  AND RU.IR_LANCAMENTO IN ('P', 'D')
  AND RU.EE_INCIDE_LIQUIDO = 'S'
ORDER BY RU.IR_LANCAMENTO DESC