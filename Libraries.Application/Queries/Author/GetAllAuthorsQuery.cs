using Libraries.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Application.Queries.Author
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
    {
    }
}