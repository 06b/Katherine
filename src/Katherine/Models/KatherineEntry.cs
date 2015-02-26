using System;

namespace Katherine.Models
{
    public class KatherineEntry
    {
        public Guid RouteId { get; set; }
        public Guid ContentId { get; set; } /* Section Id */

        public string PostName { get; set; }
        public string PostTagLine { get; set; }
        public string PostContent { get; set; }
        public Guid PostId { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }


        public DateTime CreateDate { get; set; }
        public Guid CreateBy { get; set; }
        public string ViewName { get; set; }

        public string PostThumbnail { get; set; }

        public bool IsGatedAsset { get; set; }
        public string PostAsset { get; set; }

    }

}