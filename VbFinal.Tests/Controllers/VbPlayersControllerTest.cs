using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VbFinal.Controllers;
using VbFinal.Models;

namespace VbFinal.Tests.Controllers
{
    [TestClass]
    public class VbPlayersControllerTest
    {
        VbPlayersController vbController;
        Mock<IMockVbPlayer> mock;
        List<VbPlayer> vbPlayers;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockVbPlayer>();

            vbPlayers = new List<VbPlayer>
            {
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Lori",
                    Lastname = "S",
                    Photo = "https://img.icons8.com/color/384/beach-volleyball.png"
                },
                new VbPlayer
                {
                    VbPlayerId = 962,
                    FirstName = "Zak",
                    Lastname = "N",
                    Photo = "https://img.icons8.com/ultraviolet/384/beach-volleyball.png"
                }
            };

            mock.Setup(m => m.VbPlayers).Returns(vbPlayers.AsQueryable());
            vbController = new VbPlayersController(mock.Object);
        }

        //a IndexViewLoads – Loads the Index view
        [TestMethod]
        public void IndexViewLoads()
        {
            // arrange
            // now handled in TestInitialize

            // act
            ViewResult res = vbController.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", res.ViewName);
        }

        //b IndexValidLoadsVbPlayers – Returns a list of all VbPlayers
        [TestMethod]
        public void IndexValidLoadsVbPlayers()
        {
            // act
            var res = (List<VbPlayer>)((ViewResult)vbController.Index()).Model;

            // assert
            CollectionAssert.AreEqual(vbPlayers.OrderBy(c => c.VbPlayerId).ToList(), res);
        }

        //c EditLoadsValidId – Loads the Edit view
        [TestMethod]
        public void EditLoadsValidId()
        {
            // act
            ViewResult res = vbController.Edit(961) as ViewResult;
            // assert
            Assert.AreEqual("Edit", res.ViewName);
        }

        //d EditLoadsVbPlayerValidId – Loads the correct VbPlayer
        [TestMethod]
        public void EditLoadsVbPlayerValidId()
        {
            // act
            var res = ((ViewResult)vbController.Edit(961)).Model;
            // assert
            Assert.AreEqual(vbPlayers.OrderBy(c => c.VbPlayerId == 961), res);
        }

        //e EditInvalidId – Loads the Error View
        [TestMethod]
        public void EditInvalidId()
        {
            // act

            // assert

        }

        //f EditNoId – Loads the Error View
        [TestMethod]
        public void EditNoId()
        {
            // act

            // assert

        }

        //g EditSaveInvalid – Loads the Edit view
        [TestMethod]
        public void EditSaveInvalid()
        {
            // act

            // assert

        }

        //h EditSaveValid – Redirects to Index
        [TestMethod]
        public void EditSaveValid()
        {
            // act

            // assert

        }
    }
}
