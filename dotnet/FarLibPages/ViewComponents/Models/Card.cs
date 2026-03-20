namespace FarLibPages.ViewComponents.Models;

public class Card
{
    public required string ImageSource { get; set; }
    public required string ImageAlt { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
    public required string ButtonPage { get; set; }
    public required string ButtonRouteId { get; set; }
    public required string ButtonText { get; set; }
}