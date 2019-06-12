/*Config
    Retorno
        -HistEncargoContratoEntidade
    Parametros
        -SQ_CONTRATO:int
*/

SELECT TOP 1 * 
FROM fi_hist_encargo_contrato HEC
    INNER JOIN fi_tipo_encargo TE ON TE.SQ_TIPO_ENCARGO = HEC.SQ_TIPO_ENCARGO
WHERE SQ_CONTRATO = @SQ_CONTRATO
  AND HEC.SQ_TIPO_ENCARGO = 8
ORDER BY DT_VENCIMENTO