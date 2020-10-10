using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NmAdminBackEnd.Models;
using NmAdminBackEnd.Services;

namespace NmAdminBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        // Data service.
        private IArticleService _articleService;

        public ArticleController(IArticleService articelService) {
            this._articleService = articelService;
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return this._articleService.ArticleList;
        }

        [HttpGet("{id}", Name = "Get")]
        public Article Get(int id)
        {
            return this._articleService.GetArticleById(id);
        }

        [HttpPost]
        public void Post([FromBody] Article value)
        {
            this._articleService.AddArticle(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Article value)
        {
            this._articleService.UpdateArticle(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._articleService.DeleteById(id);
        }
    }
}
