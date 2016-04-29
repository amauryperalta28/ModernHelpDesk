using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRestClient.Http;
using SimpleRestClient.Json;
using ModernHelpDesk.Common.Models;
using System.Collections.Generic;

namespace ModernHelpDesk.Test
{
    [TestClass]
    public class ServiceMethod
    {
        string UrlBase = @"http://localhost:17640/api/";   

        [TestMethod]
        public void GetAllDivisionService()
        {
            var client = new SimpleRest(UrlBase);
            var departamentos = client.Invoke<List<Departamentos>>(string.Format("/Utils/GetAllDivisiones"), HttpMethod.GET);

            bool actual = false;

            if (departamentos != null)
            {
                actual = departamentos.Count > 0;
            }

            
            bool expected = true;

            Assert.AreEqual(expected, actual);
            
        }
    }
}
