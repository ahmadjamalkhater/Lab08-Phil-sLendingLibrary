using NUnit.Framework;
//using Lab08_PhilsLendingLibrary;
using Assert = NUnit.Framework.Assert;

namespace testLibrary_LAB08
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CanAddBookToLibrary()
        {
            // Arrange
            Library<Book> library = new Library<Book>();
            Book book = new Book("123456", "Sample Book");

            // Act
            library.Add(book);

            // Assert
            Assert.AreEqual(1, library.Count);
        }

        [Test]
        public void BorrowExistingTitleReturnsBookAndRemovesIt()
        {
            // Arrange
            Library<Book> library = new Library<Book>();
            Book book = new Book("123456", "Sample Book");
            library.Add(book);

            // Act
            Book borrowedBook = library.Borrow("123456");

            // Assert
            Assert.AreEqual(book, borrowedBook);
            Assert.IsFalse(library.Contains(book));
            Assert.AreEqual(0, library.Count);
        }

        [Test]
        public void BorrowMissingTitleReturnsNull()
        {
            // Arrange
            Library<Book> library = new Library<Book>();

            // Act
            Book borrowedBook = library.Borrow("123456");

            // Assert
            Assert.IsNull(borrowedBook);
        }

        [Test]
        public void ReturnedBookIsBackInLibrary()
        {
            // Arrange
            Library<Book> library = new Library<Book>();
            Book book = new Book("123456", "Sample Book");
            library.Add(book);

            // Act
            library.Return(book);

            // Assert
            Assert.IsTrue(library.Contains(book));
            Assert.AreEqual(1, library.Count);
        }

        [Test]
        public void CanPackAndUnpackBackpack()
        {
            // Arrange
            Backpack<string> backpack = new Backpack<string>();
            string item = "Notebook";

            // Act
            backpack.Pack(item);
            string unpackedItem = backpack.Unpack(0);

            // Assert
            Assert.AreEqual(item, unpackedItem);
            Assert.AreEqual(0, backpack.Count);
        }
    }
}
