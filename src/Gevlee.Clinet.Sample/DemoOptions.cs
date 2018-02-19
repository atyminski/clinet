using System;

namespace Gevlee.Clinet.Sample
{
    public class DemoOptions
    {
        public DateTime Date { get; set; }
        public bool Bool { get; set; }

        public override string ToString()
        {
            return $"Date: {Date}, Bool: {Bool}";
        }
    }
}