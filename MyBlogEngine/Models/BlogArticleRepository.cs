using System;
using System.Collections.Generic;
using System.IO;

namespace MyBlogEngine.Models
{
    public class BlogArticleRepository : List<BlogArticle>
    {
        public string RootPath { get; set; }
        private string blogFile;

        public BlogArticleRepository(string rootPath, string blogFile)
        {
            this.RootPath = rootPath;
            this.blogFile = blogFile;
            GetAllBlogArticles(false);
        }

        public void GetAllBlogArticles(bool? forceReload)
        {
            if (this.Count == 0 || (forceReload == true))
            {
                this.Clear();
                LoadBlogArticlesFromDataStore();
            }
        }
        
        private void LoadBlogArticlesFromDataStore()
        {
            string[] allLines = File.ReadAllLines(Path.Combine(RootPath,blogFile)); 
            foreach (string line in allLines)
            {
                try
                {
                    string[] allItems = line.Split('|');

                    BlogArticle ba = new BlogArticle();
                    ba.Id = Convert.ToInt32(allItems[0]); 
                    ba.Title = allItems[1];
                    ba.Category = allItems[2];
                    ba.RelativeFilePath = allItems[3];
                    ba.Created = DateTime.Parse(allItems[4]);
                    this.Add(ba);
                }
                finally
                {

                }
            }
        }

    }
}
