using QualifiedAgencies.Debugging;

namespace QualifiedAgencies
{
    public class QualifiedAgenciesConsts
    {
        public const string LocalizationSourceName = "QualifiedAgencies";

        public const string ConnectionStringName = "Default";
        public const string AppClaimTypes = "";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "b09e9d4c83314c78b0cf6a0f905f296f";
    }
}
