using GlobalShopping.Data;

namespace GlobalShopping.Interfaces
{
    public interface IRegionConfiguration
    {
        public SupportedRegion DefaultRegionID { get; set; }
    }
}
