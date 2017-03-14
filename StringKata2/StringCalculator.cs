﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringKata2 {
    internal class StringCalculator {
        private List<string> delimiters = new List<string>() { ",", "\n" };
        private const string delimiterPattern = @"(?<=\[)[^\]]*(?=\])|(?<=//).(?=\n)";

        internal int add(string input) {
            return input.Split(getDelimiters(input), StringSplitOptions.None)
                .Select(number => number.asInt())
                .ThrowExceptionForNegatives()
                .Where(number => number <= 1000)
                .Sum();
        }

        private string[] getDelimiters(string input) {
            return deriveCustomDelimiters(input)
                .Union(delimiters)
                .ToArray();
        }

        private IEnumerable<string> deriveCustomDelimiters(string input) {
            return Regex.Matches(input, delimiterPattern).OfType<Match>()
                .Select(match => match.Value);
        }
    }
}