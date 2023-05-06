using BytexDigital.Blazor.Components.CookieConsent;
using Microsoft.AspNetCore.Components;

namespace EffundoTest.Shared
{
    public partial class Footer : IDisposable
    {
        [Inject]protected CookieConsentService cookieConsentService { get; set; }
        protected bool DisplayCookieSettingsButton { get; set; } = false;
        protected override async Task OnParametersSetAsync()
        {
            cookieConsentService.CookiePreferencesChanged += UpdateDisplayCookieButton;
            await UpdateDisplayCookieButton();
        }

        public async Task UpdateDisplayCookieButton()
        {
            DisplayCookieSettingsButton = (await cookieConsentService.GetPreferencesAsync())
                                          .AcceptedRevision == 1;
            StateHasChanged();
        }
        public void UpdateDisplayCookieButton(object sender, CookiePreferences preferences)
        {
            DisplayCookieSettingsButton = preferences.AcceptedRevision == 1;
            StateHasChanged();
        }

        public void Dispose()
        {
            cookieConsentService.CookiePreferencesChanged -= UpdateDisplayCookieButton;
        }
    }
}
