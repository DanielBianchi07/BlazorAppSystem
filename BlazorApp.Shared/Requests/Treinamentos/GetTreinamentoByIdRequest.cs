﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Treinamentos
{
    public class GetTreinamentoByIdRequest : Request
    {
        [Required(ErrorMessage = "Treinamento Inválido")]
        public Guid Id { get; set; }
    }
}
