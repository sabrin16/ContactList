using ContactListApp.Utilities;

namespace ContactListApp.Tests.Tests
{
    public class GuidGeneratorTests
    {
        [Fact]
        public void NewIDShouldNotBeEmptyAnd36LetterLong()
        {
            string id = GuidGenerator.newID();

            Assert.False(string.IsNullOrEmpty(id));
            Assert.Equal(36, id.Length);
        }

        [Fact]
        public void NewIDShouldReturnDifferentIDS()
        {
            string id1 = GuidGenerator.newID();
            string id2 = GuidGenerator.newID();
            string id3 = GuidGenerator.newID();

            Assert.NotEqual(id1, id2);
            Assert.NotEqual(id1, id3);
            Assert.NotEqual(id3, id2);
        }



    }
}
