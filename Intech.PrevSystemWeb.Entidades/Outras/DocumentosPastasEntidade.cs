using System.Collections.Generic;

namespace Intech.PrevSystemWeb.Entidades.Outras
{
    public class DocumentosPastasEntidade
    {
        public DocumentoPastaEntidade PastaAtual { get; set; }
        public List<DocumentoEntidade> Documentos { get; set; }
        public List<DocumentoPastaEntidade> Pastas { get; set; }
    }
}