﻿/*Config
    RetornaLista
    Retorno
        -ComprovanteRendimentosEntidade
    Parametros
        -CD_PESSOA:int
*/

SELECT DISTINCT 
    EX.ANO_EXERCICIO,
    EX.ANO_CALENDARIO 
FROM FI_COMPROVANTE_RENDIMENTOS CR
INNER JOIN FI_EXERCICIO_TRIBUTO EX ON EX.SQ_EXERCICIO = CR.SQ_EXERCICIO
WHERE CR.CD_PESSOA = @CD_PESSOA