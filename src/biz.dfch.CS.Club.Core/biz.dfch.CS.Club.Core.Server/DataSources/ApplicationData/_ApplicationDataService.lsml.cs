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
using System.Web.Configuration;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
using biz.dfch.CS.Club.Core.Server.Utilities;
using biz.dfch.CS.Club.Core.Server.ApplicationData.MemberDatas;

namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        private bool CheckPermission([System.Runtime.CompilerServices.CallerMemberName] string fn = "")
        {
            var hasPermission = false;
            if (fn.EndsWith("_CanInsert"))
            {
                fn = fn.Replace("_CanInsert", "_CanCreate");
            }
            var ctx = ServerApplicationContext.Current;
            var permission = string.Concat("LightSwitchApplication:", fn);
            hasPermission = ctx.Application.User.HasPermission(permission);
            if (!hasPermission)
            {
                var msg = string.Format("Authorisation FAILED. {0} does not have permission '{1}' for the requested operation.", fn, ctx.Application.User.FullName);
                System.Diagnostics.Trace.WriteLine(msg);
            }
            return hasPermission;
        }

        partial void Members_CanInsert(ref bool result)
        {
            result = CheckPermission();
        }

        partial void Members_CanDelete(ref bool result)
        {
            result = CheckPermission();
        }

        partial void Members_CanRead(ref bool result)
        {
            result = CheckPermission();
        }

        partial void Members_CanUpdate(ref bool result)
        {
            result = CheckPermission();
        }

        partial void Members_Inserting(Member entity)
        {
            var isCtxCreated = false;
            var ctx = ServerApplicationContext.Current;
            try
            {
                if (null == ctx)
                {
                    isCtxCreated = true;
                    ctx = ServerApplicationContext.CreateContext();
                }
                var controller = new MembersController(
                    new Identity() 
                    { 
                        Username = ctx.Application.User.Name
                        , 
                        Roles = ctx.Application.User.Roles
                        , 
                        Permissions = ctx.Application.User.EffectivePermissions
                    }
                    ,
                    ctx.DataWorkspace.ApplicationData
                    );
                if (!controller.Inserting(entity))
                {
                    throw new ArgumentException("Members_Inserting FAILED. Cannot save changes.", "Members_Inserting");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (isCtxCreated && null != ctx && !ctx.IsDisposed)
                {
                    ctx.Dispose();
                }
            }
        }

        partial void Members_Inserted(Member entity)
        {
            var isCtxCreated = false;
            var ctx = ServerApplicationContext.Current;
            try
            {
                if (null == ctx)
                {
                    isCtxCreated = true;
                    ctx = ServerApplicationContext.CreateContext();
                }
                var controller = new MembersController(
                    new Identity()
                    {
                        Username = ctx.Application.User.Name
                        ,
                        Roles = ctx.Application.User.Roles
                        ,
                        Permissions = ctx.Application.User.EffectivePermissions
                    }
                    ,
                    ctx.DataWorkspace.ApplicationData
                    );
                controller.Inserted(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (isCtxCreated && null != ctx && !ctx.IsDisposed)
                {
                    ctx.Dispose();
                }
            }
        }

        partial void MemberDatas_CanInsert(ref bool result)
        {
            result = CheckPermission();
        }

        partial void MemberDatas_CanDelete(ref bool result)
        {
            result = CheckPermission();
        }

        partial void MemberDatas_CanRead(ref bool result)
        {
            result = CheckPermission();
        }

        partial void MemberDatas_CanUpdate(ref bool result)
        {
            result = CheckPermission();
        }

        partial void MemberDatas_Inserting(MemberData entity)
        {
            var isCtxCreated = false;
            var ctx = ServerApplicationContext.Current;
            try
            {
                if (null == ctx)
                {
                    isCtxCreated = true;
                    ctx = ServerApplicationContext.CreateContext();
                }
                var controller = new MemberDatasController(
                    new Identity()
                    {
                        Username = ctx.Application.User.Name
                        ,
                        Roles = ctx.Application.User.Roles
                        ,
                        Permissions = ctx.Application.User.EffectivePermissions
                    }
                    ,
                    ctx.DataWorkspace.ApplicationData
                    );
                if (!controller.Inserting(entity))
                {
                    throw new ArgumentException("MemberDatas_Inserting FAILED. Cannot save changes.", "MemberDatas_Inserting");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (isCtxCreated && null != ctx && !ctx.IsDisposed)
                {
                    ctx.Dispose();
                }
            }
        }

        partial void MemberDatas_Inserted(MemberData entity)
        {
            var isCtxCreated = false;
            var ctx = ServerApplicationContext.Current;
            try
            {
                if (null == ctx)
                {
                    isCtxCreated = true;
                    ctx = ServerApplicationContext.CreateContext();
                }
                var controller = new MemberDatasController(
                    new Identity()
                    {
                        Username = ctx.Application.User.Name
                        ,
                        Roles = ctx.Application.User.Roles
                        ,
                        Permissions = ctx.Application.User.EffectivePermissions
                    }
                    ,
                    ctx.DataWorkspace.ApplicationData
                    );
                controller.Inserted(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (isCtxCreated && null != ctx && !ctx.IsDisposed)
                {
                    ctx.Dispose();
                }
            }
        }
    }
}
