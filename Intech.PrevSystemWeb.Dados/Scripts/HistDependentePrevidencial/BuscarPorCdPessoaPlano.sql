/*Config
    RetornaLista
    Retorno
        -HistDependentePrevidencialEntidade
    Parametros
        -CD_PESSOA:int
        -SQ_PLANO_PREVIDENCIAL:int
*/

SELECT HDP.*,
    PE.NO_PESSOA,
    PF.DT_NASCIMENTO, 
    GP.DS_GRAU_PARENTESCO, 
    PF.NR_CPF
FROM fi_hist_dependente_previdencial HDP
    INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = HDP.CD_PESSOA_DEP
    INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = HDP.CD_PESSOA_DEP
    INNER JOIN fi_dependente DP ON DP.CD_PESSOA_DEP = HDP.CD_PESSOA_DEP
    INNER JOIN fi_grau_parentesco GP ON GP.CD_GRAU_PARENTESCO = DP.CD_GRAU_PARENTESCO
WHERE HDP.CD_PESSOA = @CD_PESSOA
  AND HDP.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL