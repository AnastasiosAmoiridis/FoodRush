namespace Common
{
    public static class EntityConstraints
    {
        public const byte MAX_PHONE_LENGTH = 15;

        public const byte MIN_PHONE_LENGTH = 10;

        public const byte MAX_NAME_LENGTH = 200;

        public const byte MAX_CITY_LENGTH = 200;

        public const byte MAX_GLOBAL_PRODUCT_CATEGORY_TYPE_LENGTH = 100;

        public const byte MAX_EMAIL_LENGTH = 200;

        public const byte MAX_POSTALCODE_LENGTH = 10;

        public const short MAX_STREET_LENGTH = 300;

        public const short MAX_URL_LENGTH = 500;

        public const short MAX_INSTRUCTION_LENGTH = 1000;

        public const decimal MAX_RATING_VALUE = 5.0m;

        public const decimal MIN_RATING_VALUE = 0.0m;

        public const string DEFAULT_SQL_KEY_VALUE = "NEWID()";

        public const string CK_PRODUCT_BASEPRICE_MIN = "CK_Product_BasePrice_Min";

        public const string CK_STORE_PHONE_MIN = "CK_Store_Phone_Min";

        public const string CK_STORE_RATING_BOUNDARIES = "CK_Store_Rating_Boundaries";

        public static readonly Dictionary<string, string> CheckContraints = new Dictionary<string, string>
        {
            {CK_PRODUCT_BASEPRICE_MIN, "[BasePrice] >= 0.0" },
            {CK_STORE_PHONE_MIN, "LEN([Phone]) >= 10" },
            {CK_STORE_RATING_BOUNDARIES, "[Rating] >= 0.0 AND [Rating] <= 5.0" }
        };
    }
}
