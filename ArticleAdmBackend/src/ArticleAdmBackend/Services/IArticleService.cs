using NmAdminBackEnd.Models;
using System.Collections.Generic;

namespace NmAdminBackEnd.Services
{
    // Data layer.
    public interface IArticleService
    {
        List<Article> ArticleList { get; set; }

        Article GetArticleById(int id);

        void UpdateArticle(Article article);

        void AddArticle(Article value);

        void DeleteById(int id);

    }
}
