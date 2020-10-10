using System;

namespace NmAdminBackEnd.Models
{
    // Model layer.
    public class Article
    {
        public Article() { 
        }

        public Article(Article item)
        {
            this.CopyFrom(item);
        }

        public int ArticleId { get; set; }
        public string AbbreviationName { get; set; }
        public string FullName { get; set; }
        public string Specification { get; set; }
        public DateTime CreationDatetime { get; set; }
        public DateTime UpdateDatetime { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

        internal void CopyFrom(Article article)
        {
            this.ArticleId = article.ArticleId;
            this.AbbreviationName = article.AbbreviationName;
            this.FullName = article.FullName;
            this.Specification = article.Specification;
            this.CreationDatetime = article.CreationDatetime;
            this.UpdateDatetime = article.UpdateDatetime;
            this.Price = article.Price;
            this.Discount = article.Discount;
        }
    }
}
