namespace Intech.PrevSystemWeb.Entidades.Outras
{
    public class SaldoEntidade
    {
        public string DS_TIPO_FUNDO { get; set; }
        public decimal VL_CONTRIBUICAO { get; set; }
        public decimal QT_COTA_CONTRIBUICAO { get; set; }
        public decimal VL_ATUALIZADO { get; set; }
        public decimal VL_RENDIMENTO { get; set; }

        public static SaldoEntidade operator + (SaldoEntidade saldo1, SaldoEntidade saldo2)
        {
            return new SaldoEntidade
            {
                DS_TIPO_FUNDO = saldo1.DS_TIPO_FUNDO,
                QT_COTA_CONTRIBUICAO = saldo1.QT_COTA_CONTRIBUICAO + saldo2.QT_COTA_CONTRIBUICAO,
                VL_ATUALIZADO = saldo1.VL_ATUALIZADO + saldo2.VL_ATUALIZADO,
                VL_CONTRIBUICAO = saldo1.VL_CONTRIBUICAO + saldo2.VL_CONTRIBUICAO,
                VL_RENDIMENTO = saldo1.VL_RENDIMENTO + saldo2.VL_RENDIMENTO
            };
        }
    }
}