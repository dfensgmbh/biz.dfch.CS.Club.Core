/// <reference path="../Scripts/msls.js" />

window.myapp = msls.application;

(function (lightSwitchApplication) {

    var $Entity = msls.Entity,
        $DataService = msls.DataService,
        $DataWorkspace = msls.DataWorkspace,
        $defineEntity = msls._defineEntity,
        $defineDataService = msls._defineDataService,
        $defineDataWorkspace = msls._defineDataWorkspace,
        $DataServiceQuery = msls.DataServiceQuery,
        $toODataString = msls._toODataString;

    function Member(entitySet) {
        /// <summary>
        /// Represents the Member entity type.
        /// </summary>
        /// <param name="entitySet" type="msls.EntitySet" optional="true">
        /// The entity set that should contain this member.
        /// </param>
        /// <field name="Id" type="Number">
        /// Gets or sets the id for this member.
        /// </field>
        /// <field name="FirstName" type="String">
        /// Gets or sets the firstName for this member.
        /// </field>
        /// <field name="LastName" type="String">
        /// Gets or sets the lastName for this member.
        /// </field>
        /// <field name="Birthday" type="Date">
        /// Gets or sets the birthday for this member.
        /// </field>
        /// <field name="Address1" type="String">
        /// Gets or sets the address1 for this member.
        /// </field>
        /// <field name="Address2" type="String">
        /// Gets or sets the address2 for this member.
        /// </field>
        /// <field name="Address3" type="String">
        /// Gets or sets the address3 for this member.
        /// </field>
        /// <field name="PostalCode" type="String">
        /// Gets or sets the postalCode for this member.
        /// </field>
        /// <field name="City" type="String">
        /// Gets or sets the city for this member.
        /// </field>
        /// <field name="Country" type="String">
        /// Gets or sets the country for this member.
        /// </field>
        /// <field name="MobileNumber" type="String">
        /// Gets or sets the mobileNumber for this member.
        /// </field>
        /// <field name="Active" type="Boolean">
        /// Gets or sets the active for this member.
        /// </field>
        /// <field name="SubscriptionType" type="String">
        /// Gets or sets the subscriptionType for this member.
        /// </field>
        /// <field name="SubscriptionStarts" type="Date">
        /// Gets or sets the subscriptionStarts for this member.
        /// </field>
        /// <field name="SubscriptionEnds" type="Date">
        /// Gets or sets the subscriptionEnds for this member.
        /// </field>
        /// <field name="CreatedBy" type="String">
        /// Gets or sets the createdBy for this member.
        /// </field>
        /// <field name="Created" type="Date">
        /// Gets or sets the created for this member.
        /// </field>
        /// <field name="ModifiedBy" type="String">
        /// Gets or sets the modifiedBy for this member.
        /// </field>
        /// <field name="Modified" type="Date">
        /// Gets or sets the modified for this member.
        /// </field>
        /// <field name="RowVersion" type="Array">
        /// Gets or sets the rowVersion for this member.
        /// </field>
        /// <field name="details" type="msls.application.Member.Details">
        /// Gets the details for this member.
        /// </field>
        $Entity.call(this, entitySet);
    }

    function ApplicationData(dataWorkspace) {
        /// <summary>
        /// Represents the ApplicationData data service.
        /// </summary>
        /// <param name="dataWorkspace" type="msls.DataWorkspace">
        /// The data workspace that created this data service.
        /// </param>
        /// <field name="Members" type="msls.EntitySet">
        /// Gets the Members entity set.
        /// </field>
        /// <field name="details" type="msls.application.ApplicationData.Details">
        /// Gets the details for this data service.
        /// </field>
        $DataService.call(this, dataWorkspace);
    };
    function DataWorkspace() {
        /// <summary>
        /// Represents the data workspace.
        /// </summary>
        /// <field name="ApplicationData" type="msls.application.ApplicationData">
        /// Gets the ApplicationData data service.
        /// </field>
        /// <field name="details" type="msls.application.DataWorkspace.Details">
        /// Gets the details for this data workspace.
        /// </field>
        $DataWorkspace.call(this);
    };

    msls._addToNamespace("msls.application", {

        Member: $defineEntity(Member, [
            { name: "Id", type: Number },
            { name: "FirstName", type: String },
            { name: "LastName", type: String },
            { name: "Birthday", type: Date },
            { name: "Address1", type: String },
            { name: "Address2", type: String },
            { name: "Address3", type: String },
            { name: "PostalCode", type: String },
            { name: "City", type: String },
            { name: "Country", type: String },
            { name: "MobileNumber", type: String },
            { name: "Active", type: Boolean },
            { name: "SubscriptionType", type: String },
            { name: "SubscriptionStarts", type: Date },
            { name: "SubscriptionEnds", type: Date },
            { name: "CreatedBy", type: String, isReadOnly: true },
            { name: "Created", type: Date, isReadOnly: true },
            { name: "ModifiedBy", type: String, isReadOnly: true },
            { name: "Modified", type: Date, isReadOnly: true },
            { name: "RowVersion", type: Array }
        ]),

        ApplicationData: $defineDataService(ApplicationData, lightSwitchApplication.rootUri + "/ApplicationData.svc", [
            { name: "Members", elementType: Member }
        ], [
            {
                name: "Members_SingleOrDefault", value: function (Id) {
                    return new $DataServiceQuery({ _entitySet: this.Members },
                        lightSwitchApplication.rootUri + "/ApplicationData.svc" + "/Members(" + "Id=" + $toODataString(Id, "Int32?") + ")"
                    );
                }
            }
        ]),

        DataWorkspace: $defineDataWorkspace(DataWorkspace, [
            { name: "ApplicationData", type: ApplicationData }
        ])

    });

}(msls.application));
