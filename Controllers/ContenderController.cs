﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotingAdminService.Models;
using VotingAdminService.Repositories;

namespace VotingAdminService.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ContenderController : ControllerBase
    {
        public readonly IRepository<Contender> _contenderRepo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ContenderController));
        public ContenderController(IRepository<Contender> contenderRepo)
        {
            _contenderRepo = contenderRepo;
        }

        //GET: Contender
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                _log4net.Info("Getting all Contenders");
                var contenders = _contenderRepo.GetAll();
                if (contenders != null)
                {
                    return Ok(contenders);
                }
                return new NoContentResult();

            }
            catch
            {
                _log4net.Error("Error in Getting Contenders");
                return new NoContentResult();
            }
        }

        // GET: Contenders/5
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                _log4net.Info("Getting Contender by Id" + "(" + id.ToString() + ")");
                var contender = _contenderRepo.GetByID(id);
                if (contender != null)
                {
                    return new OkObjectResult(contender);
                }
                return new NoContentResult();
            }
            catch
            {
                _log4net.Error("Error in Getting Contender of Id " + id.ToString());
                return new NoContentResult();
            }
        }


        // POST: Contenders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Add")]
        public IActionResult Add(Contender contender)
        {
            try
            {
                _log4net.Info("Contender Details Getting Added - " + "ContenderID is " + (contender.ContenderID + 1).ToString());
                
                var added = _contenderRepo.Add(contender);
                if (added)
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch
            {
                _log4net.Error("Error in Adding Contender Details " + "ContenderID is " + (contender.ContenderID + 1).ToString());
                return new NoContentResult();
            }
        }


    }
}