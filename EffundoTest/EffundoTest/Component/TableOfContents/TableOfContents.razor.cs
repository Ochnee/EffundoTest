using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EffundoTest.Component.TableOfContents
{
    public partial class TableOfContents
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] public NavigationManager navigationManager { get; set; }
        public List<Header> Headers { get; set; }
        public bool Collapsed { get; set; } = false;

        public void ToggleCollapse()
        {
            Collapsed = !Collapsed;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Headers = (await JsRuntime.InvokeAsync<Header[]>("getHeaders")).ToList();
                StateHasChanged();
            }
        }

        public async Task GoToTitle(string titleId)
        {
            await JsRuntime.InvokeAsync<bool>("scrollToElementId", new[] { titleId });
        }
    }
}
