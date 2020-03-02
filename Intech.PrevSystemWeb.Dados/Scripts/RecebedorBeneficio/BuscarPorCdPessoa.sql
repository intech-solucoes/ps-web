/*Config
    RetornaLista
    Retorno
        -RecebedorBeneficioEntidade
    Parametros
        -CD_PESSOA:int
*/

SELECT * FROM FI_RECEBEDOR_BENEFICIO
WHERE CD_PESSOA_RECEB = @CD_PESSOA