namespace CodeCraft.Web.AdminPortal.Models;

public class DataTableModel
{
    public required string Title { get; set; }
    public required List<string> Headers { get; set; }

    public required List<DataTableRowModel> Rows { get; set; }

    public string? MainController { get; set; }

    public bool CreatingEnabled { get; set; } = false;
    public bool ViewingEnabled { get; set; } = false;
    public bool EditingEnabled { get; set; } = false;
    public bool DeletingEnabled { get; set; } = false;

    public bool ActionsEnabled
    {
        get
        {
            return CreatingEnabled || ViewingEnabled || EditingEnabled || DeletingEnabled;
        }
    }
}
