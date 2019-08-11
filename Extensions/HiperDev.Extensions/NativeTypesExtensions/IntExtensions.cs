using System;
using System.Collections.Generic;
using System.Text;

namespace HiperDev.Extensions.NativeTypesExtensions
{
    public static class IntExtensions
    {
        public static bool Between(this int valor, int inicio, int final) => valor >= inicio && valor <= final;
    }
}