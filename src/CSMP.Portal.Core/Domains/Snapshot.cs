namespace CSMP.Portal.Domains
{
    /// <summary>
    ///  收集的数据
    /// </summary>
    public class Snapshot : IEntity<long>, IAgentIdentifier
    {
        public long Id { get; set; }

        public string AgentIdentifier { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }
    }
}
