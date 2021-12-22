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
            return CollectAssembly(null, predicate);
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
            var allAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic);

            return CollectTypes(allAssembly, predicate, null);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypes(Func<Type, int, bool> predicate)
        {
            var allAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic);
            return CollectTypes(allAssembly, null, predicate);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypesFrom(IEnumerable<Assembly> assemblies, Func<Type, int, bool> predicate)
        {
            return CollectTypes(assemblies, null, predicate);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypesFrom(IEnumerable<Assembly> assemblies, Func<Type, bool> predicate)
        {
            return CollectTypes(assemblies, predicate, null);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypesFrom(Assembly assembly, Func<Type, int, bool> predicate)
        {
            var assemblies = new List<Assembly> { assembly };
            return CollectTypes(assemblies, null, predicate);
        }

        /// <summary>
        /// Collect list of types that satisfy the condition are collected
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<Type> CollectTypesFrom(Assembly assembly, Func<Type, bool> predicate)
        {
            var assemblies = new List<Assembly> { assembly };
            return CollectTypes(assemblies, predicate, null);
        }

        private static IEnumerable<Type> CollectTypes(IEnumerable<Assembly> assemblies, Func<Type, bool> predicate = null, Func<Type, int, bool> predicateWithIndex = null)
        {
            if (predicateWithIndex == null && predicate == null)
            {
                throw new ArgumentNullException("Predicate must be set. Predicate should describe what type includes.");
            }

            var condition = predicateWithIndex ?? new Func<Type, int, bool>((t, i) => predicate(t));

            foreach (var assembly in assemblies)
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
