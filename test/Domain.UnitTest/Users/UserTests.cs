using Domain.Users;
using FluentAssertions;
using SharedKernel.Domain.Enumerations.Users;
using SharedKernel.ValueObjects;
using Xunit;

namespace Domain.UnitTest.Users;

public class UserTests
{
    [Fact]
    public void Create_new_user()
    {
        // arrange
        var username = "test.user@snowmanlabs.com";
        var username_email = new Email(username);
        var password = "123456";
        var firstName = "Snowman";
        var lastName = "Labs";
        var userType = UserType.Professor;
        var userLevel = UserLevel.Professor;

        // act
        var user = User.Create(username, password, firstName, lastName, userType, userLevel);

        // assert
        user.Should().BeAssignableTo<User>();
        user.Username.Should().Be(username_email);
        user.Password.Should().Be(password);
        user.FirstName.Should().Be(firstName);
        user.LastName.Should().Be(lastName);
        user.Type.Should().Be(userType);
        user.Level.Should().Be(userLevel);
    }

    [Fact]
    public void Throw_exception_when_username_is_null()
    {
        // arrange
        var username = string.Empty;
        var password = "123456";
        var firstName = "Snowman";
        var lastName = "Labs";
        var userType = UserType.Professor;
        var userLevel = UserLevel.Professor;

        // act & assert
        FluentActions.Invoking(() => User.Create(username, password, firstName, lastName, userType,
                userLevel))
            .Should()
            .Throw<Exception>()
            .WithMessage("Username should not be null");
    }

    //... do all the validations for the rest of the properties
}
