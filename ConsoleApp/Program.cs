using Newtonsoft.Json.Schema;
using NJsonSchema.CodeGeneration.CSharp;

using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var bla = await NJsonSchema.JsonSchema.FromJsonAsync(File.ReadAllText("madfaerdSchema.json"));
            var generator = new CSharpGenerator(bla);
            var file = generator.GenerateFile();
            var types = generator.GenerateTypes();
            while (true)
            {
                //PuppeteerWrapper puppeteerWrapper = await PuppeteerWrapper.CreateAsync(new System.Collections.Generic.List<string>());
                //Console.WriteLine($"{puppeteerWrapper.browser.WebSocketEndpoint}");
                await Task.Delay(1000);
            }
            //await puppeteerWrapper.GetHtmlContentAsync(new Uri("http://www.hardkoded.com/"));
            //using (var browser = await PuppeteerSharp.Puppeteer.ConnectAsync(new PuppeteerSharp.ConnectOptions() { BrowserWSEndpoint = "ws://127.0.0.1:45565/devtools/browser/0926b693-f404-4396-b5e0-b133dac0daa9" }))
            //{
            //    using (var page = await browser.NewPageAsync())
            //    {
            //        await page.GoToAsync("https://www.arla.dk/");
            //    }
            //}
        }
    }
}

