/*Config
    Retorno
        -UsuarioEntidade
    Parametros
        -CPF:string
*/

SELECT * FROM FR_USUARIO
WHERE USR_LOGIN = @CPF