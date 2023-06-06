using AutoMapper;
using SanctionScanner.Common.DTOs.Book;
using SanctionScanner.Model.Entities;

namespace SanctionScanner.API.Infrastructor.Mapper
{
    public class BookMapperProfile:Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, AddBookRequest>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Book, BorrowBookRequest>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<Book, BookResponse>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
