using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBuilderTests
{
    public class UserBuilder
    {
        private User _user = new User();

        public UserBuilder WithUserName(string username)
        { 
            _user.UserName = username;
            return this;
        }

        public UserBuilder WithEmail(string email)
        { 
            _user.Email = email;
            return this;
        }

        public UserBuilder WithDataOfBirth(DateTime dateOfBirth)
        { 
            _user.DateOfBirth = dateOfBirth;
            return this;
        }

        public User Build()
        { 
            return _user;
        }
    }
}
