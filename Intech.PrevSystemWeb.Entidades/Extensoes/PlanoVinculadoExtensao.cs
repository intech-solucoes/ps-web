﻿using Intech.PrevSystemWeb.Entidades;

namespace System
{
    public static class PlanoVinculadoExtensao
    {
        public static bool IsAtivo(this PlanoVinculadoEntidade plano) => plano.SQ_SIT_PLANO == 1;
        public static bool IsDesligado(this PlanoVinculadoEntidade plano) => plano.SQ_SIT_PLANO == 2;
        public static bool IsAssistido(this PlanoVinculadoEntidade plano) => plano.SQ_SIT_PLANO == 3;
        public static bool IsAutopatrocinio(this PlanoVinculadoEntidade plano) => plano.SQ_SIT_PLANO == 4;
    }
}
