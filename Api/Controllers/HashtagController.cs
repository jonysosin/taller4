using System.Collections.Generic;
using Core.DTO;
using Core.Interface;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashtagController : Controller
    {
        IHashtagService hashtagService;
        public HashtagController(IHashtagService hashtagService)
        {
            this.hashtagService = hashtagService;
        }

        [HttpGet]
        public ActionResult<List<Core.DTO.Hashtag>> Get()
        {
            try
            {
                var hashtagList = this.hashtagService.Get();

                return hashtagList;
            }
            catch (MapaSolidarioException ex)
            {
                return Json(new {
                    status="error",
                    message=ex.Message
                });
            }
        }
    }
}