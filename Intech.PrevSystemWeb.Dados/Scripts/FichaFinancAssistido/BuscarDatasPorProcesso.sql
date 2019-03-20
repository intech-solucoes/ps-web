/*Config
    RetornaLista
    Retorno
        -FichaFinancAssistidoEntidade
    Parametros
        -SQ_PROCESSO:int
        -DT_REFERENCIA:DateTime
*/

SELECT DISTINCT FF.DT_COMPETENCIA
FROM fi_ficha_financ_assistido FF
     INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA
     INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA
WHERE FF.SQ_PROCESSO = @SQ_PROCESSO
  AND RU.IR_LANCAMENTO IN ('P', 'D')
  AND RU.EE_INCIDE_LIQUIDO = 'S'
  AND FF.DT_COMPETENCIA >= @DT_REFERENCIA
ORDER BY FF.DT_COMPETENCIA DESC