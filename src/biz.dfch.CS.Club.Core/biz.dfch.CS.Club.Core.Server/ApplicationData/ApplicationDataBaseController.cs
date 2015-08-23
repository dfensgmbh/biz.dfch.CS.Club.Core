﻿/**
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biz.dfch.CS.Club.Core.Server.Utilities;
using LightSwitchApplication;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData
{
    public class ApplicationDataBaseController
    {
        protected readonly Identity _identity;
        protected readonly ApplicationDataService _applicationDataService;

        public ApplicationDataBaseController(Identity identity, ApplicationDataService applicationDataService)
        {
            _identity = identity;
            _applicationDataService = applicationDataService;
        }
    }
}