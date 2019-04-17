﻿/*Config
    Retorno
        -PlanoVinculadoEntidade
    Parametros
        -SQ_CONTRATO_TRABALHO:int
        -SQ_PLANO_PREVIDENCIAL:int
*/

SELECT 
    FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL, 
    FI_SIT_PLANO.DS_SIT_PLANO, 
    FI_SIT_INSCRICAO.DS_SIT_INSCRICAO, 
    FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO, 
    FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB, 
    FI_PLANO_VINCULADO.DT_INSC_PLANO,
    FI_PLANO_VINCULADO.DT_SITUACAO,
    FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO,
    FI_PLANO_VINCULADO.*
FROM FI_PLANO_VINCULADO 
INNER JOIN FI_PLANO_PREVIDENCIAL ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL
INNER JOIN FI_SIT_PLANO ON FI_SIT_PLANO.SQ_SIT_PLANO = FI_PLANO_VINCULADO.SQ_SIT_PLANO
INNER JOIN FI_MOT_SIT_PLANO ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO = FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO
INNER JOIN FI_SIT_INSCRICAO ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO = FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO
WHERE SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO
  AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT IN (2, 6)
  AND FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL