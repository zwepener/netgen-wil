namespace CodeCraft.Web.AdminPortal.Models;

public class DataTableRowModel
{
    public required List<DataTableCellModel> Cells { get; set; }

    public string? ItemId { get; set; }

    public bool ActionsEnabled
    {
        get
        {
            return !String.IsNullOrEmpty(ItemId);
        }
    }
}
