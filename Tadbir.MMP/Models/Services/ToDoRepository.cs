using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.EntityFrameworkCore;
using Tadbir.MMP.Models.Context;
using Tadbir.MMP.Models.Entities;

namespace Tadbir.MMP.Models.Services
{
    public class ToDoRepository
    {
        private readonly DataBaseContext _context;
        public ToDoRepository(DataBaseContext context)
        {
            _context = context;
        }
        public List<ToDoDto> GetAll()
        {
            return _context.ToDos
                .Include(p => p.ReqDetails)
                .Select(p => new ToDoDto
                {
                    ToDoId = p.ToDoId,
                    RequestSubject = p.RequestSubject,
                    NetInsurancePremium = p.NetInsurancePremium,
                    InsertTime = p.InsertTime,
                    IsRemoved = p.IsRemoved,
                    ReqDetails = p.ReqDetails,

                }).ToList();
        }
        public ToDoDto Get(int Id)
        {
            var todo = _context.ToDos
                .Include(p => p.ReqDetails)
                .SingleOrDefault(p => p.ToDoId == Id);
            return new ToDoDto()
            {
                ToDoId = todo.ToDoId,
                RequestSubject = todo.RequestSubject,
                NetInsurancePremium = todo.NetInsurancePremium,
                InsertTime = todo.InsertTime,
                IsRemoved = todo.IsRemoved,
                ReqDetails = todo.ReqDetails,
            };
        }
        public InsuranceTypeDto check(int Id)
        {
            var insuranceType = _context.InsuranceTypes.SingleOrDefault(p => p.InsuranceTypeId == Id);
            return new InsuranceTypeDto()
            {
                Id = insuranceType.InsuranceTypeId,
                InsuranceRate = insuranceType.InsuranceRate,
                MaxInsuranceCoverage = insuranceType.MaxInsuranceCoverage,
                MinInsuranceCoverage = insuranceType.MinInsuranceCoverage

            };
        }
        public ToDoDto Add(ToDoDto todo)
        {
            double sumInsuranceCo = 0;
            ToDo newToDo = new ToDo()
            {
                RequestSubject = todo.RequestSubject,
                // NetInsurancePremium = todo.NetInsurancePremium,            
                InsertTime = DateTime.Now,
                IsRemoved = false,
                ReqDetails = new List<ReqDetails>()


            };
            ;
            foreach (var reqDetailsModel in todo.ReqDetails)
            {
                var reqDetails = new ReqDetails
                {

                    Id = reqDetailsModel.Id,
                    InsuranceTypeId = reqDetailsModel.InsuranceTypeId,
                    RequestInsuranceCoverage = reqDetailsModel.RequestInsuranceCoverage,
                    NetInsurancePremiumItem = Convert.ToDouble(reqDetailsModel.RequestInsuranceCoverage) * _context.InsuranceTypes.Where(j => j.InsuranceTypeId == reqDetailsModel.InsuranceTypeId).Select(z => z.InsuranceRate).FirstOrDefault(),

                };
                sumInsuranceCo += reqDetails.NetInsurancePremiumItem;
                newToDo.ReqDetails.Add(reqDetails);
            }

            newToDo.NetInsurancePremium = sumInsuranceCo;
            _context.ToDos.Add(newToDo);
            _context.SaveChanges();

            return new ToDoDto
            {

                ToDoId = newToDo.ToDoId,
                NetInsurancePremium = newToDo.NetInsurancePremium,
                RequestSubject = newToDo.RequestSubject,
                InsertTime = newToDo.InsertTime,
                IsRemoved = newToDo.IsRemoved,
                ReqDetails = new List<ReqDetails>()

            };
        }

    }
    public class ToDoDto
    {
        public int ToDoId { get; set; }
        public string RequestSubject { get; set; } //عنوان

        public double NetInsurancePremium { get; set; } //حق بیمه خالص
        public DateTime InsertTime { get; set; }
        public bool IsRemoved { get; set; }
        public List<ReqDetails> ReqDetails { get; set; }

    }
    public class ReqDetailsDto
    {
        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }
        public int InsuranceTypeId { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public int RequestInsuranceCoverage { get; set; } //پوشش درخواستی کاربر
        public double NetInsurancePremiumItem { get; set; } //حق بیمه خالص
    }

    public class InsuranceTypeDto
    {
        public int Id { get; set; }

        public int MinInsuranceCoverage { get; set; }
        public int MaxInsuranceCoverage { get; set; }
        public double InsuranceRate { get; set; }

    }
}
