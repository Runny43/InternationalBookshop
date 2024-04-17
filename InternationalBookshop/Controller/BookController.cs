using InternationalBookshop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InternationalBookshop.Controller
{
    public class BookController
    {
        public List<Book> GetBooks(string valor)
        {
            List<Book> bookList = new List<Book>();
            DataTable dsBook;
            DatabaseHelper.Database database = new DatabaseHelper.Database();

            if (valor == string.Empty)
            {
                dsBook = database.GetBooks();
            }
            else
            {
                dsBook = database.SearchBook(valor);
            }

            foreach (DataRow dr in dsBook.Rows)
            {
                bookList.Add(new Book
                {
                    bookid = (int)dr["bookid"],
                    ISBN = dr["ISBN"].ToString(),
                    PhotoPath = dr["photoPath"].ToString(),
                    Title = dr["title"].ToString(),
                    Author = dr["author"].ToString(),
                    PublicationDate = Convert.ToDateTime(dr["publicationdate"]),
                    Price = (decimal)dr["Price"]
                });
            }

            return bookList;
        }

        public List<Book> GetBook(int id)
        {
            List<Book> bookList = GetBooks(string.Empty);

            foreach (Book book in bookList)
            {
                if (book.bookid == id)
                {
                    bookList.Clear();
                    bookList.Add(book);
                    return bookList;
                }
            }

            return null;
        }
        
    }
}
 