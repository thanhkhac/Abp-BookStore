using Microsoft.AspNetCore.Builder;
using BookStore;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("BookStore.Web.csproj"); 
await builder.RunAbpModuleAsync<BookStoreWebTestModule>(applicationName: "BookStore.Web");

public partial class Program
{
}
