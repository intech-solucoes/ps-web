/*Config
    RetornaLista
    Retorno
        -ContratoTrabalhoEntidade
    Parametros
        -CPF:string
*/

SELECT CT.*
FROM FI_CONTRATO_TRABALHO CT
INNER JOIN FI_PESSOA_FISICA PF ON PF.CD_PESSOA = CT.CD_PESSOA
WHERE PF.NR_CPF = @CPF