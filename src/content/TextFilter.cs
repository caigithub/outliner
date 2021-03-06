﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace outliner
{
    public class TextFilter
    {
        public TextFilter()
        {
        }

        public TextFilter(string filter_string)
        {
            filterString = filter_string;
        }

        private string _filterString = "";
        private string _filterReg = "";
        public string filterString
        {
            get
            {
                return _filterString;
            }

            set
            {
                _filterString = value;
                _filterReg = makeReg(_filterString);
            }
        }

        public string filterReg
        {
            get
            {
                return _filterReg;
            }
        }

        public bool isValid()
        {
            return _filterReg.Length > 0;
        }

        public bool isMatch(string value)
        {
            return Regex.IsMatch(value, _filterReg, RegexOptions.IgnoreCase);
        }

        private string makeReg(string org)
        {
            string result = "";

            foreach (string i in retranslateReg(org.Trim()).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (result.Length <= 0)
                {
                    result = result + "(" + i + ")";
                }
                else
                {
                    result = result + "|(" + i + ")";
                }
            }

            return result;
        }

        private string retranslateReg(string org)
        {
            string result = org;

            result = result.Replace("\\", "\\\\");

            string[] reg = { "(", ")", "[", "]", "{", "}", "^", "$", "*", ".", "+", "?", "|" };
            foreach (string r in reg)
            {
                result = result.Replace(r, "\\" + r);
            }

            return result;
        }

        //====================================

        public void info()
        {
            System.Diagnostics.Debug.WriteLine("== filter org : " + filterString);
            System.Diagnostics.Debug.WriteLine("== filter reg : " + _filterReg);
            System.Diagnostics.Debug.WriteLine("== filter valid : " + isValid().ToString());
        }

    }
}
