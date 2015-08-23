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
using biz.dfch.CS.Club.Core.Server.Utilities;
using LightSwitchApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.MemberDatas
{
    public class MemberDatasController : ApplicationDataBaseController
    {
        public MemberDatasController(Identity identity, ApplicationDataService applicationDataService) 
            : base(identity, applicationDataService)
        {
            // empty constructor - all work is done in base constructor
        }

        public bool Inserting(MemberData entity)
        {
            var fReturn = false;
            return fReturn;
        }

        public void Inserted(MemberData entity)
        {
            if (null == entity.ParametersType)
            {
                entity.ParametersType = "default";
            }
        }
    }
}
