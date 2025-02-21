using System.Collections.Generic;
using QueueRealization;

namespace QueueUnitTests
{
    [TestClass]
    public sealed class QueueUnitTests
    {
        #region EnqueueTests
        [TestMethod]
        public void Enqueue_AddsItemToQueue()
        {
            var queue = new MyQueue<int>();

            queue.Enqueue(10);

            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void Enqueue_ResizesQueueWhenFull()
        {

            var queue = new MyQueue<int>(2);

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Assert.AreEqual(3, queue.Count);
        }
        #endregion
        #region DequeueTests
        [TestMethod]
        public void Dequeue_RemovesItemFromQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            var item = queue.Dequeue();

            Assert.AreEqual(10, item);
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void Dequeue_ThrowsExceptionWhenQueueIsEmpty()
        {
            var queue = new MyQueue<int>();

            Assert.ThrowsException<ArgumentException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void Dequeue_WrapsAroundCircularBuffer()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Dequeue();
            queue.Enqueue(40);

            var item = queue.Dequeue();

            Assert.AreEqual(20, item);
        }
        #endregion
        #region PeekTests
        [TestMethod]
        public void Peek_ReturnsFirstItemWithoutRemoving()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            var item = queue.Peek();

            Assert.AreEqual(10, item);
            Assert.AreEqual(2, queue.Count);
        }

        [TestMethod]
        public void Peek_ThrowsExceptionWhenQueueIsEmpty()
        {

            var queue = new MyQueue<int>();

            Assert.ThrowsException<ArgumentException>(() => queue.Peek());
        }
        #endregion
        #region ContainsTests
        [TestMethod]
        public void Contains_ReturnsTrueIfItemExists()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            bool contains = queue.Contains(20);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Contains_ReturnsFalseIfItemDoesNotExist()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            bool contains = queue.Contains(30);

            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Contains_ThrowsExceptionWhenQueueIsEmpty()
        {
            var queue = new MyQueue<int>();

            Assert.ThrowsException<ArgumentException>(() => queue.Contains(10));
        }
        #endregion
        #region CountTests
        [TestMethod]
        public void Count_ReturnsZeroForEmptyQueue()
        {
            var queue = new MyQueue<int>();

            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void Count_ReturnsCorrectValueAfterEnqueueAndDequeue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Dequeue();

            Assert.AreEqual(1, queue.Count);
        }
        #endregion
        #region ResizeTests
        [TestMethod]
        public void Resize_DoublesCapacityWhenFull()
        {
            var queue = new MyQueue<int>(2);
            queue.Enqueue(10);
            queue.Enqueue(20);

            queue.Enqueue(30);

            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod]
        public void Resize_PreservesOrderOfItems()
        {
            var queue = new MyQueue<int>(2);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Dequeue(); 
            queue.Enqueue(30);

            queue.Enqueue(40);

            Assert.AreEqual(20, queue.Dequeue());
            Assert.AreEqual(30, queue.Dequeue());
            Assert.AreEqual(40, queue.Dequeue());
        }
        #endregion
    }
}
