using Domain.Abstractions;
using System;

namespace Domain
{
    public class Sample : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string SampledBy { get; set; } // should use AppUser? or  create another Laboratory Staff table ?
        public DateTime SampledDate { get; set; }
        public Guid ProjectId { get; set; }
    }
}
