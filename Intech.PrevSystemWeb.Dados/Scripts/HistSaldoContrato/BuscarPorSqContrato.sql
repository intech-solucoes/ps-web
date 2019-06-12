/*Config
    RetornaLista
    Retorno
        -HistSaldoContratoEntidade
    Parametros
        -SQ_CONTRATO:int
*/

SELECT *
FROM fi_hist_saldo_contrato
WHERE SQ_CONTRATO = @SQ_CONTRATO
ORDER BY DT_VENCIMENTO 