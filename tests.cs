using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using NUnit.Framework;
using лаба13;

namespace ЛабаТесты
{
    [TestFixture]
    public class MyCollectionTests
    {
        [Test]
        public void TestAddAndRemoveItems()
        {
            var collection = new MyCollection<int>();
            Assert.AreEqual(0, collection.Count);

            collection.Add(1);
            Assert.AreEqual(1, collection.Count);

            collection.Add(2);
            Assert.AreEqual(2, collection.Count);

            collection.Remove(1);
            Assert.AreEqual(1, collection.Count);

            collection.RemoveAt(0);
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void TestInsertAndClearItems()
        {
            var collection = new MyCollection<int>();
            Assert.AreEqual(0, collection.Count);

            collection.Insert(0, 1);
            Assert.AreEqual(1, collection.Count);

            collection.Insert(0, 2);
            Assert.AreEqual(2, collection.Count);

            collection.Clear();
            Assert.AreEqual(0, collection.Count);
        }

        [Test]
        public void TestContainsItem()
        {
            var collection = new MyCollection<int>();
            Assert.IsFalse(collection.Contains(1));

            collection.Add(1);
            Assert.IsTrue(collection.Contains(1));
        }

        [Test]
        public void TestCopyTo()
        {
            var collection = new MyCollection<int>();
            var array = new int[2];

            collection.Add(1);
            collection.Add(2);

            collection.CopyTo(array, 0);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
        }
    }

    [TestFixture]
    public class MyObservableCollectionTests
    {
        [Test]
        public void TestAddAndRemoveItemsWithEvent()
        {
            var observableCollection = new MyObservableCollection<int>();
            var handlerCalled = false;

            observableCollection.CollectionChanged += (sender, e) =>
            {
                handlerCalled = true;
            };

            observableCollection.Add(1);
            Assert.IsTrue(handlerCalled);

            observableCollection.Remove(1);
            Assert.IsTrue(handlerCalled);
        }
    }
}

