using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using CoensioBackendCase.Entities;
using Microsoft.AspNetCore.Mvc;
using CoensioBackendCase.Context;
using Microsoft.EntityFrameworkCore;

namespace CoensioBackendCase.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly DataContext _context;

        public QuestionController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<QuestionDto>>> GetQuestions()
        {
            var dbResult = _context.Questions.Include(q => q.Answer).Include(q => q.QuestionChoices).ThenInclude(qc => qc.Choice).ToList();

            List<QuestionDto> response = new List<QuestionDto>();
            foreach (var i in dbResult)
            {
                List<string> choices = new List<string>();
                foreach (var j in i.QuestionChoices)
                {
                    choices.Add(j.Choice.Text);
                }
                response.Add(new QuestionDto { Choices = choices, Text = i.Text, Answer = i.Answer.Text, Id = i.Id });
            }

            return Ok(response);

        }

        [HttpPost("create")]
        public async Task<ActionResult<QuestionDto>> AddQuestion(QuestionDto questionDto)
        {
            try
            {
                List<Choice> choices = await _context.Choices
                .Where(c => questionDto.Choices.Contains(c.Text)).ToListAsync();


                List<Choice> newChoices = new List<Choice>();

                Choice answer = choices.Find(e => e.Text == questionDto.Answer);
              
                foreach (string c in questionDto.Choices)
                {
                    if (choices.Find(e => e.Text == c) == null)
                    {
                        Choice newChoice = new Choice { Text = c };
                        newChoices.Add(newChoice);

                        if(answer == null && c == questionDto.Answer)
                        {
                            answer = newChoice;
                        }
                    }
                }

                _context.Choices.AddRange(newChoices);
                newChoices.AddRange(choices);

                List<QuestionChoice> questionChoices = new List<QuestionChoice>();

                foreach (Choice c in newChoices)
                {
                    questionChoices.Add(new QuestionChoice { Choice = c });
                }

                Question newQuestion = new Question { Text = questionDto.Text, Answer = answer, QuestionChoices = questionChoices };
                
                _context.Questions.Add(newQuestion);
                _context.SaveChanges();

                questionDto.Id = newQuestion.Id;

                return Ok(questionDto);

            } catch (Exception e)
            {
               return BadRequest(e);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<QuestionDto>> UpdateQuestion(int id, QuestionDto questionDto)
        {
            try
            {
                Question questionDb = _context.Questions.Include(q => q.Answer).Include(q => q.QuestionChoices).First(q => q.Id == id);

                _context.QuestionChoices.RemoveRange(questionDb.QuestionChoices);
                _context.SaveChanges();

                List<Choice> choices = await _context.Choices
                .Where(c => questionDto.Choices.Contains(c.Text)).ToListAsync();


                List<Choice> newChoices = new List<Choice>();

                Choice answer = choices.Find(e => e.Text == questionDto.Answer);

                foreach (string c in questionDto.Choices)
                {
                    if (choices.Find(e => e.Text == c) == null)
                    {
                        Choice newChoice = new Choice { Text = c };
                        newChoices.Add(newChoice);

                        if (answer == null && c == questionDto.Answer)
                        {
                            answer = newChoice;
                        }
                    }
                }

                _context.Choices.AddRange(newChoices);
                newChoices.AddRange(choices);

                List<QuestionChoice> questionChoices = new List<QuestionChoice>();

                foreach (Choice c in newChoices)
                {
                    questionChoices.Add(new QuestionChoice { Choice = c });
                }

                questionDb.QuestionChoices = questionChoices;
                questionDb.Answer = answer;
                questionDb.Text = questionDto.Text;

                _context.Questions.Update(questionDb);
                _context.SaveChanges();

                questionDto.Id = questionDb.Id;

                return Ok(questionDto);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}

