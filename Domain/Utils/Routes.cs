namespace Booasacre.Domain.Utils;

public static class Routes
{
    public static class ApiRoute
    {
        private const string PrefixApi = "api";

        public static class Home
        {
            public const string Base = "/api";
            public const string Homepage = "";
            public const string Tobban = "tobban";
            public const string Toregular = "toregular";
        }

        public static class Security
        {
            private const string PrefixSecurity = PrefixApi + "";

            public static class Auth
            {
                public const string Base = PrefixSecurity + "/auth";
                public const string Login = "login";
                public const string Register = "register";
            }

            public static class Ldap
            {
                public const string Base = PrefixSecurity + "/ldap";
                public const string Login = "login";
            }
        }

        public static class Secure
        {
            private const string PrefixSecure = PrefixApi + "/secure";

            public static class Admin
            {
                private const string PrefixSecureAdmin = PrefixSecure + "/admin";

                public static class Branch
                {
                    public const string Base = PrefixSecureAdmin + "/branch";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }


                public static class User
                {
                    public const string Base = PrefixSecureAdmin + "/user";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string UpdateSecret = "updatesecret";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class Permission
                {
                    public const string Base = PrefixSecureAdmin + "/permission";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }
            }

            public static class App
            {
                private const string PrefixSecureApp = PrefixSecure + "/app";
                public static class PhoneNumber
                {
                    public const string Base = PrefixSecureApp + "/phoneNumber";
                    public const string Create = "create";
                }
                
                public static class Token
                {
                    public const string Base = PrefixSecureApp + "/token";
                    public const string Generate = "generate";
                    public const string Validate = "validate";
                }
                
                public static class Alert
                {
                    public const string Base = PrefixSecureApp + "/alert";
                    public const string Create = "create";
                }
            }
        }
    }
}