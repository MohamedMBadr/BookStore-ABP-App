using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }


        private Author() { }

        internal Author(Guid id, string name, DateTime birthDate, string? shortBio) : base(id)
        {
            setName(name);
            BirthDate = birthDate;
            ShortBio = shortBio;

        }
        private void setName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name, nameof(name),
                maxLength: AuthorConsts.MaxNameLength
                );
        }
        internal Author ChangeName(string name)
        {
            setName(name);
            return this;
        }
    }
}
