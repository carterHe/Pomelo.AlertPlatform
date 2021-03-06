﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomelo.AlertPlatform.Incident.Models
{
    public enum IncidentStatus
    {
        Active,
        Mitigated,
        Resolved
    }

    public class Incident
    {
        public long Id { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        public int HitCount { get; set; }

        public int Severity { get; set; }

        public IncidentStatus Status { get; set; }

        [ForeignKey("User")]
        public Guid? UserId { get; set; }

        public virtual User User { get; set; }

        public string Summary { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        public DateTime? MitigatedTime { get; set; } 

        public DateTime? ResolvedTime { get; set; }

        public virtual ICollection<CallHistory> CallHistories { get; set; }
    }
}
