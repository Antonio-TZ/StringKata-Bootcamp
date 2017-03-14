using System;
using System.Collections.Generic;
using System.Linq;

namespace StringKata2 {
    public static class Extensions {
        public static int asInt(this string value) {
            int parsed;
            return int.TryParse(value, out parsed) ? parsed : 0;
        }
        public static IEnumerable<int> ThrowExceptionForNegatives(this IEnumerable<int> numbers) {
            if (numbers.Any(number => number < 0)) {
                throw new ArgumentOutOfRangeException(
                    $"No negatives allowed : {string.Join(",", numbers.Where(number => number < 0))}");
            } else {
                return numbers;
            }
        }
    }
}
