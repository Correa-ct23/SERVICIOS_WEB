using System;
using API.J.Movies.DAL.Dtos;
using API.J.Movies.DAL.Models;
using AutoMapper;

public class Mappers : Profile
{
	public Mappers()
	{
		CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Movie, MovieDto>().ReverseMap();
        CreateMap<Movie, MovieCreateDto>().ReverseMap();
    }
}
