using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LightSwitchApplication;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.Members
{
    public class MembersController
    {
        private string _username;
        private IEnumerable<string> _roles;
        private IEnumerable<string> _permissions;

        public MembersController(string username, IEnumerable<string> roles, IEnumerable<string> permissions)
        {
            _username = username;
            _roles = roles;
            _permissions = permissions;
        }

        public bool Inserting(Member entity)
        {
            var fReturn = false;
            if (_roles.Contains("AnonymousCanSubscribe"))
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
            var fReturn = false;

            entity.Active = false;
            entity.SubscriptionEnds = entity.Created.Value.AddDays(30);
            entity.SubscriptionStarts = entity.Created;
            entity.SubscriptionType = (new SubscriptionType()).TrialPerson;

            fReturn = true;
            return fReturn;
        }

        public bool AdminRegistration(Member entity)
        {
            var fReturn = false;

            entity.Active = true;
            if (null == entity.SubscriptionStarts)
            {
                entity.SubscriptionStarts = entity.Created;
            }

            fReturn = true;
            return fReturn;
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