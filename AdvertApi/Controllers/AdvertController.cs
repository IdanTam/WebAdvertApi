﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.Models;
using AdvertApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvertApi.Controllers
{
    [ApiController]
    [Route("api/v1/adverts")]    
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertStorageService _advertStorageService;

        public AdvertController(IAdvertStorageService advertStorageService)
        {
            _advertStorageService = advertStorageService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(404)]
        [ProducesResponseType(201, Type = typeof(CreateAdvertResponse))]
        public async Task<IActionResult> Create(AdvertModel model)
        {
            string recordId;
            try
            {
                recordId = await _advertStorageService.Add(model);
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();             
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }

            return StatusCode(201, new CreateAdvertResponse { Id = recordId });
        }


        [HttpPut]
        [Route("Confirm")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Confirm(ConfirmAdvertModel model)
        {           
            try
            {
                await _advertStorageService.Confirm(model);
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
            catch (Exception exp)
            {
                return StatusCode(500, exp.Message);
            }

            return Ok();
        }

    }
}