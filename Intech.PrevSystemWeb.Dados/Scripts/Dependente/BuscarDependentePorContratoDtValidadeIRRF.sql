﻿/*Config
    RetornaLista
    Retorno
        -DependenteEntidade
    Parametros
        -SQ_CONTRATO_TRABALHO:int
        -DT_TERM_VALIDADE:DateTime
*/

SELECT FI_DEPENDENTE.*
FROM FI_DEPENDENTE
    INNER JOIN FI_CONTRATO_TRABALHO ON FI_CONTRATO_TRABALHO.CD_PESSOA = FI_DEPENDENTE.CD_PESSOA_PAI
WHERE (FI_CONTRATO_TRABALHO.SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO)
  AND (FI_DEPENDENTE.DT_TERM_VALIDADE IS NULL OR FI_DEPENDENTE.DT_TERM_VALIDADE < @DT_TERM_VALIDADE)
  AND (FI_DEPENDENTE.IR_ABATIMENTO_IRRF = 'S')