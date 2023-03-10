using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoensioBackendCase.Entities
{
	public class QuestionChoice : BaseEntity
	{
        public int QuestionId { get; set; }

        public Question Question { get; set; }

		[NotMapped]
		public int ChoiceId { get; set; }

		public Choice Choice { get; set; }
	}
}

