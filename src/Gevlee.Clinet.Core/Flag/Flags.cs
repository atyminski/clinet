namespace Gevlee.Clinet.Core.Flag
{
    public static class Flags
    {
        public static IFlag String(string key) => new TypeFlag(key)
        {
            ConvertFunc = s => s
        };
        
        public static IFlag Int(string key) => new TypeFlag(key)
        {
            ConvertFunc = s => int.Parse(s)
        };
        
        public static IFlag DateTime(string key) => new TypeFlag(key)
        {
            ConvertFunc = s => System.DateTime.Parse(s)
        };
        
        public static IFlag Bool(string key) => new TypeFlag(key)
        {
            ConvertFunc = s => bool.Parse(s)
        };
    }
}