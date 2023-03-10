using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoensioBackendCase.Entities
{
    [Table("Questions")]
    public class Question : BaseEntity
	{
        [Required]
        public string Text { get; set; }

        [Required]
        public Choice Answer { get; set; }

        public ICollection<QuestionChoice> QuestionChoices { get; set; }

    }
}

