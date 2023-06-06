﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Goc.Models
{
    public partial class ActionsLog
    {
        public ActionsLog()
        {
            Evidences = new HashSet<Evidences>();
        }

        public long Id { get; set; }
        public int TeamId { get; set; }
        public int TeamCharacterId { get; set; }
        public int ActionTypeId { get; set; }
        public int? AffectedTeamId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public int MissionId { get; set; }
        public int Coinks { get; set; }

        public virtual ActionTypes ActionType { get; set; }

        public virtual TeamsCharacters TeamCharacter { get; set; }
        public virtual Missions Mission { get; set; }
        public virtual Teams Team { get; set; }
        public virtual ICollection<Evidences> Evidences { get; set; }
    }
}