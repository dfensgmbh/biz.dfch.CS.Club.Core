﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 8/9/2015 5:03:52 PM
namespace LightSwitchApplication.Implementation
{
    
    /// <summary>
    /// There are no comments for ApplicationData in the schema.
    /// </summary>
    public partial class ApplicationData : global::Microsoft.LightSwitch.ClientGenerated.Implementation.DataServiceContext
    {
        /// <summary>
        /// Initialize a new ApplicationData object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public ApplicationData(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            global::System.Type resolvedType = this.DefaultResolveType(typeName, "LightSwitchApplication", "LightSwitchApplication.Implementation");
            if ((resolvedType != null))
            {
                return resolvedType;
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("LightSwitchApplication.Implementation", global::System.StringComparison.Ordinal))
            {
                return string.Concat("LightSwitchApplication.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Members in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Member> Members
        {
            get
            {
                if ((this._Members == null))
                {
                    this._Members = base.CreateQuery<Member>("Members");
                }
                return this._Members;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Member> _Members;
        /// <summary>
        /// There are no comments for Members in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToMembers(Member member)
        {
            base.AddObject("Members", member);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private const string ModelPart0 = "<edmx:Edmx Version=\"1.0\" xmlns:edmx=\"http://schemas.microsoft.com/ado/2007/06/edm" +
                "x\"><edmx:DataServices xmlns:m=\"http://schemas.microsoft.com/ado/2007/08/dataserv" +
                "ices/metadata\" m:DataServiceVersion=\"1.0\" m:MaxDataServiceVersion=\"3.0\"><Schema " +
                "xmlns:annotation=\"http://schemas.microsoft.com/ado/2009/02/edm/annotation\" Names" +
                "pace=\"LightSwitchApplication\" Alias=\"Self\" xmlns=\"http://schemas.microsoft.com/a" +
                "do/2008/09/edm\"><EntityType Name=\"Member\"><Key><PropertyRef Name=\"Id\" /></Key><P" +
                "roperty Name=\"Id\" Type=\"Edm.Int32\" Nullable=\"false\" annotation:StoreGeneratedPat" +
                "tern=\"Identity\" /><Property Name=\"FirstName\" Type=\"Edm.String\" Nullable=\"false\" " +
                "MaxLength=\"255\" /><Property Name=\"LastName\" Type=\"Edm.String\" Nullable=\"false\" M" +
                "axLength=\"255\" /><Property Name=\"Birthday\" Type=\"Edm.DateTime\" Nullable=\"false\" " +
                "/><Property Name=\"Address1\" Type=\"Edm.String\" Nullable=\"false\" MaxLength=\"255\" /" +
                "><Property Name=\"Address2\" Type=\"Edm.String\" MaxLength=\"255\" /><Property Name=\"A" +
                "ddress3\" Type=\"Edm.String\" MaxLength=\"255\" /><Property Name=\"PostalCode\" Type=\"E" +
                "dm.String\" Nullable=\"false\" MaxLength=\"255\" /><Property Name=\"City\" Type=\"Edm.St" +
                "ring\" Nullable=\"false\" MaxLength=\"255\" /><Property Name=\"State\" Type=\"Edm.String" +
                "\" MaxLength=\"255\" /><Property Name=\"Country\" Type=\"Edm.String\" Nullable=\"false\" " +
                "MaxLength=\"255\" /><Property Name=\"MobileNumber\" Type=\"Edm.String\" Nullable=\"fals" +
                "e\" MaxLength=\"255\" /><Property Name=\"CreatedBy\" Type=\"Edm.String\" MaxLength=\"255" +
                "\" /><Property Name=\"Created\" Type=\"Edm.DateTimeOffset\" /><Property Name=\"Modifie" +
                "dBy\" Type=\"Edm.String\" MaxLength=\"255\" /><Property Name=\"Modified\" Type=\"Edm.Dat" +
                "eTimeOffset\" /><Property Name=\"RowVersion\" Type=\"Edm.Binary\" Nullable=\"false\" Co" +
                "ncurrencyMode=\"Fixed\" annotation:StoreGeneratedPattern=\"Computed\" /></EntityType" +
                "><EntityContainer Name=\"ApplicationData\" m:IsDefaultEntityContainer=\"true\"><Enti" +
                "tySet Name=\"Members\" EntityType=\"LightSwitchApplication.Member\" /><FunctionImpor" +
                "t Name=\"Microsoft_LightSwitch_GetCanInformation\" ReturnType=\"Edm.String\" m:HttpM" +
                "ethod=\"GET\"><Parameter Name=\"dataServiceMembers\" Type=\"Edm.String\" Mode=\"In\" /><" +
                "/FunctionImport></EntityContainer></Schema></edmx:DataServices></edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static string GetConcatenatedEdmxString()
            {
                return string.Concat(ModelPart0);
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            public static global::Microsoft.Data.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel LoadModelFromString()
            {
                string edmxToParse = GetConcatenatedEdmxString();
                global::System.Xml.XmlReader reader = CreateXmlReader(edmxToParse);
                try
                {
                    return global::Microsoft.Data.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
    /// <summary>
    /// There are no comments for LightSwitchApplication.Member in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Members")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id")]
    public partial class Member : global::Microsoft.LightSwitch.ClientGenerated.Implementation.EntityBase, global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Member object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="firstName">Initial value of FirstName.</param>
        /// <param name="lastName">Initial value of LastName.</param>
        /// <param name="birthday">Initial value of Birthday.</param>
        /// <param name="address1">Initial value of Address1.</param>
        /// <param name="postalCode">Initial value of PostalCode.</param>
        /// <param name="city">Initial value of City.</param>
        /// <param name="country">Initial value of Country.</param>
        /// <param name="mobileNumber">Initial value of MobileNumber.</param>
        /// <param name="rowVersion">Initial value of RowVersion.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Member CreateMember(int ID, string firstName, string lastName, global::System.DateTime birthday, string address1, string postalCode, string city, string country, string mobileNumber, byte[] rowVersion)
        {
            Member member = new Member();
            member.Id = ID;
            member.FirstName = firstName;
            member.LastName = lastName;
            member.Birthday = birthday;
            member.Address1 = address1;
            member.PostalCode = postalCode;
            member.City = city;
            member.Country = country;
            member.MobileNumber = mobileNumber;
            member.RowVersion = rowVersion;
            return member;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                if (object.Equals(this.Id, value))
                {
                    return;
                }
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property FirstName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this.OnFirstNameChanging(value);
                if (object.Equals(this.FirstName, value))
                {
                    return;
                }
                this._FirstName = value;
                this.OnFirstNameChanged();
                this.OnPropertyChanged("FirstName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _FirstName;
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// There are no comments for Property LastName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this.OnLastNameChanging(value);
                if (object.Equals(this.LastName, value))
                {
                    return;
                }
                this._LastName = value;
                this.OnLastNameChanged();
                this.OnPropertyChanged("LastName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _LastName;
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        /// <summary>
        /// There are no comments for Property Birthday in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this.OnBirthdayChanging(value);
                if (object.Equals(this.Birthday, value))
                {
                    return;
                }
                this._Birthday = value;
                this.OnBirthdayChanged();
                this.OnPropertyChanged("Birthday");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _Birthday;
        partial void OnBirthdayChanging(global::System.DateTime value);
        partial void OnBirthdayChanged();
        /// <summary>
        /// There are no comments for Property Address1 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address1
        {
            get
            {
                return this._Address1;
            }
            set
            {
                this.OnAddress1Changing(value);
                if (object.Equals(this.Address1, value))
                {
                    return;
                }
                this._Address1 = value;
                this.OnAddress1Changed();
                this.OnPropertyChanged("Address1");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address1;
        partial void OnAddress1Changing(string value);
        partial void OnAddress1Changed();
        /// <summary>
        /// There are no comments for Property Address2 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address2
        {
            get
            {
                return this._Address2;
            }
            set
            {
                this.OnAddress2Changing(value);
                if (object.Equals(this.Address2, value))
                {
                    return;
                }
                this._Address2 = value;
                this.OnAddress2Changed();
                this.OnPropertyChanged("Address2");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address2;
        partial void OnAddress2Changing(string value);
        partial void OnAddress2Changed();
        /// <summary>
        /// There are no comments for Property Address3 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address3
        {
            get
            {
                return this._Address3;
            }
            set
            {
                this.OnAddress3Changing(value);
                if (object.Equals(this.Address3, value))
                {
                    return;
                }
                this._Address3 = value;
                this.OnAddress3Changed();
                this.OnPropertyChanged("Address3");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address3;
        partial void OnAddress3Changing(string value);
        partial void OnAddress3Changed();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                if (object.Equals(this.PostalCode, value))
                {
                    return;
                }
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                if (object.Equals(this.City, value))
                {
                    return;
                }
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property State in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string State
        {
            get
            {
                return this._State;
            }
            set
            {
                this.OnStateChanging(value);
                if (object.Equals(this.State, value))
                {
                    return;
                }
                this._State = value;
                this.OnStateChanged();
                this.OnPropertyChanged("State");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _State;
        partial void OnStateChanging(string value);
        partial void OnStateChanged();
        /// <summary>
        /// There are no comments for Property Country in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this.OnCountryChanging(value);
                if (object.Equals(this.Country, value))
                {
                    return;
                }
                this._Country = value;
                this.OnCountryChanged();
                this.OnPropertyChanged("Country");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Country;
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        /// <summary>
        /// There are no comments for Property MobileNumber in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string MobileNumber
        {
            get
            {
                return this._MobileNumber;
            }
            set
            {
                this.OnMobileNumberChanging(value);
                if (object.Equals(this.MobileNumber, value))
                {
                    return;
                }
                this._MobileNumber = value;
                this.OnMobileNumberChanged();
                this.OnPropertyChanged("MobileNumber");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _MobileNumber;
        partial void OnMobileNumberChanging(string value);
        partial void OnMobileNumberChanged();
        /// <summary>
        /// There are no comments for Property CreatedBy in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this.OnCreatedByChanging(value);
                if (object.Equals(this.CreatedBy, value))
                {
                    return;
                }
                this._CreatedBy = value;
                this.OnCreatedByChanged();
                this.OnPropertyChanged("CreatedBy");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CreatedBy;
        partial void OnCreatedByChanging(string value);
        partial void OnCreatedByChanged();
        /// <summary>
        /// There are no comments for Property Created in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTimeOffset> Created
        {
            get
            {
                return this._Created;
            }
            set
            {
                this.OnCreatedChanging(value);
                if (object.Equals(this.Created, value))
                {
                    return;
                }
                this._Created = value;
                this.OnCreatedChanged();
                this.OnPropertyChanged("Created");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTimeOffset> _Created;
        partial void OnCreatedChanging(global::System.Nullable<global::System.DateTimeOffset> value);
        partial void OnCreatedChanged();
        /// <summary>
        /// There are no comments for Property ModifiedBy in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ModifiedBy
        {
            get
            {
                return this._ModifiedBy;
            }
            set
            {
                this.OnModifiedByChanging(value);
                if (object.Equals(this.ModifiedBy, value))
                {
                    return;
                }
                this._ModifiedBy = value;
                this.OnModifiedByChanged();
                this.OnPropertyChanged("ModifiedBy");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ModifiedBy;
        partial void OnModifiedByChanging(string value);
        partial void OnModifiedByChanged();
        /// <summary>
        /// There are no comments for Property Modified in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTimeOffset> Modified
        {
            get
            {
                return this._Modified;
            }
            set
            {
                this.OnModifiedChanging(value);
                if (object.Equals(this.Modified, value))
                {
                    return;
                }
                this._Modified = value;
                this.OnModifiedChanged();
                this.OnPropertyChanged("Modified");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTimeOffset> _Modified;
        partial void OnModifiedChanging(global::System.Nullable<global::System.DateTimeOffset> value);
        partial void OnModifiedChanged();
        /// <summary>
        /// There are no comments for Property RowVersion in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public byte[] RowVersion
        {
            get
            {
                if ((this._RowVersion != null))
                {
                    return ((byte[])(this._RowVersion.Clone()));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnRowVersionChanging(value);
                if (object.Equals(this.RowVersion, value))
                {
                    return;
                }
                this._RowVersion = value;
                this.OnRowVersionChanged();
                this.OnPropertyChanged("RowVersion");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private byte[] _RowVersion;
        partial void OnRowVersionChanging(byte[] value);
        partial void OnRowVersionChanged();
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}