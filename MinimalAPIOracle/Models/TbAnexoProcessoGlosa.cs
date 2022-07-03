using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class TbAnexoProcessoGlosa
    {
        public decimal IdAnexoProcesso { get; set; }
        public decimal? NuOrdemProcesso { get; set; }
        public string? UrlArquivo { get; set; }
        public string? NomeArquivo { get; set; }
        public string? Aprovado { get; set; }

        public virtual TbProducaoServico? NuOrdemProcessoNavigation { get; set; }
    }
}
