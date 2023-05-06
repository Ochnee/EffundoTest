using BytexDigital.Blazor.Components.CookieConsent;
using EffundoTest;
using EffundoTest.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(x => new MockPageService(10));

builder.Services.AddCookieConsent(o =>
{
    o.Revision = 1;
    o.PolicyUrl = "/cookie-policy";

    // Call optional
    o.UseDefaultConsentPrompt(prompt =>
    {
        prompt.Position = ConsentModalPosition.BottomRight;
        prompt.Layout = ConsentModalLayout.Bar;
        prompt.SecondaryActionOpensSettings = true;
        prompt.AcceptAllButtonDisplaysFirst = false;
    });

    o.Categories.Add(new CookieCategory
    {
        TitleText = new()
        {
            ["en"] = "PayPal Services"
        },
        DescriptionText = new()
        {
            ["en"] = "Allows for the safe usage of the PayPal donation buttons on this website."
        },
        Identifier = "PayPal",
        IsPreselected = true,

        Services = new()
        {
            new CookieCategoryService
            {
                Identifier = "PayPal donation button",
                PolicyUrl = "https://policies.google.com/privacy",
                TitleText = new()
                {
                    ["en"] = "PayPal Donation Button"
                },
                ShowPolicyText = new()
                {
                    ["en"] = "Display policies",
                    ["de"] = "Richtlinien anzeigen"
                }
            }
        }
    });
});

await builder.Build().RunAsync();

