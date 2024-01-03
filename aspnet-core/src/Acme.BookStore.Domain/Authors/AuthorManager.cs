using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors
{
    public class AuthorManager :DomainService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(string name, DateTime birthDate, string? shortBoi = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            var existingAuthor = await _authorRepository.FindByNameAsync(name);

            if (existingAuthor != null)
            {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Author(
                GuidGenerator.Create(),
                name,
                birthDate,
                shortBoi
                );
        }
        public async Task ChangeNameAsync(Author author , string newName)
        {
            Check.NotNull(newName, nameof(newName));
            Check.NotNull(author , nameof(author));

            var existingAuthor = await _authorRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != author.Id)
            {
                throw new AuthorAlreadyExistsException(newName);

            }
            author.ChangeName(newName);
        }
    }
}
