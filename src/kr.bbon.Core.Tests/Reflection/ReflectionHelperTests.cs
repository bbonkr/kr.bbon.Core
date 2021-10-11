using System;
using System.Linq;
using kr.bbon.Core.Reflection;
using Xunit;

namespace kr.bbon.Core.Tests.Reflection
{
    public class ReflectionHelperTests
    {
        [Fact(DisplayName ="Should collect kr.bbon.Core")]
        public void Collect_Assembly()
        {
            var assemblyName = "kr.bbon.Core";
            var predicte = new Func<Type, bool>(t => t.Name == nameof(ApiException));

            var assemblies = ReflectionHelper.CollectAssembly(predicte);

            Assert.NotNull(assemblies);
            
            Assert.Contains(assemblies, a => a.GetName().Name == assemblyName);
        }

        [Fact(DisplayName ="Should collect ApiException type")]
        public void Collect_Types()
        {
            var typeName = nameof(ApiException);
            var predicte = new Func<Type, bool>(t => t.Name == typeName);

            var types = ReflectionHelper.CollectTypes(predicte);

            Assert.NotNull(types);

            Assert.Contains(types, a => a.Name == typeName);
        }

        [Fact(DisplayName = "CollectTypes Should throw exception when predicate is null")]
        public void CollectTypes_Should_Throws_When_Predicate_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => {
                Func<Type, bool> predicate = null;
                foreach(var t in ReflectionHelper.CollectTypes(predicate))
                {
                    // nothing ;)
                }
            });
        }

        [Fact(DisplayName = "CollectAssemblty Shold throw exception when predicate is null")]
        public void CollectAssemblty_Should_Throw_When_Predicate_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => {
                Func<Type, bool> predicate = null;
                foreach (var t in ReflectionHelper.CollectAssembly(predicate))
                {
                    // nothing ;)
                }
            });
        }
    }
}
