using System;

namespace Katherine.Models
{
    public class KatherineRoute
    {

        public Guid RouteId { get; set; }
        public string Route { get; set; } /* Section Id */

        public bool IsPublished { get; set; }
        public DateTime? IsDeleted { get; set; }

        public DateTime CreateDate { get; set; }
        public Guid CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }

        public Guid ContentTypeId { get; set; } /* Section Id */
        public Guid ContentId { get; set; } /* Id of the custom content whatever it may be */


    }
}