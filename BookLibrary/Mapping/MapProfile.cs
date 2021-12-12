using AutoMapper;
using BookLibrary.DTOs;
using BookLibrary.DTOs.Author;
using BookLibrary.DTOs.Genre;
using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {

            CreateMap<BookInsDto, Book>();
            CreateMap<BookUpdDto, Book>();
            CreateMap<Book, BookDto>();

            CreateMap<AuthorUpdDto, BookAuthor>();

            CreateMap<GenreUpdDto, BookGenre>();

            CreateMap<BookAuthor,AuthorUpdDto > ()
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Author.Name))
                .ForMember(dest=>dest.Surname,opt=>opt.MapFrom(src=>src.Author.Surname));

            CreateMap<BookGenre, GenreUpdDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre.Name));
                

        }
    }
}
