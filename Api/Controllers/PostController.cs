using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        IPostService servicePost;
        public PostController(IPostService servicePost)
        {
            this.servicePost = servicePost;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<PostHashtags>> Get(DateTime? created_at)
        {
            if (created_at.HasValue) {
                var dateFilter = created_at.Value;
                try {
                    var posts = this.servicePost.Get(dateFilter);

                    return posts;
                } catch (Core.DTO.MapaSolidarioException ex) {
                    return Json( new { status = "error", message = ex.Message });
                }
            } else {
                return Json( new { status = "ERROR", message = "Debes ingrasar el parametro created_at " });
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Core.DTO.Post post)
        {
            String error = this.ValidatePost(post);
            if (error.Equals("")) {
                try {
                    return Created("", this.servicePost.Post(post));
                } catch (DAL.InvalidPostException ex) {
                    return Json( new { status = "ERROR", message = ex.Message });
                }
            } else {
                return Json( new { status = "ERROR", message = error });
            }
        }

        private String ValidatePost(Core.DTO.Post post) {
            String response = "";
            if (post != null) {
                if (post.Description == null) {
                    response = response + "El campo 'Description' es obligatorio.";
                }

                if (post.Latitud == null) {
                    response = response + "\n El campo 'Latitud' es obligatorio.";
                }

                if (post.Longitud == null) {
                    response = response + "\n El campo 'Longitud' es obligatorio.";
                }
            } else {
                response = response + "La consulta no es valida.";
            }

            return response;
        }
    }
}
