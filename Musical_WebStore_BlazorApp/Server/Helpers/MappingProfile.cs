using System;
using AutoMapper;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<User, UserLimited>();
        CreateMap<Comment, CommentLimited>();
        
    }
}