using System;

namespace Forum.Api.Core.Domain.Models;

public class EmailConfirmation : BaseEntity
{
    public string OldEmailAddress { get; set; }
    public string NewEmailAddress { get; set; }

}
