using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementService.DTO
{
    public class TaskDTO
    {
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
        [Required]

        public required string Description { get; set; }

        public DateTime LoggedTime { get; set; }

        public DateTime LastUpdated { get; set; }

        public TaskStatusEnum Status { get; set; }

        public bool IsFavorite { get; set; }

        public string[]? ImagesUrls { get; set; }
    }

    public enum TaskStatusEnum { TODO, InProgress, Done }
}
