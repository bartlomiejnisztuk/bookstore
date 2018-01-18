using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace BookStore.Models
{
    public class BookRepository: IBookRepository
    {
        public List<Book> List()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/book.json");
            if (filePath != null)
            {
                var json = File.ReadAllText(filePath);
                var books = JsonConvert.DeserializeObject<List<Book>>(json);
                return books;
            }
            throw new FileNotFoundException("book.json file not found");
        }

        public Book Create()
        {
            return new Book();
        }
    }
}