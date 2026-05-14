using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wateen12148ArticalProject.Core;
using wateen12148ArticalProject.Data;

namespace wateen12148ArticalProject.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IDataHelper<AuthorPost> dataHelperForPost;
        public AuthorPost authorPost;

        public ArticleModel(IDataHelper<Core.AuthorPost> dataHelperForPost)

        {
            this.dataHelperForPost = dataHelperForPost;
            authorPost = new AuthorPost();
        }



        public void OnGet()
        {
            var id = HttpContext.Request.RouteValues["id"];
            authorPost = dataHelperForPost.Find(Convert.ToInt32(id));
        }
    }
}
