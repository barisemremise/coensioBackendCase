using System;
namespace CoensioBackendCase.Entities
{
	public class QuestionDto
	{
        public string Text { get; set; }

        public List<string> Choices { get; set; }

        public string? Answer { get; set; }

        public int? Id { get; set; }
    }
}