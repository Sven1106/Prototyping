using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                DockerSetup dockerSetup = new DockerSetup();
                await dockerSetup.InitializeAsync();
                Console.ReadKey();
            }
        }
    }
    public class DockerSetup
    {
        private readonly DockerClient _dockerClient;
        public DockerSetup()
        {
            _dockerClient = new DockerClientConfiguration(DockerApiUri()).CreateClient();
        }

        public async Task InitializeAsync()
        {
            string containerImageUri = "shaddyd/puppeteersharp";
            await PullImage(containerImageUri);
            await StartContainer(containerImageUri);
        }

        private async Task StartContainer(string containerImageUri)
        {
            var response = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = containerImageUri
            });
            string _containerId = response.ID;

            await _dockerClient.Volumes.CreateAsync(new VolumesCreateParameters());
            await _dockerClient.Containers.StartContainerAsync(_containerId, new ContainerStartParameters());
        }

        private async Task PullImage(string imageUrl)
        {
            await _dockerClient.Images
                .CreateImageAsync(new ImagesCreateParameters
                {
                    FromImage = imageUrl,
                    Tag = "latest"
                },
                    new AuthConfig(),
                    new Progress<JSONMessage>());
        }

        private Uri DockerApiUri()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                return new Uri("npipe://./pipe/docker_engine");
            }

            var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            if (isLinux)
            {
                return new Uri("unix:/var/run/docker.sock");
            }

            throw new Exception(
                "Was unable to determine what OS this is running on, does not appear to be Windows or Linux!?");
        }
    }
}
