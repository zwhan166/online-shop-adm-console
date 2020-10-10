using Microsoft.EntityFrameworkCore;
using NmAdminBackEnd.Data;
using NmAdminBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NmAdminBackEnd.Services
{
    public class ArticleServiceImpl : IArticleService
    {
        // Database context based on the entity framework.
        private ArticleDbContext _dbContext;

        public ArticleServiceImpl() {
            this._dbContext = new ArticleDbContext();
        }

        ~ArticleServiceImpl() {
            if (null != this._dbContext)
            {
                this._dbContext.Dispose();
            }
        }

        public List<Article> ArticleList
        {
            get
            {
                List<Article> result = new List<Article>();
                foreach (Article item in this._dbContext.Articles.AsQueryable())
                {
                    result.Add(new Article(item));
                }
                return result;
            }
            set
            {
                this.ArticleList = new List<Article>(value);
            }
        }

        public Article GetArticleById(int id)
        {
            return this.ArticleList.Find(item => item.ArticleId == id); ;
        }

        // todo: test this function!
        public void UpdateArticle(Article article)
        {
            var entity = this._dbContext.Articles.FirstOrDefault(item => item.ArticleId == article.ArticleId);
            if (null != entity)
            {
                ((Article)entity).CopyFrom(article);
                this._dbContext.SaveChanges();
            }
        }

        public void AddArticle(Article article)
        {
            this._dbContext.Add(article);
            this._dbContext.SaveChanges();
        }

        public void DeleteById(int id) 
        {
            int index = this.ArticleList.FindIndex(item => item.ArticleId == id);
            if (index >= 0)
            {
                this.ArticleList.RemoveAt(index);
            }
        }

        // This method was used to initialized the local database.
        private List<Article> CreateDataList()
        {
            List<Article> dataList = new List<Article>();
            this.AddArticleFromList(dataList, 1, "a-101-led", "LED Highbay Industriebeleuchtung", "100 Watt, ca. 28 x 8.4 cm", new DateTime(2020, 8, 11), new DateTime(2020, 8, 21), 38.98, 0.9);
            this.AddArticleFromList(dataList, 2, "a-102-mini-speck", "Mini Speck", "1.2 kg", new DateTime(2020, 8, 11), new DateTime(2020, 8, 21), 10.9, 0.95);
            this.AddArticleFromList(dataList, 3, "a-103-heinz-ketchup", "HEINZ Tomato Ketchup", "1320 ml", new DateTime(2020, 8, 11), new DateTime(2020, 8, 21), 2.93, 0.88);
            this.AddArticleFromList(dataList, 4, "a-104-weissbier", "Franziskaner Weißbier Alkoholfrei", "6 x 0.5 l", new DateTime(2020, 8, 11), new DateTime(2020, 8, 21), 3.88, 0.88);
            this.AddArticleFromList(dataList, 5, "a-105-vitamin", "Vitafit Vitamin B12 Kur", "10 x 8 ml", new DateTime(2020, 8, 11), new DateTime(2020, 8, 21), 2.59, 0.88);
            //this.DataList = dataList;
            return dataList;
        }

        private void AddArticleFromList(List<Article> dataList, int id, string abbreviationName,
            string fullName, string specification,
            DateTime creationDatetime, DateTime updateDatetime,
            double price, double discount)
        {
            Article article = new Article()
            {
                ArticleId = id,
                AbbreviationName = abbreviationName,
                FullName = fullName,
                Specification = specification,
                CreationDatetime = creationDatetime,
                UpdateDatetime = updateDatetime,
                Price = price,
                Discount = discount
            };
            dataList.Add(article);
        }

    }
}
