using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.BookStore.EntityFrameworkCore.Books
{
    [Collection(BookStoreTestConsts.CollectionDefinitionName)]
    public class EfCoreBookAppService_Tests :BookAppService_Tests<BookStoreEntityFrameworkCoreTestModule>
    {
    }
}
