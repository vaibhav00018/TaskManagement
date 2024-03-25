using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementDataAccess.DBModel
{
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public required string Description { get; set; }

        public DateTime LoggedTime { get; set; }

        public DateTime LastUpdated { get; set; }

        public  string Status { get; set; }

        public byte IsFavorite { get; set; }

        public string? ImagesUrls { get; set; }
    }
}
