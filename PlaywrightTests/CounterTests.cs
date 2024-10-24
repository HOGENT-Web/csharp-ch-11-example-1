using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Example.PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
public class CounterTests : PageTest
{
    [Test]
    public async Task Clicking_Counter_Updates_Count()
    {
        // Navigate to the counter page
        await Page.GotoAsync($"{TestHelper.ServerBaseUrl}/counter");

        // Wait until the counter page is really there.
        await Page.WaitForSelectorAsync("h1");

        // Click on counter
        await Page.ClickAsync("data-test-id=counter-button");

        // Assert
        var content = await Page.TextContentAsync("p");
        Assert.That(content, Is.EqualTo("Current count: 1"));

    }
}
