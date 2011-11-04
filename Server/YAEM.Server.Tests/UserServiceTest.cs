using YAEM.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using YAEM.Domain;

namespace YAEM.Server.Tests
{
    [TestClass()]
    public class UserServiceTest
    {
        [TestMethod()]
        public void Register_SimpleUser_Registered()
        {
            UserService target = new UserService();
            User u = new User() { Name = "Florian"  };
            Session expected = new Session() 
            { 
                ExpiryDate = DateTime.Now, 
                SessionKey = Guid.NewGuid(), 
                User = u 
            };
            Session actual;
            actual = target.Register(u);

            Assert.AreEqual<User>(expected.User, actual.User);
            Assert.IsTrue(expected.ExpiryDate < actual.ExpiryDate);
            Assert.IsInstanceOfType(actual.SessionKey, typeof(Guid));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Register_UserIsNull_ArgumentNullException()
        {
            UserService target = new UserService();
            User u = null;
            Session actual;

            actual = target.Register(u);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Register_UserNameIsNull_ArgumentOutOfRangeException()
        {
            UserService target = new UserService();
            User u = new User() { Name = null };
            Session actual;

            actual = target.Register(u);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Register_UserNameIsEmpty_ArgumentOutOfRangeException()
        {
            UserService target = new UserService();
            User u = new User() { Name = String.Empty };
            Session actual;

            actual = target.Register(u);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Register_UserRegisteredTwice_InvalidOperationException()
        {
            UserService target = new UserService();
            User u = new User() { Name = "Florian" };
            Session actual;
            actual = target.Register(u); 
            
            actual = target.Register(u);
        }

        [TestMethod()]
        public void UnRegister_SimpleUser_Unregistered()
        {
            UserService target = new UserService();
            User u = new User() { Name = "Florian" };
            Session s = target.Register(u);
            target.UnRegister(s);

            Assert.IsFalse(target.IsRegistered(s));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnRegister_SessionNotRegistered_InvalidOperationException()
        {
            UserService target = new UserService();
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                SessionKey = Guid.NewGuid(),
                User = new User() { Name = "Florian" }
            };
            
            target.UnRegister(s);   
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnRegister_SessionIsNull_ArgumentNullException()
        {
            UserService target = new UserService();
            Session s = null;

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UnRegister_SessionExpiryDateNull_ArgumentOutOfRangeException()
        {
            UserService target = new UserService();
            Session s = new Session()
            {
                SessionKey = Guid.NewGuid(),
                User = new User()
                {
                    Name = "Florian"
                }
            };

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UnRegister_SessionSessionKeyNull_ArgumentOutOfRangeException()
        {
            UserService target = new UserService();
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                User = new User()
                {
                    Name = "Florian"
                }
            };

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UnRegister_SessionUserNull_ArgumentOutOfRangeException()
        {
            UserService target = new UserService();
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                SessionKey = Guid.NewGuid()
            };

            target.UnRegister(s);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnRegister_UserUnregisteredTwice_InvalidOperationException()
        {
            UserService target = new UserService();
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                SessionKey = Guid.NewGuid(),
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
            UserService target = new UserService();
            User u = new User() { Name = "Florian" };
            Session s = target.Register(u);

            Assert.IsTrue(target.IsRegistered(s));
        }

        [TestMethod()]
        public void IsRegistered_FakeSession_False()
        {
            UserService target = new UserService();
            Session s = new Session()
            {
                ExpiryDate = DateTime.Now.AddHours(1),
                SessionKey = Guid.NewGuid(),
                User = new User() { Name = "Florian" }
            };

            Assert.IsFalse(target.IsRegistered(s));
        }

        [TestMethod()]
        public void IsRegistered_RegisteredAndUnregisteredUser_False()
        {
            UserService target = new UserService();
            User u = new User() { Name = "Florian" };
            Session s = target.Register(u);
            target.UnRegister(s);

            Assert.IsFalse(target.IsRegistered(s));
        }

        [TestMethod()]
        public void IsRegistered_SessionIsNull_False()
        {
            UserService target = new UserService();

            Assert.IsFalse(target.IsRegistered(null));
        }
    }
}
