using CodeCraft.Data.Models;

namespace CodeCraft.Web.PublicPortal.Models;

public class CoursesViewModel
{
    public class FilterModel
    {
        public required string Label { get; set; }

        public required string Value { get; set; }

        public bool Enabled { get; set; } = false;
    }

    public class FiltersModel
    {
        public List<FilterModel> DifficultyLevels { get; set; } = [];

        public List<FilterModel> Durations { get; set; } = [];

        public List<FilterModel> Technologies { get; set; } = [];
    }

    public required FiltersModel Filters { get; set; }

    public List<Course> Courses { get; set; } = [];
}
