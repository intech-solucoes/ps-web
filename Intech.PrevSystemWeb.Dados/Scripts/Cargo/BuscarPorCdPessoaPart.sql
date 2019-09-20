/*Config
    RetornaLista
    Retorno
        -CargoEntidade
    Parametros
        -CD_PESSOA_PATR:int
*/

SELECT SQ_CARGO,
       DS_CARGO 
FROM fi_cargo
WHERE CD_PESSOA_PATR = @CD_PESSOA_PATR