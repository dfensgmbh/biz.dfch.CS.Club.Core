/// <reference path="data.js" />

(function (lightSwitchApplication) {

    var $Screen = msls.Screen,
        $defineScreen = msls._defineScreen,
        $DataServiceQuery = msls.DataServiceQuery,
        $toODataString = msls._toODataString,
        $defineShowScreen = msls._defineShowScreen;

    function AddEditMember(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the AddEditMember screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Member" type="msls.application.Member">
        /// Gets or sets the member for this screen.
        /// </field>
        /// <field name="details" type="msls.application.AddEditMember.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "AddEditMember", parameters);
    }

    function BrowseMembers(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the BrowseMembers screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Members" type="msls.VisualCollection" elementType="msls.application.Member">
        /// Gets the members for this screen.
        /// </field>
        /// <field name="details" type="msls.application.BrowseMembers.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "BrowseMembers", parameters);
    }

    function Home(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the Home screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="details" type="msls.application.Home.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "Home", parameters);
    }

    function ViewMember(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the ViewMember screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Member" type="msls.application.Member">
        /// Gets or sets the member for this screen.
        /// </field>
        /// <field name="details" type="msls.application.ViewMember.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "ViewMember", parameters);
    }

    function BrowseMemberDatas(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the BrowseMemberDatas screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="MemberDatas" type="msls.VisualCollection" elementType="msls.application.MemberData">
        /// Gets the memberDatas for this screen.
        /// </field>
        /// <field name="details" type="msls.application.BrowseMemberDatas.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "BrowseMemberDatas", parameters);
    }

    function AddEditMemberData(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the AddEditMemberData screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="MemberData" type="msls.application.MemberData">
        /// Gets or sets the memberData for this screen.
        /// </field>
        /// <field name="details" type="msls.application.AddEditMemberData.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "AddEditMemberData", parameters);
    }

    function ViewMemberData(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the ViewMemberData screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="MemberData" type="msls.application.MemberData">
        /// Gets or sets the memberData for this screen.
        /// </field>
        /// <field name="details" type="msls.application.ViewMemberData.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "ViewMemberData", parameters);
    }

    msls._addToNamespace("msls.application", {

        AddEditMember: $defineScreen(AddEditMember, [
            { name: "Member", kind: "local", type: lightSwitchApplication.Member }
        ], [
        ]),

        BrowseMembers: $defineScreen(BrowseMembers, [
            {
                name: "Members", kind: "collection", elementType: lightSwitchApplication.Member,
                createQuery: function () {
                    return this.dataWorkspace.ApplicationData.Members;
                }
            }
        ], [
        ]),

        Home: $defineScreen(Home, [
        ], [
        ]),

        ViewMember: $defineScreen(ViewMember, [
            { name: "Member", kind: "local", type: lightSwitchApplication.Member }
        ], [
            { name: "deleteEntity" }
        ]),

        BrowseMemberDatas: $defineScreen(BrowseMemberDatas, [
            {
                name: "MemberDatas", kind: "collection", elementType: lightSwitchApplication.MemberData,
                createQuery: function () {
                    return this.dataWorkspace.ApplicationData.MemberDatas;
                }
            }
        ], [
        ]),

        AddEditMemberData: $defineScreen(AddEditMemberData, [
            { name: "MemberData", kind: "local", type: lightSwitchApplication.MemberData }
        ], [
        ]),

        ViewMemberData: $defineScreen(ViewMemberData, [
            { name: "MemberData", kind: "local", type: lightSwitchApplication.MemberData }
        ], [
        ]),

        showAddEditMember: $defineShowScreen(function showAddEditMember(Member, options) {
            /// <summary>
            /// Asynchronously navigates forward to the AddEditMember screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("AddEditMember", parameters, options);
        }),

        showBrowseMembers: $defineShowScreen(function showBrowseMembers(options) {
            /// <summary>
            /// Asynchronously navigates forward to the BrowseMembers screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 0);
            return lightSwitchApplication.showScreen("BrowseMembers", parameters, options);
        }),

        showHome: $defineShowScreen(function showHome(options) {
            /// <summary>
            /// Asynchronously navigates forward to the Home screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 0);
            return lightSwitchApplication.showScreen("Home", parameters, options);
        }),

        showViewMember: $defineShowScreen(function showViewMember(Member, options) {
            /// <summary>
            /// Asynchronously navigates forward to the ViewMember screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("ViewMember", parameters, options);
        }),

        showBrowseMemberDatas: $defineShowScreen(function showBrowseMemberDatas(options) {
            /// <summary>
            /// Asynchronously navigates forward to the BrowseMemberDatas screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 0);
            return lightSwitchApplication.showScreen("BrowseMemberDatas", parameters, options);
        }),

        showAddEditMemberData: $defineShowScreen(function showAddEditMemberData(MemberData, options) {
            /// <summary>
            /// Asynchronously navigates forward to the AddEditMemberData screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("AddEditMemberData", parameters, options);
        }),

        showViewMemberData: $defineShowScreen(function showViewMemberData(MemberData, options) {
            /// <summary>
            /// Asynchronously navigates forward to the ViewMemberData screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("ViewMemberData", parameters, options);
        })

    });

}(msls.application));
