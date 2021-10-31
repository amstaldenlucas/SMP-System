namespace SMPSystem.Areas.Web.ViewModels
{
    /// <summary>
    /// <see cref="SMPSystem.Models.ProductionStep" />
    /// </summary>
    public class ProductionStepVm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public int ExecutionOrder { get; set; }
    }
}
