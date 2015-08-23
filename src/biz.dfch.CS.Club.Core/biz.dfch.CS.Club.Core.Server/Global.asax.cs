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
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Routing;
using biz.dfch.CS.Club.Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.IO;
using System.Web.Http.Dispatcher;


namespace LightSwitchApplication
{
    public class Global : System.Web.HttpApplication
    {
        private CompositionContainer _container;

        /**
         * On ComposeParts MEF initializes the list with all parts found that match the contract
         * (Contract: Parts have to be of type IODataEndpoint)
         **/
        [ImportMany(typeof(IODataEndpoint))]
        private IEnumerable<Lazy<IODataEndpoint, IODataEndpointData>> endpoints;
        
        //static void CurrentDomain_UnhandledException(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Trace.WriteLine("The threshold was reached.");
        //}
        
        protected void Application_Start(object sender, EventArgs e)
        {
            LoadAndComposeParts();

            WebApiConfig.InitEndpoints(endpoints);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new DefaultAssembliesResolver());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void LoadAndComposeParts()
        {
            var assemblyCatalog = new AggregateCatalog();

            // Adds all the parts found in the given directory
            var folder = ConfigurationManager.AppSettings["Club.Server.ExtensionsFolder"];
            try
            {
                if (!Path.IsPathRooted(folder))
                {
                    folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
                }
                assemblyCatalog.Catalogs.Add(new DirectoryCatalog(folder));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("WARNING: Loading extensions from '{0}' FAILED.\n{1}", folder, ex.Message));
            }
            finally
            {
                // Adds all the parts found in the same assembly as the Program class
                assemblyCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Global).Assembly));
            }
            _container = new CompositionContainer(assemblyCatalog);

            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

    }
}