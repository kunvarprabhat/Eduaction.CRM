namespace Eduaction.DataModel
{
    public struct ConfigSetting
    {
        public static string SqlConnection { get; set; } = string.Empty;
        public static string LogPath { get; set; } = string.Empty;
        public static string MediaPath { get; set; } = string.Empty;
        public static string AdminEmail { get; set; } = string.Empty;
        public static string MediaBaseUrl { get; set; } = string.Empty;
        
    }
}
