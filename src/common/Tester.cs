using System;
using System.Collections.Generic;
using System.Text;

namespace outliner
{
    public class Tester
    {
        public static void info(Type t)
        {
            System.Diagnostics.Debug.WriteLine("[test] " + t.FullName);
        }

        public static void check(object expected, object actual, string description)
        {
            if (expected.ToString() != actual.ToString())
            {
                System.Diagnostics.Trace.WriteLine(description + " does not match ");
                System.Diagnostics.Trace.WriteLine("\t\texpected : " + expected.ToString());
                System.Diagnostics.Trace.WriteLine("\t\tactual   : " + actual.ToString());
            }
        }
    }
}
