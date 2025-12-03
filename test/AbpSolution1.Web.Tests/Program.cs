using Microsoft.AspNetCore.Builder;
using AbpSolution1;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("AbpSolution1.Web.csproj"); 
await builder.RunAbpModuleAsync<AbpSolution1WebTestModule>(applicationName: "AbpSolution1.Web");

public partial class Program
{
}
