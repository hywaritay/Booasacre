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
            
        }

        public static class Secure
        {
            private const string PrefixSecure = PrefixApi + "/secure";

            public static class Admin
            {
                private const string PrefixSecureAdmin = PrefixSecure + "/admin";
                
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
            
            public static class Content
            {
                private const string PrefixSecureContent = PrefixSecure + "/content";

                public static class Services
                {
                    public const string Base = PrefixSecureContent + "/services";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }
                public static class Benefit
                {
                    public const string Base = PrefixSecureContent + "/benefit";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class Consultation
                {
                    public const string Base = PrefixSecureContent + "/consultation";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class Contact
                {
                    public const string Base = PrefixSecureContent + "/contact";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class ContactInfo
                {
                    public const string Base = PrefixSecureContent + "/contactinfo";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class TeamMembers
                {
                    public const string Base = PrefixSecureContent + "/teammembers";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class CoreValues
                {
                    public const string Base = PrefixSecureContent + "/corevalues";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }

                public static class Statement
                {
                    public const string Base = PrefixSecureContent + "/statement";
                    public const string All = "all";
                    public const string Find = "find";
                    public const string Create = "create";
                    public const string Update = "update";
                    public const string Delete = "delete";
                    public const string State = "state";
                }
            }

        }
    }
}