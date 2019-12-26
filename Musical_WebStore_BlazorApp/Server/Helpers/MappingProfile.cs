using System;
using AutoMapper;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;
using Musical_WebStore_BlazorApp.Shared.DTOs;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<User, UserLimited>();
        CreateMap<Comment, CommentLimited>();
        CreateMap<Star, StarDTO>();
        CreateMap<Testing, TestingDTO>();
    }
}