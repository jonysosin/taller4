using System;
using System.Collections.Generic;
using Core.DTO;
using DAL;

namespace Core.Interface
{
    public interface IPostService
    {
        DTO.Post Post(DTO.Post post);
        List<PostHashtags> Get(DateTime created_at);  
    }
}