﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Goc.Api.Dtos
{
    public partial class ActionTypes
    {
        public ActionTypes()
        {
            ActionsLog = new HashSet<ActionsLog>();
            MessageTemplates = new HashSet<MessageTemplates>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ActionsLog> ActionsLog { get; set; }
        public virtual ICollection<MessageTemplates> MessageTemplates { get; set; }
    }
}