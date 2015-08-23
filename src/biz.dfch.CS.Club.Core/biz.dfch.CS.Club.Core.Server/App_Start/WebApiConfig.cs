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
using System.Web.Http.OData.Builder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Extensions;
using System.Linq;
using biz.dfch.CS.Club.Contracts;
using System.Diagnostics;

namespace LightSwitchApplication
{
    public static class WebApiConfig
    {
        private static String _apiBase = "api";

        private static List<String> _serverRoles = ConfigurationManager.AppSettings["Club.Server.ServerRoles"].Split(',').ToList<String>();

        private static IEnumerable<Lazy<IODataEndpoint, IODataEndpointData>> endpoints;

        public static void InitEndpoints(IEnumerable<Lazy<IODataEndpoint, IODataEndpointData>> endpoints)
        {
            WebApiConfig.endpoints = (null == endpoints) ? new List<Lazy<IODataEndpoint, IODataEndpointData>>() : endpoints;
        }

        public static void Register(HttpConfiguration config)
        {
            Debug.Write("WebApiConfig::Register() START");

            RegisterAdministrationEndpoint(config);

            if(null != endpoints)
            {
                foreach (var endpoint in endpoints)
                {

                    if (NotMatchingRoleOfServer(endpoint))
                    {
                        Debug.WriteLine(String.Format("Endpoint '{0}' not matching server role {1}", endpoint.Value.GetContainerName(), _serverRoles));
                        continue;
                    }

                    if (IsContainerNameNotUnique(endpoint))
                    {
                        Debug.WriteLine(String.Format("ContainerName '{0}' not unique", endpoint.Value.GetContainerName()));
                        continue;
                    }

                    RegisterMefEndpoint(config, endpoint);
                }
            }
            config.MapHttpAttributeRoutes();
            Debug.Write("WebApiConfig::Register() END");
        }

        private static void RegisterAdministrationEndpoint(HttpConfiguration config)
        {
            String containerName = "Administration";
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.ContainerName = containerName;

            RegisterEndpoint(config, containerName, builder.GetEdmModel());
        }

        private static Boolean NotMatchingRoleOfServer(Lazy<IODataEndpoint, IODataEndpointData> endpoint)
        {
            return !_serverRoles.Contains(endpoint.Metadata.ServerRole.ToString());
        }

        private static Boolean IsContainerNameNotUnique(Lazy<IODataEndpoint, IODataEndpointData> endpoint)
        {
            return "Administration".Equals(endpoint.Value.GetContainerName()) || 1 < endpoints
                .Where(v => v.Value.GetContainerName().Equals(endpoint.Value.GetContainerName(), StringComparison.InvariantCultureIgnoreCase))
                .Count();
        }

        private static void RegisterMefEndpoint(HttpConfiguration config, Lazy<IODataEndpoint, IODataEndpointData> endpoint)
        {
            RegisterEndpoint(config, endpoint.Value.GetContainerName(), endpoint.Value.GetModel());
        }

        private static void RegisterEndpoint(HttpConfiguration config, string containerName, Microsoft.Data.Edm.IEdmModel edmModel)
        {
            config.Routes.MapODataServiceRoute(
                routeName: String.Format("{0}/{1}.svc", _apiBase, containerName)
                ,
                routePrefix: String.Format("{0}/{1}.svc", _apiBase, containerName)
                ,
                model: edmModel
                ,
                batchHandler: new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer)
                );
        }
    }
}
