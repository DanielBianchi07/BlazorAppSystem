﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Requests.Alternativas
{
    public class DeleteAlternativaRequest : Request
    {
        [Required(ErrorMessage = "Questão Inválida")]
        public Guid Id { get; set; }
    }
}
