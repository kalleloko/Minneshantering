namespace SkalProj_Datastrukturer_Minne.Tests
{
    [TestClass()]
    public class BracketsParserTests
    {
        [TestMethod()]
        public void SimpleParseTest()
        {
            BracketsParser p = new("(hej){då}");

            List<BracketMatch> result = new()
            {
                new BracketMatch(0, ')', "(hej)"),
                new BracketMatch(5, '}', "{då}"),
            };

            CollectionAssert.AreEqual(result, p.Parse());
        }
        [TestMethod()]
        public void FailingParseTest()
        {
            BracketsParser p = new("((hej){då}");

            Assert.ThrowsException<FormatException>(p.Parse);
        }
        [TestMethod()]
        public void Failing2ParseTest()
        {
            BracketsParser p = new("hej){då}");

            Assert.ThrowsException<FormatException>(p.Parse);
        }
        [TestMethod()]
        public void Failing3ParseTest()
        {
            BracketsParser p = new("(hej{)då}");

            Assert.ThrowsException<FormatException>(p.Parse);
        }

        [TestMethod()]
        public void TestIfParenthesisIsClosingBracket()
        {
            Assert.IsTrue(BracketsParser.IsClosingBracket(')'));
        }

        [TestMethod()]
        public void TestIfSquareBracketIsClosingBracket()
        {
            Assert.IsTrue(BracketsParser.IsClosingBracket(']'));
        }

        [TestMethod()]
        public void TestIfCurlyBracketIsClosingBracket()
        {
            Assert.IsTrue(BracketsParser.IsClosingBracket('}'));
        }
        [TestMethod()]
        public void TestIfAIsClosingBracket()
        {
            Assert.IsFalse(BracketsParser.IsClosingBracket('a'));
        }
    }
}