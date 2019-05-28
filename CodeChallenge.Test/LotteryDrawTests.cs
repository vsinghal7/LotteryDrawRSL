using CodeChallenge.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CodeChallenge.Test
{
    [TestClass]
    public class LotteryDrawTests
    {
        DrawViewModel drawViewModel = new DrawViewModel();
        [TestMethod]
        public void GetDrawResultsCountTests()
        {
            var controller = new HomeController();
            var result = controller.FinalDrawResults(drawViewModel) as ViewResult;
            var draw = (DrawViewModel)result.ViewData.Model;
            Assert.AreEqual(20, draw.Draws.Length);
        }

        [TestMethod]
        public void GetDrawResultsViewDataTests()
        {
            var controller = new HomeController();
            var result = controller.FinalDrawResults(drawViewModel) as ViewResult;
            var draw = (DrawViewModel)result.ViewData.Model;
            Assert.IsNotNull(draw);
            Assert.IsNotNull(draw.Draws[0].ProductId, "OzLotto");
        }
    }
}
