﻿/*Config
    RetornaLista
    Retorno
        -IRRFFaixaRegressivoEntidade
*/

SELECT * FROM FI_IRRF_FAIXA_REGRESSIVO
WHERE DT_INIC_VALIDADE = (SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF_FAIXA_REGRESSIVO)