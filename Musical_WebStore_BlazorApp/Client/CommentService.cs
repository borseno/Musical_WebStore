using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Services
{
    public class CommentService
    {
        private readonly HttpClient _httpClient;
        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<LeaveCommentResult> LeaveComment(LeaveCommentModel model)
            => _httpClient.PostJsonAsync<LeaveCommentResult>("api/comments/addcomment", model);

        public Task<DeleteCommentResult> DeleteComment(DeleteCommentModel model)
         => _httpClient.PostJsonAsync<DeleteCommentResult>("api/comments/deletecomment", model);        
    }
}