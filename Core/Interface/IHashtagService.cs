using System.Collections.Generic;
using Core.DTO;
using DAL;

namespace Core.Interface
{
    public interface IHashtagService
    {
        List<DTO.Hashtag> Get();
    }
}