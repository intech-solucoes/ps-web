/*Config
    RetornaLista
    Retorno
        -PessoaFisicaEntidade
    Parametros
        -CPF:string
        -NO_PESSOA:string
*/

SELECT * 
FROM FI_PESSOA
INNER JOIN FI_PESSOA_FISICA ON FI_PESSOA.CD_PESSOA = FI_PESSOA_FISICA.CD_PESSOA
WHERE (FI_PESSOA.NO_PESSOA LIKE '%' + @NO_PESSOA + '%' OR @NO_PESSOA IS NULL)
  AND (FI_PESSOA_FISICA.NR_CPF = @CPF OR @CPF IS NULL)