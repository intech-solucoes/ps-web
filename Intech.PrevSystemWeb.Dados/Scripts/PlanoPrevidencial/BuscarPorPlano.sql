/*Config
    Retorno
        -PlanoPrevidencialEntidade
    Parametros
        -SQ_PLANO_PREVIDENCIAL:int
*/

SELECT *
FROM FI_PLANO_PREVIDENCIAL
WHERE SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL