namespace CodeCraft.Web.AdminPortal.Models;

public class DataTableCellModel
{
    public required string Value { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public string? RouteId { get; set; }

    public bool IsLink
    {
        get
        {
            return !String.IsNullOrEmpty(Controller) && !String.IsNullOrEmpty(Action);
        }
    }

    public bool IsSpecificLink
    {
        get
        {
            return IsLink && !String.IsNullOrEmpty(RouteId);
        }
    }
}
