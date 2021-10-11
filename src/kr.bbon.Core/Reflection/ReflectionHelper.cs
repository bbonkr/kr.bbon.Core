using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace kr.bbon.Core.Reflection
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// Collect list of assemblies that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> CollectAssembly(Func<Type, bool> predicate)
        {
            return CollectAssembly(predicate, null);
        }

        /// <summary>
        /// Collect list of assemblies that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> CollectAssembly(Func<Type, int, bool> predicate)
        {
            return CollectAssembly(null,predicate);
        }

        private static IEnumerable<Assembly> CollectAssembly(Func<Type, bool> predicate = null, Func<Type, int, bool> predicateWithIndex = null)

        {
            if (predicate == null && predicateWithIndex == null)
            {
                throw new ArgumentNullException("Predicate must be set. Predicate should describe what type includes.");
            }

            var condition = predicateWithIndex ?? new Func<Type, int, bool>((t, i) => predicate(t));

            var entityTypeConfigurations = new List<Assembly>();

            var allAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic);

            foreach (var assembly in allAssembly)
            {
                var exportedTypes = assembly
                    .GetExportedTypes()
                    .Where(condition);

                if (exportedTypes.Any())
                {
                    yield return assembly;
                }
            }
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypes(Func<Type, bool> predicate)
        {
            return CollectTypes(predicate, null);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypes(Func<Type, int, bool> predicate)
        {
            return CollectTypes(null, predicate);
        }

        private static IEnumerable<Type> CollectTypes(Func<Type, bool> predicate = null, Func<Type, int, bool> predicateWithIndex = null)
        {
            if (predicateWithIndex == null && predicate == null)
            {
                throw new ArgumentNullException("Predicate must be set. Predicate should describe what type includes.");
            }

            var allAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic);

            var condition = predicateWithIndex ?? new Func<Type, int, bool>((t, i) => predicate(t));

            foreach (var assembly in allAssembly)
            {
                var foundTypes = assembly
                    .GetExportedTypes()
                    .Where(condition);

                foreach (var type in foundTypes)
                {
                    yield return type;
                }
            }
        }
    }
}
