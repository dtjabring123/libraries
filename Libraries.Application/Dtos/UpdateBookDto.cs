using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Dtos
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int? LibraryId { get; set; }
        public int? UserId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}