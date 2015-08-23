/**
 *
 *
 * Copyright 2015 Ronald Rink, d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Linq;
using LightSwitchApplication;
using biz.dfch.CS.Club.Core.Server.Utilities;
using biz.dfch.CS.Club.Core.Server.Utilities.Clickatell;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.Members
{
    public class MembersController : ApplicationDataBaseController
    {
        public MembersController(Identity identity, ApplicationDataService applicationDataService) 
            : base(identity, applicationDataService)
        {
            // empty constructor - all work is done in base constructor
        }

        public bool Inserting(Member entity)
        {
            var fReturn = false;
            if (_identity.Roles.Contains("AnonymousCanSubscribe"))
            {
                fReturn = AnonymousRegistration1(entity);
            }
            else
            {
                fReturn = AdminRegistration(entity);
            }
            return fReturn;
        }

        public bool AnonymousRegistration1(Member entity)
        {
            entity.Active = false;
            entity.SubscriptionEnds = entity.Created.Value.AddDays(30);
            entity.SubscriptionStarts = entity.Created;
            entity.SubscriptionType = (new SubscriptionType()).TrialPerson;

            return true;
        }

        public bool AnonymousRegistration2(Member entity)
        {
            bool fReturn = false;

            var messageTemplate = "Hier ist Dein Zugriffscode:\r\n\r\n{0}\r\n\r\nAntworte auf die SMS mit diesem Code, um die Registrierung abzuschliessen.";
            var token = (new OnetimeToken()).GenerateOnetimeToken();

            IShortMessageServiceProvider provider = new ClickatellShortMessageProvider();
            IShortMessage message = new Message
            {
                Text = string.Format(messageTemplate, token)
                ,
                Recipient = entity.MobileNumber
            };
            var result = provider.SendMessage(message);
            if (provider.HasError())
            {
                entity.Delete();
                fReturn = false;
            }
            else
            {
                var memberData = ServerApplicationContext.Current.DataWorkspace.ApplicationData.MemberDatas.AddNew();
                fReturn = true;
            }
            return fReturn;

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