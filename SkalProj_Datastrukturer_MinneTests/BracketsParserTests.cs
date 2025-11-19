namespace SkalProj_Datastrukturer_Minne.Tests
{
    [TestClass()]
    public class BracketsParserTests
    {
        [TestMethod()]
        public void SimpleParseTest()
        {
            BracketsParser p = new("(hej){då}");

            List<(int, string)> result = new List<(int, string)>()
            {
                (0, "(hej)"),
                (5, "{då}"),
            };

            CollectionAssert.AreEqual(result, p.Parse());
        }
    }
}