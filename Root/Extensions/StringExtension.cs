﻿using System.Collections.Generic;

namespace Root.Extension
{
    public static class StringExtension
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            List<int> indexes = new List<int>();

            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                {
                    return indexes;
                }

                indexes.Add(index);
            }
        }
    }
}
