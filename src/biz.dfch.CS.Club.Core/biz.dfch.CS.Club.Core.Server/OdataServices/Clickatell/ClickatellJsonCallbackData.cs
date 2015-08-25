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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell
{
    public class ClickatellJsonCallbackData
    {
        [Required]
        public int apiId { get; set; }
        [Required]
        public string moMessageId { get; set; }
        [Required]
        public string from { get; set; }
        [Required]
        public string to { get; set; }
        [Required]
        public DateTimeOffset timestamp { get; set; }
        [Required]
        public string charset { get; set; }
        [Required]
        public string udh { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string text { get; set; }
    }
}
