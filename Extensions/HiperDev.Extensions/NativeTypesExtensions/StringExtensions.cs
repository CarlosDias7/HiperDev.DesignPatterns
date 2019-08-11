using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiperDev.Extensions.NativeTypesExtensions
{
    public static class StringExtensions
    {
        public static bool In(this string valor, params string[] array) => array.Contains(valor);

        public static int ToInt(this string valor) => int.Parse(valor);
    }
}