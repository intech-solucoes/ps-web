/*Config
    Retorno
        -void
    Parametros
        -CD_PESSOA:int
        -NO_EMAIL:string
*/

UPDATE FI_ENDERECO_PESSOA SET NO_EMAIL = @NO_EMAIL WHERE CD_PESSOA = @CD_PESSOA