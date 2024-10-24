using System;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Example.PlaywrightTests;
[Parallelizable(ParallelScope.Self)]
public class FetchDataTests : PageTest
{
    [Test]
    public async Task Shows_Forecasts_On_Page_Load()
    {
        // Navigate to the fetchdata page
        await Page.GotoAsync($"{TestHelper.ServerBaseUrl}/fetchdata");

        // Wait until the fetchdata page is really there.
        await Page.WaitForSelectorAsync("h1");

        // Assert
        var amount = await Page.Locator("data-test-id=forecase-item").CountAsync();
        Assert.That(amount, Is.EqualTo(5));
    }
}
