using YAEM.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using YAEM.Domain;
using Microsoft.Practices.Unity;
using log4net;

namespace YAEM.Server.Tests
{
    [TestClass()]
    public class UserServiceTest
    {
        private IUnityContainer container;
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            container = new UnityContainer();
            container.RegisterInstance<ILog>(LogManager.GetLogger(typeof(UserServiceTest)));
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            container = null;
        }
        //
        #endregion

        [TestMethod()]
        public void Register_SimpleUser_Registered()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = "Florian"  };
            Session expected = new Session() 
            { 
                ExpiryDate = DateTime.Now, 
                User = u 
            };
            Session actual;
            actual = target.Register(u);

            Assert.AreEqual<User>(expected.User, actual.User);
            Assert.IsTrue(expected.ExpiryDate < actual.ExpiryDate);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Register_UserIsNull_ArgumentNullException()
        {
            UserService target = new UserService(container);
            User u = null;
            Session actual;

            actual = target.Register(u);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Register_UserNameIsNull_ArgumentNullException()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = null };
            Session actual;

            actual = target.Register(u);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Register_UserNameIsEmpty_ArgumentException()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = String.Empty };
            Session actual;

            actual = target.Register(u);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Register_UserRegisteredTwice_InvalidOperationException()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = "Florian" };
            Session actual;
            actual = target.Register(u); 
            
            actual = target.Register(u);
        }

        [TestMethod()]
        public void UnRegister_SimpleUser_Unregistered()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = "Florian" };
            Session s = target.Register(u);

            target.UnRegister(s);

            Assert.IsFalse(target.IsRegistered(s));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnRegister_SessionNotRegistered_InvalidOperationException()
        {
            UserService target = new UserService(container);
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                User = new User() { Name = "Florian" }
            };
            
            target.UnRegister(s);   
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnRegister_SessionIsNull_ArgumentNullException()
        {
            UserService target = new UserService(container);
            Session s = null;

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void UnRegister_SessionExpiryDateNull_ArgumentException()
        {
            UserService target = new UserService(container);
            Session s = new Session()
            {
                User = new User()
                {
                    Name = "Florian"
                }
            };

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnRegister_SessionUserNull_ArgumentNullException()
        {
            UserService target = new UserService(container);
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
            };

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnRegister_UserUnregisteredTwice_InvalidOperationException()
        {
            UserService target = new UserService(container);
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                User = new User()
                {
                    Name = "Florian"
                }
            };
            target.UnRegister(s);

            target.UnRegister(s);
        }

        [TestMethod()]
        public void IsRegistered_SimpleUser_True()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = "Florian" };
            Session s = target.Register(u);

            Assert.IsTrue(target.IsRegistered(s));
        }

        [TestMethod()]
        public void IsRegistered_FakeSession_False()
        {
            UserService target = new UserService(container);
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                User = new User() { Name = "Florian" }
            };

            Assert.IsFalse(target.IsRegistered(s));
        }

        [TestMethod()]
        public void IsRegistered_RegisteredAndUnregisteredUser_False()
        {
            UserService target = new UserService(container);
            User u = new User() { Name = "Florian" };
            Session s = target.Register(u);
            target.UnRegister(s);

            Assert.IsFalse(target.IsRegistered(s));
        }

        [TestMethod()]
        public void IsRegistered_SessionIsNull_False()
        {
            UserService target = new UserService(container);

            Assert.IsFalse(target.IsRegistered(null));
        }
    }
}
