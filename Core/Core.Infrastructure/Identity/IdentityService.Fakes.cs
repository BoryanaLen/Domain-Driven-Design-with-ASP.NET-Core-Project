namespace Core.Infrastructure.Identity
{
    using FakeItEasy;
    using Microsoft.AspNetCore.Identity;

    public class IdentityFakes
    {
        public const string TestEmail = "test@test.com";
        public const string ValidPassword = "TestPass";
        public const string ValidFirstName = "FirstName";
        public const string ValidLastName = "LastName";
        public const string ValidAddress = "TAddress";

        public static UserManager<User> FakeUserManager
        {
            get
            {
                var userManager = A.Fake<UserManager<User>>();

                A
                    .CallTo(() => userManager.FindByEmailAsync(TestEmail))
                    .Returns(new User());

                A
                    .CallTo(() => userManager.CheckPasswordAsync(A<User>.That.Matches(u => u.Email == TestEmail), ValidPassword))
                    .Returns(true);

                return userManager;
            }
        }
    }
}
