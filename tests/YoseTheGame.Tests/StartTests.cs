using System;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using YoseTheGame.Start;

namespace YoseTheGame.Tests
{
    [TestFixture]
    public class StartTests
    {
        private const string YoseServerUrl = "http://127.0.0.1:8080";
        private TestContext _testContext;

        [SetUp]
        public void Setup()
        {
            _testContext = new TestContext();
        }

        [TearDown]
        public void TearDown()
        {
            _testContext.Dispose();
        }

        [Test]
        public async void Your_page_should_include_the_text_Hello_Yose()
        {
            const string expected = "Hello Yose";

            var response = 
                await _testContext.HttpClient.GetStringAsync(YoseServerUrl);

            response.Should().Contain(expected);
        }

        [Test]
        public async void Your_first_web_service_should_respond_with_the_alive_json_response()
        {
            var jsonSchema = JsonSchema.Parse("{'alive':true}");

            var response =
                await _testContext.HttpClient.GetStringAsync(YoseServerUrl + "/ping");

            var jsonAlive = JObject.Parse(response);

            jsonAlive.IsValid(jsonSchema).Should().BeTrue();
        }

        public class TestContext : IDisposable
        {
            private readonly IDisposable _app;

            public TestContext()
            {
                _app = WebApp.Start<Startup>(new StartOptions(YoseServerUrl));

                var httpClientHandler = new HttpClientHandler
                {
                    AllowAutoRedirect = false
                };

                HttpClient = new HttpClient(httpClientHandler);
            }

            public HttpClient HttpClient { get; set; }

            public void Dispose()
            {
                if (_app != null)
                {
                    _app.Dispose();
                }
            }
        }
    }
}
