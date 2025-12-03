using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpSolution1.Pages;

[Collection(AbpSolution1TestConsts.CollectionDefinitionName)]
public class Index_Tests : AbpSolution1WebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
