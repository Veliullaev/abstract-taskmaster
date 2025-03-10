﻿using Taskmaster.Core.Model.Shared;

namespace Taskmaster.Core.Model;

public class AbstractTask : Entity
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}