using System;
using System.Linq;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Hosting;
using Nancy.Helpers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using YoseTheGame.Server;

namespace YoseTheGame.Tests
{
    [TestFixture]
    public class ServerTests
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
            var response =
                await _testContext.HttpClient.GetStringAsync(YoseServerUrl + "/ping");

            var data = JObject.Parse(response);

            data.Value<bool>("alive").Should().BeTrue();
        }

        [Test]
        public async void Your_server_receive_a_power_of_2_as_parameter_and_should_respond_a_JSON_containing_the_decomposition_of_this_number()
        {
            const int powerOfTwoNumber = 16;
            var uriBuilder = new UriBuilder(YoseServerUrl + "/primeFactors");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["number"] = powerOfTwoNumber.ToString();
            uriBuilder.Query = query.ToString();

            var response =
                await _testContext.HttpClient.GetStringAsync(uriBuilder.ToString());

            var data = JObject.Parse(response);

            data.Value<int>("number").Should().Be(powerOfTwoNumber);
            data.Value<JArray>("decomposition").Count.Should().Be(4);
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
