﻿/*Config
    Retorno
        -IRRFEntidade
*/

SELECT * FROM FI_IRRF
WHERE DT_INIC_VALIDADE = (SELECT MAX(DT_INIC_VALIDADE) FROM FI_IRRF)