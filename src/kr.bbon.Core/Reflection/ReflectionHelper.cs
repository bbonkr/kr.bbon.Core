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
        public static IEnumerable<Assembly> CollectAssemblty(Func<Type, bool> predicate)
        {
            return CollectAssemblty(predicate);
        }

        /// <summary>
        /// Collect list of assemblies that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Assembly> CollectAssemblty(Func<Type, int, bool> predicate)
        {
            return CollectAssemblty(predicate);
        }

        private static IEnumerable<Assembly> CollectAssemblty(Func<Type, bool> predicate = null, Func<Type, int, bool> predicateWithIndex = null)

        {
            if (predicate == null && predicateWithIndex == null)
            {
                throw new ArgumentNullException("Predicate must be set. Predicate should describe what type includes.");
            }

            var condition = predicateWithIndex ?? new Func<Type, int, bool>((t, i) => predicate(t));

            var entityTypeConfigurations = new List<Assembly>();

            var allAssembly = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in allAssembly)
            {
                // Does not support
                if (assembly.IsDynamic) { continue; }

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
            return CollectTypes(predicate: predicate);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypes(Func<Type, int, bool> predicate)
        {
            return CollectTypes(predicateWithIndex: predicate);
        }

        private static IEnumerable<Type> CollectTypes(Func<Type, bool> predicate = null, Func<Type, int, bool> predicateWithIndex = null)
        {
            if (predicateWithIndex == null && predicate == null)
            {
                throw new ArgumentNullException("Predicate must be set. Predicate should describe what type includes.");
            }

            var allAssembly = AppDomain.CurrentDomain.GetAssemblies();

            var condition = predicateWithIndex ?? new Func<Type, int, bool>((t, i) => predicate(t));

            foreach (var assembly in allAssembly)
            {
                // Does not support
                if (assembly.IsDynamic) { continue; }

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
