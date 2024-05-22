using Libraries.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<BookEntity> Add(BookEntity book);

        public Task<BookEntity> Delete(int id);

        public Task<BookEntity> Update(BookEntity book);
    }
}