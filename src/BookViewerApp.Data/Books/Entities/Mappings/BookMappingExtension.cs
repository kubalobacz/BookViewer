using BookViewerApp.Domain.Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookViewerApp.Data.Books.Entities.Mappings
{
    static class BookMappingExtension
    {
        public static BookDbEntity ToDbEntity(this Book bookDbEntity)
        {
            return new BookDbEntity
            {
                ID = bookDbEntity.ID,
                Title = bookDbEntity.Title,
                ReleaseYear = bookDbEntity.ReleaseYear,
                Publisher = bookDbEntity.Publisher,
                CoverFileName = bookDbEntity.CoverFileName
            };
        }
    }
}
