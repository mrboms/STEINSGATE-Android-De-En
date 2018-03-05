using System;
using System.Collections.Generic;
using System.IO;

namespace EncryptDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Made By SKunio-VN--");
            string path = Environment.CurrentDirectory;
            string[] addFile = Environment.GetCommandLineArgs();
            Console.WriteLine(path);

            try
            {
                if (addFile.Length > 1)
                {
                    for (int f = 1; f < addFile.Length; f++)
                    {
                        byte[] bytes = File.ReadAllBytes(addFile[f]);

                        string Name = Path.GetFileNameWithoutExtension(addFile[f]);
                        string FullName = "";
                        Console.WriteLine("In : " + Path.GetFileName(addFile[f]));

                        Dictionary<string, string> libExt = new Dictionary<string, string>
                        {
                           { "SDT", ".sdt" },
                           { "SRC", ".src" },
                           { "PNG", ".png" },
                           { "MP4", ".mp4" }
                        };

                        if (bytes[0] == 71 && bytes[1] == 8)
                        {
                            FullName = Name + libExt["SRC"];
                            for (int i = 0; i < bytes.Length; i++)
                            {
                                bytes[i] ^= 100;
                            }
                            goto Next;
                        }
                        else if (bytes[0] == 237 && bytes[1] == 52)
                        {
                            FullName = Name + libExt["PNG"];
                        }
                        else if (bytes[0] == 100 && bytes[1] == 100)
                        {
                            FullName = Name + libExt["MP4"];
                        }
                        else
                        {
                            FullName = Name + libExt["SDT"];
                            if (Path.GetExtension(addFile[f]) == libExt["SRC"])
                            {
                                FullName = Name + libExt["SRC"];
                                for (int i = 0; i < bytes.Length; i++)
                                {
                                    bytes[i] ^= 100;
                                }
                                goto Next;
                            }
                        }

                        for (int i = 0; i < 100; i++)
                        {
                            bytes[i] ^= 100;
                        }

                    Next:
                        if (!Directory.Exists(path + "\\OutPut"))
                        {
                            Directory.CreateDirectory(path + "\\OutPut");
                        }
                        Console.WriteLine("Out : \\OutPut\\" + FullName);

                        File.WriteAllBytes(path + "\\OutPut\\" + FullName, bytes);
                    }
                    Console.WriteLine("Press one Key!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Press one Key!");
                    Console.WriteLine("File!");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Press one Key!");
                Console.WriteLine("Err!");
                Console.ReadKey();
            }
        }
    }
}
