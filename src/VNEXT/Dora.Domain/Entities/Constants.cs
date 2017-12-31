namespace Dora.Domain.Entities
{
    public static class Constants
    {
        public const string CompanyName = "梦工厂";
        public const int INT36 = 36;
        public const int INT64 = 64;
        public const int INT128 = 128;
        public const int INT256 = 256;
        public const int INT512 = 512;
        public const int INT4000 = 4000;

        public enum UserType : int
        {
            普通员工 = 0,
            管理员 = 1,
            超级管理员 = 2
        }

        public enum IsLock : int
        {
            No = 0,
            Yes = 1
        }

        public enum Sex : int
        {
            /// <summary>
            /// Unknown 未知的性别
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// Man 男性
            /// </summary>
            Man = 1,

            /// <summary>
            /// Woman 女性
            /// </summary>
            Woman = 2,

            /// <summary>
            /// WomanToMan 女性改（变）为男性
            /// </summary>
            WomanToMan = 5,

            /// <summary>
            /// ManToWoman 男性改（变）为女性
            /// </summary>
            ManToWoman = 6,

            /// <summary>
            /// NoDiscription 未说明的性别
            /// </summary>
            NoDiscription = 9
        }

        public enum LogType : int
        {
            EventLog = 1,
            ErrorLog = 2
        }

        public enum SuccessOrError : int
        {
            Success=1,
            Error=0
        }
    }
}
