﻿/*Config
    RetornaLista
    Retorno
        -ContratoEmprestimoEntidade
    Parametros
        -CD_PESSOA:int
*/

SELECT CE.*,
       PE.NO_PESSOA,  
	   PF.NR_CPF,
       EM.NO_PESSOA AS NO_EMPRESA,
       CT.NR_REGISTRO,
       PL.DS_PLANO_PREVIDENCIAL,
       NA.DS_NATUREZA,
       ST.DS_SITUACAO,
       MQ.DS_MOT_QUITACAO
FROM fi_contrato_emprestimo CE
    INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = CE.CD_PESSOA
    INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = CE.CD_PESSOA
    INNER JOIN fi_natureza_emprestimo NA ON NA.SQ_NATUREZA = CE.SQ_NATUREZA
    INNER JOIN fi_situacao_emprestimo ST ON ST.SQ_SITUACAO = CE.SQ_SITUACAO
    INNER JOIN fi_contrato_trabalho CT ON CT.SQ_CONTRATO_TRABALHO = CE.SQ_CONTRATO_TRABALHO
    INNER JOIN fi_pessoa EM ON EM.CD_PESSOA = CT.CD_PESSOA_PATR
    INNER JOIN fi_plano_previdencial PL ON PL.SQ_PLANO_PREVIDENCIAL = CE.SQ_PLANO_PREVIDENCIAL
    LEFT OUTER JOIN fi_motivo_quitacao MQ ON MQ.SQ_MOT_QUITACAO = CE.SQ_MOT_QUITACAO
WHERE CE.CD_PESSOA = @CD_PESSOA
ORDER BY CE.DT_CREDITO DESC  