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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using LightSwitchApplication;
using Microsoft.LightSwitch;

using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.MemberDatas
{
    public class Validation
    {
        public bool ParametersType_Validate(MemberData entity, out String errormsg)
        {
            errormsg = null;
            if (String.IsNullOrEmpty(entity.ParametersType))
            {
                return true;
            }
            Type type = Type.GetType(entity.ParametersType);
            try
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject(entity.Parameters, type);
            }
            catch (Exception ex)
            {
                errormsg = String.Format("ParametersType: Parameter validation FAILED. Parameter 'Parameters' is not of specified type '{0}'.", entity.ParametersType);
                return false;
            }
            return true;
        }
    }
}