﻿using System;

namespace First2._0.Application.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
    }
}
