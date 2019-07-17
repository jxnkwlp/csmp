using System;
using System.ComponentModel.DataAnnotations;

namespace CSMP.Portal.Domains
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    /// <summary>
    ///  basic entity
    /// </summary>
    public abstract class BaseEntity : IEntity<int>
    {
        public int Id { get; set; }
    }

    /// <summary>
    ///  basic entity with create time
    /// </summary>
    public abstract class BaseCreationEntity : BaseEntity
    {
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }


    public interface IAgentIdentifier
    {
        [MaxLength(32)]
        string AgentIdentifier { get; set; }
    }
}
