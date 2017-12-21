namespace Invenio.Web.Helper
{
    public class DataAnnotationsAttributesHelper
    {
        // Customer User
        public const int CustomerUerCountryMaxLength = 100;
        public const int CustomerUserManufacturingMaxLength = 100;

        // Employee User
        public const int UserFullNameMinLength = 2;
        public const int UserFullNameMaxLength = 100;
        public const int UserRegionMaxLength = 100;
        public const int UserPasswordLength = 100;
        public const int UserPasswordMinLength = 6;

        //Order
        public const int OrderNameMaxLength = 50;
        public const int OrderNumberMaxLength = 50;

        //Report
        public const int ReportTextMinLength = 10;
        public const int ReportTextMaxLength = 5000;
    }
}
