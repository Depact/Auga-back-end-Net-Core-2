﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackSide2.BL.authorize;
using BackSide2.BL.Entity;
using BackSide2.BL.ParsePageService;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackSide2.Controllers
{
    //"launchUrl": "https://localhost:44300/api/values/?adress=http://artmangroup.ru/uroki-videoproizvodstva/osnovy-fizicheskogo-rendera.html",
    //"launchUrl": "https://localhost:44300/parse?adress=http://artmangroup.ru/uroki-videoproizvodstva/osnovy-fizicheskogo-rendera.html",
    [Route("parse")]
    [ApiController]
    public class ParseController : ControllerBase
    {
        private readonly IParsePageService _parsePageService;

        public ParseController(IParsePageService parsePageService
        )
        {
            _parsePageService = parsePageService;
        }

        [HttpGet]
        public string Get()
        {
            string messageToVisitor = "You are not logged.";
            if (User.Identity.IsAuthenticated)
            {
                messageToVisitor = $"Hello, {User.Claims.First().Value}.";
            }

            return DateTime.Now + "\n" + messageToVisitor;
        }


        [HttpPost]
        public async Task<IActionResult> ParsePage(
            ParsePageDto model
        )
        {
            try
            {
                var resopnsePlayload = await _parsePageService.ParsePageAsync(model);
                return Ok(resopnsePlayload);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}