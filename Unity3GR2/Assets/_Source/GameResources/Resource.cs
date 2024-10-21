namespace GameResources
{
    public class Resource
    {
        public ResourceTypes Type { get; private set; }
        public int Amount { get; private set; }

        public Resource(ResourceTypes type, int amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}