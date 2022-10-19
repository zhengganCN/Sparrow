﻿using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult.Test
{
    internal class SerializeTest
    {
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult(option =>
            {
                option.FormatDto = (dto) =>
                {
                    return new DefinedDto
                    {
                        defined_code = dto.Code,
                        defined_message = dto.Message,
                        defined_data = dto.Data,
                        defined_success = dto.Success,
                        defined_time = dto.Time,
                        defined_traceid = dto.TraceId,
                    };
                };
            });
        }

        [Test]
        public void SerializeSuccessTest()
        {
            var data = "数据";
            var dto = new StandardDto();
            dto.SuccessResult(data);
            var json = JsonConvert.SerializeObject(new DefinedDto
            {
                defined_code = dto.Code,
                defined_message = dto.Message,
                defined_data = dto.Data,
                defined_success = dto.Success,
                defined_time = dto.Time,
                defined_traceid = dto.TraceId,
            });
            Assert.IsTrue(dto.Serialize() == json);
        }
    }
}