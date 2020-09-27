using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DogGramService.API.Http
{
    public class GenericResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}
