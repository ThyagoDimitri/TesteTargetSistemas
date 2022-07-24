using System;
using System.Collections.Generic;
using System.Text;

namespace TargetSistemas
{
   public class RendimentoEstado
    {
        public string UF { get; set; }
        public float RendimentoReais { get; set; }
        public float RendimentoPercent { get; set; }
        public RendimentoEstado(string UF, float RendimentoReais, float RendimentoPercent = 0)
        {
            this.UF = UF;
            this.RendimentoReais = RendimentoReais;
            this.RendimentoPercent = RendimentoPercent;
        }
    }
}

