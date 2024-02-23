using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tadbir.MMP.Models.Dto;
using Tadbir.MMP.Models.Entities;
using Tadbir.MMP.Models.Services;

namespace Tadbir.MMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {


        private readonly ToDoRepository _toDoRepository;
        public ToDoController(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
      
        // GET: api/<ToDoController>
        [HttpGet]
        public IActionResult Get()
        {
            var todoList = _toDoRepository.GetAll();
            return Ok(todoList);

        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var todo = _toDoRepository.Get(id);
            return Ok(todo);

        }
        /// <summary>
        /// پوشش های درخواستی به ترتیب 1و2و3 با عناوین دندان پزشکی-جراحی و بستری می باشد
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST api/<ToDoController>
        [HttpPost]
        public IActionResult Post([FromBody] ItemDto item)
        {
            for (int i = 0; i < item.InsuranceTypes.Length; i++)
            {
                var insuranceCheck = _toDoRepository.check(item.InsuranceTypes[i]);
                if (item.RequestInsuranceCoverage[i] < insuranceCheck.MinInsuranceCoverage || item.RequestInsuranceCoverage[i] > insuranceCheck.MaxInsuranceCoverage)
                {
                    return BadRequest("مقدار سرمایه وارد شده در بازه پوشش طرح انتخابی نمی باشد ");
                    break;
                }
            }
            var todoDto = new ToDoDto
            {
                RequestSubject = item.RequestSubject,
                InsertTime = DateTime.Now,
                IsRemoved = false,
                ReqDetails = new List<ReqDetails>()
            };

            for (int i = 0; i < item.RequestInsuranceCoverage.Length; i++)
            {
                var reqDetails = new ReqDetails
                {
                    InsuranceTypeId = item.InsuranceTypes[i],
                    RequestInsuranceCoverage = item.RequestInsuranceCoverage[i],
                };

                todoDto.ReqDetails.Add(reqDetails);
            }

            var result = _toDoRepository.Add(todoDto);
            string url = Url.Action(nameof(Get), "ToDo", new { Id = result.ToDoId }, Request.Scheme);
            return Created(url, true);



        }
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
