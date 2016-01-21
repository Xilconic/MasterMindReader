using BoardGameEngine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameEngineTest
{
    [TestFixture]
    public class EnummerableExtensionsTest
    {
        [Test]
        public void Shuffle_EmptyEnummerable_ReturnEmpty()
        {
            // Setup
            var rng = new Random(1);
            var enummerable = Enumerable.Empty<object>();

            // Call
            IEnumerable<object> result = enummerable.Shuffle(rng);

            // Assert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Shuffle_EnummerableWithOneElement_ReturnThatElement()
        {
            // Setup
            var rng = new Random(1);
            var enummerable = new[] { 1 };

            // Call
            int[] result =  enummerable.Shuffle(rng).ToArray();

            // Assert
            CollectionAssert.AreEqual(enummerable, result);
        }

        [Test]
        public void Shuffle_EnummerableWithFiveElement_ReturnAllElementsFromThatSequenceInRandomOrder()
        {
            // Setup
            var rng = new Random(1);
            var enummerable = new[] { 1, 2, 3, 4, 5 };

            // Call
            int[] result = enummerable.Shuffle(rng).ToArray();

            // Assert
            CollectionAssert.AreNotEqual(enummerable, result);
            CollectionAssert.AreEquivalent(enummerable, result);
        }
    }
}
