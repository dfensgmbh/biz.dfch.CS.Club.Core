/// <reference path="data.js" />

(function (lightSwitchApplication) {

    msls._addEntryPoints(lightSwitchApplication.MemberData, {
        /// <field>
        /// Called when a new memberData is created.
        /// <br/>created(msls.application.MemberData entity)
        /// </field>
        created: [lightSwitchApplication.MemberData]
    });

    msls._addEntryPoints(lightSwitchApplication.Member, {
        /// <field>
        /// Called when a new member is created.
        /// <br/>created(msls.application.Member entity)
        /// </field>
        created: [lightSwitchApplication.Member]
    });

}(msls.application));
