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
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Club.Core.Server.Utilities
{
    public class OnetimeToken
    {
        private string _UpperCaseBlacklist = "IOQSV";
        private int _TokenLength = 4;

        public string GenerateOnetimeToken()
        {
            return GenerateOnetimeToken(_TokenLength);
        }

        public string GenerateOnetimeToken(int length)
        {
            if(0 > length)
            {
                throw new ArgumentOutOfRangeException("length", string.Format("length: Parameter validation FAILED. Value '{0}' must be larger than 0.", length));
            }

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            while (builder.Length < length)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                if (_UpperCaseBlacklist.Contains(ch))
                {
                    continue;
                }
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
