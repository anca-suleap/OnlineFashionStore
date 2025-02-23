using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace OnlineFashionStore.Pages
{
    public class BlogModel : PageModel
    {
        public List<FashionSite> FashionLinks { get; set; }

        public void OnGet()
        {
            
            FashionLinks = new List<FashionSite>
            {
                new FashionSite
                {
                    Title = "Who What Wear",
                    Description = "Discover the latest UK fashion trends and must-have pieces for the season.",
                    Url = "https://www.whowhatwear.com/uk/fashion/trends"
                },
                new FashionSite
                {
                    Title = "Glamour",
                    Description = "Stay ahead with 2025's biggest fashion trends, from runway to street style.",
                    Url = "https://www.glamour.com/story/2025-fashion-trends"
                },
                new FashionSite
                {
                    Title = "Harper's Bazaar",
                    Description = "Luxury fashion, beauty tips, and exclusive interviews with industry leaders.",
                    Url = "https://www.harpersbazaar.com/"
                },
                new FashionSite
                {
                    Title = "ELLE",
                    Description = "Your go-to source for the latest fashion news, celebrity style, and runway trends.",
                    Url = "https://www.elle.com/"
                },
                new FashionSite
                {
                    Title = "Editorialist",
                    Description = "Meet the most influential fashion icons and their impact on style evolution.",
                    Url = "https://editorialist.com/fashion/influential-fashion-icons/"
                },
                 new FashionSite
                {
                    Title = "My Chic Obsession",
                    Description = "Avoid common fashion mistakes and learn how to refine your personal style.",
                    Url = "https://www.mychicobsession.com/common-fashion-mistakes/"
                }
            };
        }
    }

    public class FashionSite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}