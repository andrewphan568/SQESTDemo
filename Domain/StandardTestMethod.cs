using Domain.Abstractions;
using System;


namespace Domain
{
   public class StandardTestMethod: EntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
    }
}
