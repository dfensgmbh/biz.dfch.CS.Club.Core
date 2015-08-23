/// <reference path="viewModel.js" />

(function (lightSwitchApplication) {

    var $element = document.createElement("div");

    lightSwitchApplication.AddEditMember.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditMember
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.AddEditMember,
            value: lightSwitchApplication.AddEditMember
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.AddEditMember,
            value: lightSwitchApplication.Member
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: lightSwitchApplication.Member
        },
        FirstName: {
            _$class: msls.ContentItem,
            _$name: "FirstName",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        LastName: {
            _$class: msls.ContentItem,
            _$name: "LastName",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Birthday: {
            _$class: msls.ContentItem,
            _$name: "Birthday",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: Date
        },
        Address1: {
            _$class: msls.ContentItem,
            _$name: "Address1",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Address2: {
            _$class: msls.ContentItem,
            _$name: "Address2",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Address3: {
            _$class: msls.ContentItem,
            _$name: "Address3",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: lightSwitchApplication.Member
        },
        PostalCode: {
            _$class: msls.ContentItem,
            _$name: "PostalCode",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        City: {
            _$class: msls.ContentItem,
            _$name: "City",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Country: {
            _$class: msls.ContentItem,
            _$name: "Country",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        MobileNumber: {
            _$class: msls.ContentItem,
            _$name: "MobileNumber",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        LegalEntity: {
            _$class: msls.ContentItem,
            _$name: "LegalEntity",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        SubscriptionType: {
            _$class: msls.ContentItem,
            _$name: "SubscriptionType",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditMember
        }
    };

    msls._addEntryPoints(lightSwitchApplication.AddEditMember, {
        /// <field>
        /// Called when a new AddEditMember screen is created.
        /// <br/>created(msls.application.AddEditMember screen)
        /// </field>
        created: [lightSwitchApplication.AddEditMember],
        /// <field>
        /// Called before changes on an active AddEditMember screen are applied.
        /// <br/>beforeApplyChanges(msls.application.AddEditMember screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.AddEditMember],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("left"); }],
        /// <field>
        /// Called after the FirstName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("FirstName"); }],
        /// <field>
        /// Called after the LastName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("LastName"); }],
        /// <field>
        /// Called after the Birthday content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Birthday_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("Birthday"); }],
        /// <field>
        /// Called after the Address1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address1_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("Address1"); }],
        /// <field>
        /// Called after the Address2 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address2_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("Address2"); }],
        /// <field>
        /// Called after the Address3 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address3_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("Address3"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("right"); }],
        /// <field>
        /// Called after the PostalCode content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PostalCode_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("PostalCode"); }],
        /// <field>
        /// Called after the City content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        City_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("City"); }],
        /// <field>
        /// Called after the Country content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Country_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("Country"); }],
        /// <field>
        /// Called after the MobileNumber content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        MobileNumber_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("MobileNumber"); }],
        /// <field>
        /// Called after the LegalEntity content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LegalEntity_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("LegalEntity"); }],
        /// <field>
        /// Called after the SubscriptionType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        SubscriptionType_postRender: [$element, function () { return new lightSwitchApplication.AddEditMember().findContentItem("SubscriptionType"); }]
    });

    lightSwitchApplication.BrowseMembers.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseMembers
        },
        MemberList: {
            _$class: msls.ContentItem,
            _$name: "MemberList",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.BrowseMembers,
            data: lightSwitchApplication.BrowseMembers,
            value: lightSwitchApplication.BrowseMembers
        },
        Members: {
            _$class: msls.ContentItem,
            _$name: "Members",
            _$parentName: "MemberList",
            screen: lightSwitchApplication.BrowseMembers,
            data: lightSwitchApplication.BrowseMembers,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.BrowseMembers,
                _$entry: {
                    elementType: lightSwitchApplication.Member
                }
            }
        },
        rows: {
            _$class: msls.ContentItem,
            _$name: "rows",
            _$parentName: "Members",
            screen: lightSwitchApplication.BrowseMembers,
            data: lightSwitchApplication.Member,
            value: lightSwitchApplication.Member
        },
        FirstName: {
            _$class: msls.ContentItem,
            _$name: "FirstName",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseMembers,
            data: lightSwitchApplication.Member,
            value: String
        },
        LastName: {
            _$class: msls.ContentItem,
            _$name: "LastName",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseMembers,
            data: lightSwitchApplication.Member,
            value: String
        },
        Birthday: {
            _$class: msls.ContentItem,
            _$name: "Birthday",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseMembers,
            data: lightSwitchApplication.Member,
            value: Date
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseMembers
        }
    };

    msls._addEntryPoints(lightSwitchApplication.BrowseMembers, {
        /// <field>
        /// Called when a new BrowseMembers screen is created.
        /// <br/>created(msls.application.BrowseMembers screen)
        /// </field>
        created: [lightSwitchApplication.BrowseMembers],
        /// <field>
        /// Called before changes on an active BrowseMembers screen are applied.
        /// <br/>beforeApplyChanges(msls.application.BrowseMembers screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.BrowseMembers],
        /// <field>
        /// Called after the MemberList content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        MemberList_postRender: [$element, function () { return new lightSwitchApplication.BrowseMembers().findContentItem("MemberList"); }],
        /// <field>
        /// Called after the Members content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Members_postRender: [$element, function () { return new lightSwitchApplication.BrowseMembers().findContentItem("Members"); }],
        /// <field>
        /// Called after the rows content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        rows_postRender: [$element, function () { return new lightSwitchApplication.BrowseMembers().findContentItem("rows"); }],
        /// <field>
        /// Called after the FirstName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName_postRender: [$element, function () { return new lightSwitchApplication.BrowseMembers().findContentItem("FirstName"); }],
        /// <field>
        /// Called after the LastName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName_postRender: [$element, function () { return new lightSwitchApplication.BrowseMembers().findContentItem("LastName"); }],
        /// <field>
        /// Called after the Birthday content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Birthday_postRender: [$element, function () { return new lightSwitchApplication.BrowseMembers().findContentItem("Birthday"); }]
    });

    lightSwitchApplication.Home.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.Home
        },
        Group: {
            _$class: msls.ContentItem,
            _$name: "Group",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.Home,
            data: lightSwitchApplication.Home,
            value: lightSwitchApplication.Home
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.Home
        }
    };

    msls._addEntryPoints(lightSwitchApplication.Home, {
        /// <field>
        /// Called when a new Home screen is created.
        /// <br/>created(msls.application.Home screen)
        /// </field>
        created: [lightSwitchApplication.Home],
        /// <field>
        /// Called before changes on an active Home screen are applied.
        /// <br/>beforeApplyChanges(msls.application.Home screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.Home],
        /// <field>
        /// Called after the Group content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Group_postRender: [$element, function () { return new lightSwitchApplication.Home().findContentItem("Group"); }]
    });

    lightSwitchApplication.ViewMember.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.ViewMember
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.ViewMember,
            value: lightSwitchApplication.ViewMember
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.ViewMember,
            value: lightSwitchApplication.Member
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: lightSwitchApplication.Member
        },
        FirstName: {
            _$class: msls.ContentItem,
            _$name: "FirstName",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        LastName: {
            _$class: msls.ContentItem,
            _$name: "LastName",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Birthday: {
            _$class: msls.ContentItem,
            _$name: "Birthday",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: Date
        },
        Address1: {
            _$class: msls.ContentItem,
            _$name: "Address1",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Address2: {
            _$class: msls.ContentItem,
            _$name: "Address2",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Address3: {
            _$class: msls.ContentItem,
            _$name: "Address3",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        PostalCode: {
            _$class: msls.ContentItem,
            _$name: "PostalCode",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        City: {
            _$class: msls.ContentItem,
            _$name: "City",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        SubscriptionStarts: {
            _$class: msls.ContentItem,
            _$name: "SubscriptionStarts",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: Date
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: lightSwitchApplication.Member
        },
        Country: {
            _$class: msls.ContentItem,
            _$name: "Country",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        MobileNumber: {
            _$class: msls.ContentItem,
            _$name: "MobileNumber",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        CreatedBy: {
            _$class: msls.ContentItem,
            _$name: "CreatedBy",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Created: {
            _$class: msls.ContentItem,
            _$name: "Created",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: Date
        },
        ModifiedBy: {
            _$class: msls.ContentItem,
            _$name: "ModifiedBy",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        Modified: {
            _$class: msls.ContentItem,
            _$name: "Modified",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: Date
        },
        LegalEntity: {
            _$class: msls.ContentItem,
            _$name: "LegalEntity",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        SubscriptionType: {
            _$class: msls.ContentItem,
            _$name: "SubscriptionType",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: String
        },
        SubscriptionEnds: {
            _$class: msls.ContentItem,
            _$name: "SubscriptionEnds",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMember,
            data: lightSwitchApplication.Member,
            value: Date
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.ViewMember
        }
    };

    msls._addEntryPoints(lightSwitchApplication.ViewMember, {
        /// <field>
        /// Called when a new ViewMember screen is created.
        /// <br/>created(msls.application.ViewMember screen)
        /// </field>
        created: [lightSwitchApplication.ViewMember],
        /// <field>
        /// Called before changes on an active ViewMember screen are applied.
        /// <br/>beforeApplyChanges(msls.application.ViewMember screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.ViewMember],
        /// <field>
        /// Called to determine if the deleteEntity method can be executed.
        /// <br/>canExecute(msls.application.ViewMember screen)
        /// </field>
        deleteEntity_canExecute: [lightSwitchApplication.ViewMember],
        /// <field>
        /// Called to execute the deleteEntity method.
        /// <br/>execute(msls.application.ViewMember screen)
        /// </field>
        deleteEntity_execute: [lightSwitchApplication.ViewMember],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("left"); }],
        /// <field>
        /// Called after the FirstName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("FirstName"); }],
        /// <field>
        /// Called after the LastName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("LastName"); }],
        /// <field>
        /// Called after the Birthday content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Birthday_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Birthday"); }],
        /// <field>
        /// Called after the Address1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address1_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Address1"); }],
        /// <field>
        /// Called after the Address2 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address2_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Address2"); }],
        /// <field>
        /// Called after the Address3 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address3_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Address3"); }],
        /// <field>
        /// Called after the PostalCode content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PostalCode_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("PostalCode"); }],
        /// <field>
        /// Called after the City content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        City_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("City"); }],
        /// <field>
        /// Called after the SubscriptionStarts content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        SubscriptionStarts_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("SubscriptionStarts"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("right"); }],
        /// <field>
        /// Called after the Country content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Country_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Country"); }],
        /// <field>
        /// Called after the MobileNumber content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        MobileNumber_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("MobileNumber"); }],
        /// <field>
        /// Called after the CreatedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        CreatedBy_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("CreatedBy"); }],
        /// <field>
        /// Called after the Created content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Created_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Created"); }],
        /// <field>
        /// Called after the ModifiedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ModifiedBy_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("ModifiedBy"); }],
        /// <field>
        /// Called after the Modified content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Modified_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("Modified"); }],
        /// <field>
        /// Called after the LegalEntity content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LegalEntity_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("LegalEntity"); }],
        /// <field>
        /// Called after the SubscriptionType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        SubscriptionType_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("SubscriptionType"); }],
        /// <field>
        /// Called after the SubscriptionEnds content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        SubscriptionEnds_postRender: [$element, function () { return new lightSwitchApplication.ViewMember().findContentItem("SubscriptionEnds"); }]
    });

    lightSwitchApplication.BrowseMemberDatas.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseMemberDatas
        },
        MemberDataList: {
            _$class: msls.ContentItem,
            _$name: "MemberDataList",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.BrowseMemberDatas,
            data: lightSwitchApplication.BrowseMemberDatas,
            value: lightSwitchApplication.BrowseMemberDatas
        },
        MemberDatas: {
            _$class: msls.ContentItem,
            _$name: "MemberDatas",
            _$parentName: "MemberDataList",
            screen: lightSwitchApplication.BrowseMemberDatas,
            data: lightSwitchApplication.BrowseMemberDatas,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.BrowseMemberDatas,
                _$entry: {
                    elementType: lightSwitchApplication.MemberData
                }
            }
        },
        rows: {
            _$class: msls.ContentItem,
            _$name: "rows",
            _$parentName: "MemberDatas",
            screen: lightSwitchApplication.BrowseMemberDatas,
            data: lightSwitchApplication.MemberData,
            value: lightSwitchApplication.MemberData
        },
        ParametersType: {
            _$class: msls.ContentItem,
            _$name: "ParametersType",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseMemberDatas,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        Parameters: {
            _$class: msls.ContentItem,
            _$name: "Parameters",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseMemberDatas,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseMemberDatas
        }
    };

    msls._addEntryPoints(lightSwitchApplication.BrowseMemberDatas, {
        /// <field>
        /// Called when a new BrowseMemberDatas screen is created.
        /// <br/>created(msls.application.BrowseMemberDatas screen)
        /// </field>
        created: [lightSwitchApplication.BrowseMemberDatas],
        /// <field>
        /// Called before changes on an active BrowseMemberDatas screen are applied.
        /// <br/>beforeApplyChanges(msls.application.BrowseMemberDatas screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.BrowseMemberDatas],
        /// <field>
        /// Called after the MemberDataList content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        MemberDataList_postRender: [$element, function () { return new lightSwitchApplication.BrowseMemberDatas().findContentItem("MemberDataList"); }],
        /// <field>
        /// Called after the MemberDatas content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        MemberDatas_postRender: [$element, function () { return new lightSwitchApplication.BrowseMemberDatas().findContentItem("MemberDatas"); }],
        /// <field>
        /// Called after the rows content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        rows_postRender: [$element, function () { return new lightSwitchApplication.BrowseMemberDatas().findContentItem("rows"); }],
        /// <field>
        /// Called after the ParametersType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ParametersType_postRender: [$element, function () { return new lightSwitchApplication.BrowseMemberDatas().findContentItem("ParametersType"); }],
        /// <field>
        /// Called after the Parameters content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Parameters_postRender: [$element, function () { return new lightSwitchApplication.BrowseMemberDatas().findContentItem("Parameters"); }]
    });

    lightSwitchApplication.AddEditMemberData.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditMemberData
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.AddEditMemberData,
            data: lightSwitchApplication.AddEditMemberData,
            value: lightSwitchApplication.AddEditMemberData
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.AddEditMemberData,
            data: lightSwitchApplication.AddEditMemberData,
            value: lightSwitchApplication.MemberData
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditMemberData,
            data: lightSwitchApplication.MemberData,
            value: lightSwitchApplication.MemberData
        },
        ParametersType: {
            _$class: msls.ContentItem,
            _$name: "ParametersType",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditMemberData,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditMemberData,
            data: lightSwitchApplication.MemberData,
            value: lightSwitchApplication.MemberData
        },
        Parameters: {
            _$class: msls.ContentItem,
            _$name: "Parameters",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditMemberData,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditMemberData
        }
    };

    msls._addEntryPoints(lightSwitchApplication.AddEditMemberData, {
        /// <field>
        /// Called when a new AddEditMemberData screen is created.
        /// <br/>created(msls.application.AddEditMemberData screen)
        /// </field>
        created: [lightSwitchApplication.AddEditMemberData],
        /// <field>
        /// Called before changes on an active AddEditMemberData screen are applied.
        /// <br/>beforeApplyChanges(msls.application.AddEditMemberData screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.AddEditMemberData],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.AddEditMemberData().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.AddEditMemberData().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.AddEditMemberData().findContentItem("left"); }],
        /// <field>
        /// Called after the ParametersType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ParametersType_postRender: [$element, function () { return new lightSwitchApplication.AddEditMemberData().findContentItem("ParametersType"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.AddEditMemberData().findContentItem("right"); }],
        /// <field>
        /// Called after the Parameters content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Parameters_postRender: [$element, function () { return new lightSwitchApplication.AddEditMemberData().findContentItem("Parameters"); }]
    });

    lightSwitchApplication.ViewMemberData.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.ViewMemberData
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.ViewMemberData,
            value: lightSwitchApplication.ViewMemberData
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.ViewMemberData,
            value: lightSwitchApplication.MemberData
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: lightSwitchApplication.MemberData
        },
        ParametersType: {
            _$class: msls.ContentItem,
            _$name: "ParametersType",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        Parameters: {
            _$class: msls.ContentItem,
            _$name: "Parameters",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        CreatedBy: {
            _$class: msls.ContentItem,
            _$name: "CreatedBy",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: lightSwitchApplication.MemberData
        },
        Created: {
            _$class: msls.ContentItem,
            _$name: "Created",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: Date
        },
        ModifiedBy: {
            _$class: msls.ContentItem,
            _$name: "ModifiedBy",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: String
        },
        Modified: {
            _$class: msls.ContentItem,
            _$name: "Modified",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewMemberData,
            data: lightSwitchApplication.MemberData,
            value: Date
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.ViewMemberData
        }
    };

    msls._addEntryPoints(lightSwitchApplication.ViewMemberData, {
        /// <field>
        /// Called when a new ViewMemberData screen is created.
        /// <br/>created(msls.application.ViewMemberData screen)
        /// </field>
        created: [lightSwitchApplication.ViewMemberData],
        /// <field>
        /// Called before changes on an active ViewMemberData screen are applied.
        /// <br/>beforeApplyChanges(msls.application.ViewMemberData screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.ViewMemberData],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("left"); }],
        /// <field>
        /// Called after the ParametersType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ParametersType_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("ParametersType"); }],
        /// <field>
        /// Called after the Parameters content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Parameters_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("Parameters"); }],
        /// <field>
        /// Called after the CreatedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        CreatedBy_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("CreatedBy"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("right"); }],
        /// <field>
        /// Called after the Created content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Created_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("Created"); }],
        /// <field>
        /// Called after the ModifiedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ModifiedBy_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("ModifiedBy"); }],
        /// <field>
        /// Called after the Modified content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Modified_postRender: [$element, function () { return new lightSwitchApplication.ViewMemberData().findContentItem("Modified"); }]
    });

}(msls.application));