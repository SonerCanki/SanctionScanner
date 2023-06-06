using AutoMapper;
using SanctionScanner.Common.DTOs.Book;
using SanctionScanner.UI.Models.Book;

namespace SanctionScanner.UI.Infrasructure.Mapper
{
    public class BookMapperProfile :Profile
    {
        public BookMapperProfile()
        {
            CreateMap<AddBookViewModel, AddBookRequest > ()
               .ReverseMap()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AddBookViewModel, BookResponse>()
               .ReverseMap()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BorrowBookViewModel, BorrowBookRequest>()
               .ReverseMap()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BorrowBookViewModel, BookResponse>()
               .ReverseMap()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ListBookViewModel, AddBookRequest>()
               .ReverseMap()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ListBookViewModel, BookResponse>()
               .ReverseMap()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
