using Domain.Abstractions;
using System;

namespace Domain.Moisture
{
    public class Specification : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }        
    }
}
