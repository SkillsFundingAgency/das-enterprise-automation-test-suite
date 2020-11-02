using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.TestDataExport
{
    public class FrameworkList<T> : List<T>
    {
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var element in this)
            {
                s.Append(element?.ToString() + Environment.NewLine);
            }
            return s.ToString();
        }
    }
}