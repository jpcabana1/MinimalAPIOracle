using System;
using System.Collections.Generic;

namespace MinimalAPIOracle.Models
{
    public partial class TbProducaoServico
    {
        public TbProducaoServico()
        {
            TbAnexoProcessoGlosas = new HashSet<TbAnexoProcessoGlosa>();
        }

        public decimal NuOrdem { get; set; }
        public decimal? CdPrestador { get; set; }
        public string? DsObservacao { get; set; }

        public virtual ICollection<TbAnexoProcessoGlosa> TbAnexoProcessoGlosas { get; set; }
    }
}
