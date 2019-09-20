/*Config
    RetornaLista
    Retorno
        -OpcaoTributacaoEntidade
*/

SELECT SQ_OPCAO_TRIBUTACAO,
	   DS_OPCAO_TRIBUTACAO
FROM fi_opcao_tributacao
WHERE SQ_OPCAO_TRIBUTACAO <> 2