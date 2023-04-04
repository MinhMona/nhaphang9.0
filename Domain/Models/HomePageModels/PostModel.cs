using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.HomePageModels
{
    public class PostModel : HomeModel
    {
        public string? Title { get; set; }

        public string? Summary { get; set; }

        public bool? SideBar { get; set; }

        public Guid? CategoryId { get; set; }

        public string? Ogurl { get; set; }

        public string? Ogtitle { get; set; }

        public string? Ogdescription { get; set; }

        public string? OgfacebookTitle { get; set; }

        public string? OgfacebookDescription { get; set; }

        public string? OgtwitterTitle { get; set; }

        public string? OgtwitterDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaKeyWords { get; set; }

        public string? OgtwitterImage { get; set; }

        public string? OgfacebookImage { get; set; }

    }
}
