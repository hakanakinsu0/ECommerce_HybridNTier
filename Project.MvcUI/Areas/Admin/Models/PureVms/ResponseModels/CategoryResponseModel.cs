using Project.Entities.Enums;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; }
    }
}
