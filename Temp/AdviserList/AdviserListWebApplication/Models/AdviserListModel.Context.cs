﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdviserListWebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdviserListDBEntities : DbContext
    {
        public AdviserListDBEntities()
            : base("name=AdviserListDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adviser> Advisers { get; set; }
        public virtual DbSet<AdviserCertificate> AdviserCertificates { get; set; }
        public virtual DbSet<AdviserCompany> AdviserCompanies { get; set; }
        public virtual DbSet<AdviserHistory> AdviserHistories { get; set; }
        public virtual DbSet<AdviserPhoto> AdviserPhotoes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<PromotionLocation> PromotionLocations { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual int AdviserCompanyDelete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserCompanyDelete", idParameter);
        }
    
        public virtual int AdviserCompanyInsert(Nullable<System.Guid> adviserId, Nullable<System.Guid> companyId, string designation, string contactNumber, string email, Nullable<bool> primaryFlag)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var companyIdParameter = companyId.HasValue ?
                new ObjectParameter("companyId", companyId) :
                new ObjectParameter("companyId", typeof(System.Guid));
    
            var designationParameter = designation != null ?
                new ObjectParameter("designation", designation) :
                new ObjectParameter("designation", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("contactNumber", contactNumber) :
                new ObjectParameter("contactNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var primaryFlagParameter = primaryFlag.HasValue ?
                new ObjectParameter("primaryFlag", primaryFlag) :
                new ObjectParameter("primaryFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserCompanyInsert", adviserIdParameter, companyIdParameter, designationParameter, contactNumberParameter, emailParameter, primaryFlagParameter);
        }
    
        public virtual ObjectResult<AdviserCompanySelectAll_Result> AdviserCompanySelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AdviserCompanySelectAll_Result>("AdviserCompanySelectAll");
        }
    
        public virtual int AdviserCompanyUpdate(Nullable<System.Guid> id, Nullable<System.Guid> adviserId, Nullable<System.Guid> companyId, string designation, string contactNumber, string email, Nullable<bool> primaryFlag)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var companyIdParameter = companyId.HasValue ?
                new ObjectParameter("companyId", companyId) :
                new ObjectParameter("companyId", typeof(System.Guid));
    
            var designationParameter = designation != null ?
                new ObjectParameter("designation", designation) :
                new ObjectParameter("designation", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("contactNumber", contactNumber) :
                new ObjectParameter("contactNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var primaryFlagParameter = primaryFlag.HasValue ?
                new ObjectParameter("primaryFlag", primaryFlag) :
                new ObjectParameter("primaryFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserCompanyUpdate", idParameter, adviserIdParameter, companyIdParameter, designationParameter, contactNumberParameter, emailParameter, primaryFlagParameter);
        }
    
        public virtual int AdviserCertificateDelete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserCertificateDelete", idParameter);
        }
    
        public virtual int AdviserCertificateInsert(Nullable<System.Guid> adviserId, string certificateName, string certificateDescription)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var certificateNameParameter = certificateName != null ?
                new ObjectParameter("certificateName", certificateName) :
                new ObjectParameter("certificateName", typeof(string));
    
            var certificateDescriptionParameter = certificateDescription != null ?
                new ObjectParameter("certificateDescription", certificateDescription) :
                new ObjectParameter("certificateDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserCertificateInsert", adviserIdParameter, certificateNameParameter, certificateDescriptionParameter);
        }
    
        public virtual int AdviserCertificateUpdate(Nullable<System.Guid> id, Nullable<System.Guid> adviserId, string certificateName, string certificateDescription)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var certificateNameParameter = certificateName != null ?
                new ObjectParameter("certificateName", certificateName) :
                new ObjectParameter("certificateName", typeof(string));
    
            var certificateDescriptionParameter = certificateDescription != null ?
                new ObjectParameter("certificateDescription", certificateDescription) :
                new ObjectParameter("certificateDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserCertificateUpdate", idParameter, adviserIdParameter, certificateNameParameter, certificateDescriptionParameter);
        }
    
        public virtual int AdviserDelete(Nullable<System.Guid> adviserId)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserDelete", adviserIdParameter);
        }
    
        public virtual int AdviserHistoryInsert(Nullable<System.Guid> adviserId, Nullable<double> latitude, Nullable<double> longitude, Nullable<bool> displayFlag)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(double));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(double));
    
            var displayFlagParameter = displayFlag.HasValue ?
                new ObjectParameter("displayFlag", displayFlag) :
                new ObjectParameter("displayFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserHistoryInsert", adviserIdParameter, latitudeParameter, longitudeParameter, displayFlagParameter);
        }
    
        public virtual int AdviserHistoryUpdate(Nullable<System.Guid> id, Nullable<System.Guid> adviserId, Nullable<double> latitude, Nullable<double> longitude, Nullable<bool> displayFlag)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(double));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(double));
    
            var displayFlagParameter = displayFlag.HasValue ?
                new ObjectParameter("displayFlag", displayFlag) :
                new ObjectParameter("displayFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserHistoryUpdate", idParameter, adviserIdParameter, latitudeParameter, longitudeParameter, displayFlagParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> AdviserInsert(string fullName, string displayName, string nric, Nullable<System.DateTime> dateOfBirth, string gender, string contactNumber, string email, string address, string aboutMeShort, string aboutMe, string creditCardNumber, Nullable<System.DateTime> creditCardExpire, Nullable<bool> recurringPaymentAgreementFlag, string password, Nullable<long> viewCountFromWeb, Nullable<long> viewCountFromApp)
        {
            var fullNameParameter = fullName != null ?
                new ObjectParameter("fullName", fullName) :
                new ObjectParameter("fullName", typeof(string));
    
            var displayNameParameter = displayName != null ?
                new ObjectParameter("displayName", displayName) :
                new ObjectParameter("displayName", typeof(string));
    
            var nricParameter = nric != null ?
                new ObjectParameter("nric", nric) :
                new ObjectParameter("nric", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("dateOfBirth", dateOfBirth) :
                new ObjectParameter("dateOfBirth", typeof(System.DateTime));
    
            var genderParameter = gender != null ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("contactNumber", contactNumber) :
                new ObjectParameter("contactNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var aboutMeShortParameter = aboutMeShort != null ?
                new ObjectParameter("aboutMeShort", aboutMeShort) :
                new ObjectParameter("aboutMeShort", typeof(string));
    
            var aboutMeParameter = aboutMe != null ?
                new ObjectParameter("aboutMe", aboutMe) :
                new ObjectParameter("aboutMe", typeof(string));
    
            var creditCardNumberParameter = creditCardNumber != null ?
                new ObjectParameter("creditCardNumber", creditCardNumber) :
                new ObjectParameter("creditCardNumber", typeof(string));
    
            var creditCardExpireParameter = creditCardExpire.HasValue ?
                new ObjectParameter("creditCardExpire", creditCardExpire) :
                new ObjectParameter("creditCardExpire", typeof(System.DateTime));
    
            var recurringPaymentAgreementFlagParameter = recurringPaymentAgreementFlag.HasValue ?
                new ObjectParameter("recurringPaymentAgreementFlag", recurringPaymentAgreementFlag) :
                new ObjectParameter("recurringPaymentAgreementFlag", typeof(bool));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var viewCountFromWebParameter = viewCountFromWeb.HasValue ?
                new ObjectParameter("viewCountFromWeb", viewCountFromWeb) :
                new ObjectParameter("viewCountFromWeb", typeof(long));
    
            var viewCountFromAppParameter = viewCountFromApp.HasValue ?
                new ObjectParameter("viewCountFromApp", viewCountFromApp) :
                new ObjectParameter("viewCountFromApp", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("AdviserInsert", fullNameParameter, displayNameParameter, nricParameter, dateOfBirthParameter, genderParameter, contactNumberParameter, emailParameter, addressParameter, aboutMeShortParameter, aboutMeParameter, creditCardNumberParameter, creditCardExpireParameter, recurringPaymentAgreementFlagParameter, passwordParameter, viewCountFromWebParameter, viewCountFromAppParameter);
        }
    
        public virtual int AdviserUpdate(Nullable<System.Guid> adviserId, string displayName, string nric, Nullable<System.DateTime> dateOfBirth, string gender, string contactNumber, string email, string address, string aboutMeShort, string aboutMe, string creditCardNumber, Nullable<System.DateTime> creditCardExpire, Nullable<bool> recurringPaymentAgreementFlag, string password, Nullable<long> viewCountFromWeb, Nullable<long> viewCountFromApp)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var displayNameParameter = displayName != null ?
                new ObjectParameter("displayName", displayName) :
                new ObjectParameter("displayName", typeof(string));
    
            var nricParameter = nric != null ?
                new ObjectParameter("nric", nric) :
                new ObjectParameter("nric", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("dateOfBirth", dateOfBirth) :
                new ObjectParameter("dateOfBirth", typeof(System.DateTime));
    
            var genderParameter = gender != null ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(string));
    
            var contactNumberParameter = contactNumber != null ?
                new ObjectParameter("contactNumber", contactNumber) :
                new ObjectParameter("contactNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var aboutMeShortParameter = aboutMeShort != null ?
                new ObjectParameter("aboutMeShort", aboutMeShort) :
                new ObjectParameter("aboutMeShort", typeof(string));
    
            var aboutMeParameter = aboutMe != null ?
                new ObjectParameter("aboutMe", aboutMe) :
                new ObjectParameter("aboutMe", typeof(string));
    
            var creditCardNumberParameter = creditCardNumber != null ?
                new ObjectParameter("creditCardNumber", creditCardNumber) :
                new ObjectParameter("creditCardNumber", typeof(string));
    
            var creditCardExpireParameter = creditCardExpire.HasValue ?
                new ObjectParameter("creditCardExpire", creditCardExpire) :
                new ObjectParameter("creditCardExpire", typeof(System.DateTime));
    
            var recurringPaymentAgreementFlagParameter = recurringPaymentAgreementFlag.HasValue ?
                new ObjectParameter("recurringPaymentAgreementFlag", recurringPaymentAgreementFlag) :
                new ObjectParameter("recurringPaymentAgreementFlag", typeof(bool));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var viewCountFromWebParameter = viewCountFromWeb.HasValue ?
                new ObjectParameter("viewCountFromWeb", viewCountFromWeb) :
                new ObjectParameter("viewCountFromWeb", typeof(long));
    
            var viewCountFromAppParameter = viewCountFromApp.HasValue ?
                new ObjectParameter("viewCountFromApp", viewCountFromApp) :
                new ObjectParameter("viewCountFromApp", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserUpdate", adviserIdParameter, displayNameParameter, nricParameter, dateOfBirthParameter, genderParameter, contactNumberParameter, emailParameter, addressParameter, aboutMeShortParameter, aboutMeParameter, creditCardNumberParameter, creditCardExpireParameter, recurringPaymentAgreementFlagParameter, passwordParameter, viewCountFromWebParameter, viewCountFromAppParameter);
        }
    
        public virtual int PromotionLocationDelete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PromotionLocationDelete", idParameter);
        }
    
        public virtual int PromotionLocationInsert(Nullable<System.Guid> adviserId, Nullable<int> cityId, string locationAddress, Nullable<double> latitude, Nullable<double> longitude, Nullable<System.DateTime> effectiveDate, Nullable<System.DateTime> expiryDate, Nullable<System.TimeSpan> effectiveTime, Nullable<System.TimeSpan> expiryTime, string description)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("cityId", cityId) :
                new ObjectParameter("cityId", typeof(int));
    
            var locationAddressParameter = locationAddress != null ?
                new ObjectParameter("locationAddress", locationAddress) :
                new ObjectParameter("locationAddress", typeof(string));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(double));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(double));
    
            var effectiveDateParameter = effectiveDate.HasValue ?
                new ObjectParameter("effectiveDate", effectiveDate) :
                new ObjectParameter("effectiveDate", typeof(System.DateTime));
    
            var expiryDateParameter = expiryDate.HasValue ?
                new ObjectParameter("expiryDate", expiryDate) :
                new ObjectParameter("expiryDate", typeof(System.DateTime));
    
            var effectiveTimeParameter = effectiveTime.HasValue ?
                new ObjectParameter("effectiveTime", effectiveTime) :
                new ObjectParameter("effectiveTime", typeof(System.TimeSpan));
    
            var expiryTimeParameter = expiryTime.HasValue ?
                new ObjectParameter("expiryTime", expiryTime) :
                new ObjectParameter("expiryTime", typeof(System.TimeSpan));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PromotionLocationInsert", adviserIdParameter, cityIdParameter, locationAddressParameter, latitudeParameter, longitudeParameter, effectiveDateParameter, expiryDateParameter, effectiveTimeParameter, expiryTimeParameter, descriptionParameter);
        }
    
        public virtual int PromotionLocationUpdate(Nullable<System.Guid> id, Nullable<System.Guid> adviserId, string locationAddress, Nullable<double> latitude, Nullable<double> longitude, Nullable<System.DateTime> effectiveDate, Nullable<System.DateTime> expireDate, Nullable<System.TimeSpan> effectiveTime, Nullable<System.TimeSpan> expireTime, string description)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var locationAddressParameter = locationAddress != null ?
                new ObjectParameter("locationAddress", locationAddress) :
                new ObjectParameter("locationAddress", typeof(string));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(double));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(double));
    
            var effectiveDateParameter = effectiveDate.HasValue ?
                new ObjectParameter("effectiveDate", effectiveDate) :
                new ObjectParameter("effectiveDate", typeof(System.DateTime));
    
            var expireDateParameter = expireDate.HasValue ?
                new ObjectParameter("expireDate", expireDate) :
                new ObjectParameter("expireDate", typeof(System.DateTime));
    
            var effectiveTimeParameter = effectiveTime.HasValue ?
                new ObjectParameter("effectiveTime", effectiveTime) :
                new ObjectParameter("effectiveTime", typeof(System.TimeSpan));
    
            var expireTimeParameter = expireTime.HasValue ?
                new ObjectParameter("expireTime", expireTime) :
                new ObjectParameter("expireTime", typeof(System.TimeSpan));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PromotionLocationUpdate", idParameter, adviserIdParameter, locationAddressParameter, latitudeParameter, longitudeParameter, effectiveDateParameter, expireDateParameter, effectiveTimeParameter, expireTimeParameter, descriptionParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> AdviserPhotoInsert(Nullable<System.Guid> adviserId, string location, string name, string type, Nullable<bool> profileFlag)
        {
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var locationParameter = location != null ?
                new ObjectParameter("location", location) :
                new ObjectParameter("location", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var profileFlagParameter = profileFlag.HasValue ?
                new ObjectParameter("profileFlag", profileFlag) :
                new ObjectParameter("profileFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("AdviserPhotoInsert", adviserIdParameter, locationParameter, nameParameter, typeParameter, profileFlagParameter);
        }
    
        public virtual int AdviserPhotoUpdate(Nullable<System.Guid> id, Nullable<System.Guid> adviserId, string location, string name, string type, Nullable<bool> profileFlag)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var adviserIdParameter = adviserId.HasValue ?
                new ObjectParameter("adviserId", adviserId) :
                new ObjectParameter("adviserId", typeof(System.Guid));
    
            var locationParameter = location != null ?
                new ObjectParameter("location", location) :
                new ObjectParameter("location", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var profileFlagParameter = profileFlag.HasValue ?
                new ObjectParameter("profileFlag", profileFlag) :
                new ObjectParameter("profileFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdviserPhotoUpdate", idParameter, adviserIdParameter, locationParameter, nameParameter, typeParameter, profileFlagParameter);
        }
    }
}