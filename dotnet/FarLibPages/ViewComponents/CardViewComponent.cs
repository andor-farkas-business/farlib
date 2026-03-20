using FarLibPages.ViewComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarLibPages.ViewComponents;

public class CardViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(
        string imageSource,
        string imageAlt,
        string title,
        string text,
        string buttonPage,
        string buttonRouteId,
        string buttonText
    )
    {
        var card = new Card()
        {
            ImageSource = imageSource,
            ImageAlt = imageAlt,
            Title = title,
            Text = text,
            ButtonPage = buttonPage,
            ButtonRouteId = buttonRouteId,
            ButtonText = buttonText
        };

        return View(card);
    }
}