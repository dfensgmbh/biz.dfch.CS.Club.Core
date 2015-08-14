using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        partial void Members_Inserting(Member entity)
        {
            if (null == entity.SubscriptionStarts)
            {
                entity.SubscriptionStarts = entity.Created;   
            }
        }
    }
}
