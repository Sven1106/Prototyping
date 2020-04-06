using System;
using System.Threading.Tasks;
using ImageScalerLib;

namespace Prototyping
{
    class Program
    {
        public Program()
        {


        }
        static void Main(string[] args)
        {
            Program program = new Program();
            var bla = program.GetScaledImageAsync().Result;
            Console.WriteLine("Hello World!");
        }
        public async Task<string> GetScaledImageAsync()
        {
            ImageService imageService = new ImageService();
            imageService.DeleteAllImages();
           return await imageService.SetAndGetImageAsBase64Async("data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/2wCEAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDIBCQkJDAsMGA0NGDIhHCEyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMv/AABEIADIAMgMBIgACEQEDEQH/xAGiAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGBwgJCgsQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFBBhNRYQcicRQygZGhCCNCscEVUtHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6Onq8fLz9PX29/j5+gEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoLEQACAQIEBAMEBwUEBAABAncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APU6KKKACiiigAooooAKKKKACmmRQ+zPzdcYp1QyRM0gZfl6ZYMc4HbFAEiSJJnYwOKVmVF3McCoI4XRCG2HEYQDscZ60RwMluY2w5znJJGfr/ntQBL50YIBbBPQGn1WFvJ3YHO3JJ5GCT+PXFWaACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAP/Z", 100,50);
        }

    }
}
