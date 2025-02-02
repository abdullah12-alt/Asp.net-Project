namespace NZWalk.API.Model.DTO
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CreateRegionDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
