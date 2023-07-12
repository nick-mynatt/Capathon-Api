using System;
using System.Collections.Generic;

namespace Capathon.Models;

public partial class Appointment
{
    public int AId { get; set; }

    public DateTime? PickupTime { get; set; }

    public DateTime? DropoffTime { get; set; }

    public int? CId { get; set; }

    public int? DId { get; set; }

    public int? UId { get; set; }

    public virtual CareCenter? CIdNavigation { get; set; }

    public virtual Dependent? DIdNavigation { get; set; }

    public virtual User? UIdNavigation { get; set; }
}
