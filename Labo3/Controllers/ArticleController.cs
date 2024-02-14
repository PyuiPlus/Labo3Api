using BLL.Iterfaces;
using BLL.Models.DTO;
using BLL.Models.Forms;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILabo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleDTO>> GetAll()
        {
            return Ok(_articleService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<ArticleDTO> GetById(int id) 
        {
            ArticleDTO article = _articleService.GetById(id);

            return article is not null ? Ok(article) : NotFound();
        }

        [HttpGet("all/{id:int}")]

        public ActionResult<IEnumerable<ArticleDTO>> GetAllByUserId(int id)
        {
            return Ok(_articleService.GetAllByUserId(id));
        }

        [HttpPost]
        public ActionResult<ArticleDTO> Create(CreateArticleForm form)
        {
            ArticleDTO article = _articleService.Create(form);

            return article is not null ? Ok(form) : NotFound();
        }
    }
}
