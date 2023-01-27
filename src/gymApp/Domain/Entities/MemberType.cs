using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class MemberType:Entity
    {
        public string Name { get; set; }

        public MemberType()
        {

        }

        public MemberType(string name)
        {
            Name = name;
        }
    }
}
