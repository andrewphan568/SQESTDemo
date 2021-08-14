using Domain.Abstractions;
using System;

namespace Domain
{
    public class Project : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }  
    }
}
