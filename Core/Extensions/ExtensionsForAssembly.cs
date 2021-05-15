using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core.Extensions
{
    public static class ExtensionsForAssembly
    {
        /// <summary>
        /// Gets all exported types of the specified assembly.
        /// Plattform independent.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>
        /// All exported types of the specified assembly.
        /// </returns>
        public static IEnumerable<Type> GetExportedTypesPlatformSafe(this Assembly assembly)
        {
            return assembly.GetExportedTypes();
        }
    }
}