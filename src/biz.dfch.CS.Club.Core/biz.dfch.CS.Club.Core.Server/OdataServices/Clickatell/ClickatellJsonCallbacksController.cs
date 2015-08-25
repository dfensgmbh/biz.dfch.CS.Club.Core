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
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell;
using Microsoft.Data.OData;

namespace biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using biz.dfch.CS.Club.Core.Server.OdataServces.Clickatell;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ClickatellJsonCallback>("ClickatellJsonCallbacks");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClickatellJsonCallbacksController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/ClickatellJsonCallbacks
        public async Task<IHttpActionResult> GetClickatellJsonCallbacks(ODataQueryOptions<ClickatellJsonCallback> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/ClickatellJsonCallbacks(5)
        public async Task<IHttpActionResult> GetClickatellJsonCallback([FromODataUri] int key, ODataQueryOptions<ClickatellJsonCallback> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/ClickatellJsonCallbacks(5)
        [AcceptVerbs("HEAD")]
        public async Task<IHttpActionResult> Head([FromODataUri] int key, ODataQueryOptions<ClickatellJsonCallback> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/ClickatellJsonCallbacks(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ClickatellJsonCallback> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ClickatellJsonCallbacks
        public async Task<IHttpActionResult> Post(ClickatellJsonCallback clickatellJsonCallback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(clickatellJsonCallback);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/ClickatellJsonCallbacks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ClickatellJsonCallback> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ClickatellJsonCallbacks(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
