using Domain.Abstractions;
using System;

namespace Domain.Moisture
{
    public class SourceMaterial : EntityBase
    {
        public Guid Id { get; set; }
        public string SourceName { get; set; }
        public string MaterialDesciption { get; set; }
    }
}
