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
using biz.dfch.CS.Club.Contracts;
using Microsoft.Data.Edm;
using System;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Web.Http.OData.Builder;

namespace biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell
{
    [Export(typeof(IODataEndpoint))]
    [ExportMetadata("ServerRole", ServerRole.HOST)]
    public class ClickatellEndpoint : IODataEndpoint
    {
        public IEdmModel GetModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.ContainerName = GetContainerName();
            builder.EntitySet<ClickatellJsonCallback>("ClickatellJsonCallbacks");

            return builder.GetEdmModel();
        }

        public string GetContainerName()
        {
            var containerName = ConfigurationManager.AppSettings["Club.OdataServices.Clickatell.Container.Name"];
            return String.IsNullOrWhiteSpace(containerName) ? "ClickatellEndpoint" : containerName;
        }
    }
}
