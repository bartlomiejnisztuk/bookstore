using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using BookStore.Models;

namespace BookStore.Controllers
{
    [EnableCors("http://localhost:63608","*","*")]
    public class BooksController : ApiController
    {
        // GET: api/Books
        [EnableQueryExt()]
        public IQueryable<Book> Get()
        {
            var repo = new BookRepository();
            return repo.List().AsQueryable();
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            var repo = new BookRepository();
            return id>0 ? repo.List().FirstOrDefault(x => x.Id == id) : repo.Create();
        }

        // POST: api/Books
        public void Post([FromBody]Book value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }

    public class EnableQueryExt:EnableQueryAttribute
    {
        public EnableQueryExt()
        {
            this.PageSize = 2;
        }

        public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
        {

            base.ValidateQuery(request, queryOptions);
        }
    }
}
