using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LightSwitchApplication;
using biz.dfch.CS.Club.Core.Server.Utilities;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.Members
{
    public class MembersController
    {
        private Identity _person;

        public MembersController(Identity identity)
        {
            _person = identity;
        }

        public bool Inserting(Member entity)
        {
            var fReturn = false;
            if (_person.Roles.Contains("AnonymousCanSubscribe"))
            {
                fReturn = AnonymousRegistration(entity);
            }
            else
            {
                fReturn = AdminRegistration(entity);
            }
            return fReturn;
        }

        public bool AnonymousRegistration(Member entity)
        {
            entity.Active = false;
            entity.SubscriptionEnds = entity.Created.Value.AddDays(30);
            entity.SubscriptionStarts = entity.Created;
            entity.SubscriptionType = (new SubscriptionType()).TrialPerson;

            return true;
        }

        public bool AdminRegistration(Member entity)
        {
            entity.Active = true;
            if (null == entity.SubscriptionStarts)
            {
                entity.SubscriptionStarts = entity.Created;
            }

            if(!SubscriptionType.IsValidType(entity.SubscriptionType))
            {
                return false;
            }

            return true;
        }

        public void Inserted(Member entity)
        {
            if (null == entity.SubscriptionStarts)
            {
                entity.SubscriptionStarts = entity.Created;
            }
        }
    }
}