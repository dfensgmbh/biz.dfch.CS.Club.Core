using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities
{
    public class Identity
    {
        public string Username;
        public IEnumerable<string> Roles;
        public IEnumerable<string> Permissions;
    }
}