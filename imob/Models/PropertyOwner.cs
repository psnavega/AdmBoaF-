using System;

namespace immob.Models
{
    public class PropertyOwner
    {
        public Guid Id { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
