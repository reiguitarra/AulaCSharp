﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGamer.Domain.ValueObjects;

namespace XGamer.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }
    }
}
