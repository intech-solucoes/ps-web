using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystemWeb.Entidades
{
    [Table("fi_banco")]
    public class BancoEntidade
    {
		[Key]
		public string CD_BANCO { get; set; }
		public string NO_BANCO { get; set; }
		public string IMG_BANCO { get; set; }
		public string CD_COMPENSACAO { get; set; }
        
    }
}
