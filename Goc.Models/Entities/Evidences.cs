﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Goc.Models
{
    public partial class Evidences
    {
        public long Id { get; set; }
        public long ActionLogId { get; set; }
        public int TeamCharacterId { get; set; }
        public string Image { get; set; }
        public bool IsValid { get; set; }

        public virtual ActionsLog ActionLog { get; set; }
        public virtual User TeamCharacter { get; set; }
    }
}