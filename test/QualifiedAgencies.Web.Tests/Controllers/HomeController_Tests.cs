using System.Threading.Tasks;
using QualifiedAgencies.Models.TokenAuth;
using QualifiedAgencies.Web.Controllers;
using Shouldly;
using Xunit;

namespace QualifiedAgencies.Web.Tests.Controllers
{
    public class HomeController_Tests: QualifiedAgenciesWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}