using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
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
                var controller = new MembersController(ctx.Application.User.Name, ctx.Application.User.Roles, ctx.Application.User.EffectivePermissions);
                if (controller.Inserting(entity))
                {
                    ctx.DataWorkspace.ApplicationData.SaveChanges();
                }
                else
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
                var controller = new MembersController(ctx.Application.User.Name, ctx.Application.User.Roles, ctx.Application.User.EffectivePermissions);
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
