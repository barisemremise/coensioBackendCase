using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoensioBackendCase.Entities
{
    [Table("Choices")]
    public class Choice : BaseEntity
	{
        [Required]
        public string Text { get; set; }

        [NotMapped]
        public ICollection<QuestionChoice> QuestionChoices { get; set; }
	}
}

