namespace GameResources
{
    public class Resource
    {
        public ResourceTypes Type { get; set; }
        public int Amount { get; set; }

        public Resource(ResourceTypes type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}