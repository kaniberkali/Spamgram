using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;

namespace Spamgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Spamgram";
            Console.ForegroundColor = ConsoleColor.Green;
            basadon:
            Console.Clear();
            Console.WriteLine("Website: https://kodzamani.weebly.com");
            Console.WriteLine("Instagram: @kodzamani.tk");
            Console.WriteLine("-------------------------------------");
            string seçim = "2";
            if (File.Exists("Ayarlar.ini") == true && File.Exists("Profiller.ini") == true)
            {
                Console.WriteLine("{1} Programı Başlat");
                Console.WriteLine("{2} Ayarlar");
                Console.WriteLine("{3} Profiller");
                Console.Write("Seçim :");
                seçim = Console.ReadLine();
            }
            else if (File.Exists("Ayarlar.ini") == false)
                seçim = "2";
            else if (File.Exists("Profiller.ini") == false)
                seçim = "3";
            Console.Clear();
            if (seçim == "1")
            {
                List<string> profiller = new List<string>();
                int adet = 0;
                int beklemesüresi = 0;
                int degistirmesüresi = 0;
                Console.WriteLine("Website: https://kodzamani.weebly.com");
                Console.WriteLine("Instagram: @kodzamani.tk");
                if (File.Exists("Ayarlar.ini") == true && File.Exists("Profiller.ini") == true)
                {
                    Console.WriteLine("-------------Ayarlarınız-------------");
                    FileStream fs = new FileStream("Ayarlar.ini", FileMode.Open, FileAccess.Read);
                    StreamReader sw = new StreamReader(fs);
                    string yazi = sw.ReadLine();
                    while (yazi != null)
                    {
                        if (yazi.Contains("Adet") == true)
                            adet = Convert.ToInt32(yazi.Split(':')[1]);
                        if (yazi.Contains("Bekleme") == true)
                            beklemesüresi = Convert.ToInt32(yazi.Split(':')[1]);
                        if (yazi.Contains("Değiştirme") == true)
                            degistirmesüresi = Convert.ToInt32(yazi.Split(':')[1]);
                        Console.WriteLine(yazi);
                        yazi = sw.ReadLine();
                    }
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("------------Profilleriniz------------");
                    FileStream fs2 = new FileStream("Profiller.ini", FileMode.Open, FileAccess.Read);
                    StreamReader sw2 = new StreamReader(fs2);
                    string yazi2 = sw2.ReadLine();
                    while (yazi2 != null)
                    {
                        profiller.Add(yazi2);
                        Console.WriteLine(yazi2);
                        yazi2 = sw2.ReadLine();
                    }
                    sw2.Close();
                    fs2.Close();
                    Console.WriteLine("-------------------------------------");

                }
                else
                    goto basadon;
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                ChromeDriver Telegram = new ChromeDriver(service);
                Telegram.Navigate().GoToUrl("https://web.telegram.org/z/");
                Console.Write("Gönderilecek mesajınız :");
                string metin = Console.ReadLine();
                for (; ; )
                {
                    try
                    {
                        Telegram.FindElement(By.XPath("//div[@class='chat-list custom-scroll']")).Click();
                        break;
                    }
                    catch
                    {

                    }
                    Console.WriteLine("Hesabınıza giriş yapmanız bekleniyor.");
                    Thread.Sleep(2000);
                }
                Console.Clear();
                Console.WriteLine("Website: https://kodzamani.weebly.com");
                Console.WriteLine("Instagram: @kodzamani.tk");
                Console.WriteLine("-------------------------------------");
                for (; ; )
                {
                    for (int i = 0; i < profiller.Count; i++)
                    {
                        try
                        {
                            Thread.Sleep(200);
                            Telegram.Navigate().GoToUrl("data:,");
                            Telegram.Navigate().GoToUrl(profiller[i]);
                            Thread.Sleep(degistirmesüresi);
                            for (int a = 0; a < adet; a++)
                            {
                                try
                                {
                                    if (beklemesüresi <= 0)
                                        beklemesüresi = 1;
                                    Thread.Sleep(beklemesüresi);
                                    Telegram.FindElement(By.XPath("//div[@id='editable-message-text']")).SendKeys(metin);
                                    Thread.Sleep(200);
                                    Telegram.FindElement(By.XPath("//button[@class='Button send default secondary round']")).Click();
                                    Console.WriteLine(DateTime.Now + " > Mesaj başarıyla gönderildi.");
                                }
                                catch { Console.WriteLine(DateTime.Now + " > Mesaj gönderilemedi."); }
                            }
                        }
                        catch { Console.WriteLine(DateTime.Now + " > Profile girilemedi."); }
                    }

                }
            }
            else if (seçim == "2")
            {
                Console.WriteLine("Website: https://kodzamani.weebly.com");
                Console.WriteLine("Instagram: @kodzamani.tk");
                Console.WriteLine("-------------------------------------");
                string dosya_yolu = @"Ayarlar.ini";
                if (File.Exists("Ayarlar.ini") == true)
                {
                    Console.WriteLine("-------------Ayarlarınız-------------");
                    FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                    StreamReader sw = new StreamReader(fs);
                    string yazi = sw.ReadLine();
                    while (yazi != null)
                    {
                        Console.WriteLine(yazi);
                        yazi = sw.ReadLine();
                    }
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("-------------------------------------");
                }
                Console.Write("Mesaj Adet :");
                string adet = Console.ReadLine();
                Console.Write("Mesaj Bekleme Süresi (ms) :");
                string mesajbekleme = Console.ReadLine();
                Console.Write("Profil Değiştirme Süresi (ms) :");
                string profildeğiştirme = Console.ReadLine();

                FileStream fs2 = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
                StreamWriter sw2 = new StreamWriter(fs2);
                sw2.WriteLine("Mesaj Adet :" + adet);
                sw2.WriteLine("Mesaj Bekleme Süresi (ms) :" + mesajbekleme);
                sw2.WriteLine("Profil Değiştirme Süresi (ms) :" + profildeğiştirme);
                sw2.Flush();
                sw2.Close();
                fs2.Close();
                goto basadon;
            }
            else if (seçim == "3")
            {
                List<string> profiller = new List<string>();
                Console.WriteLine("Website: https://kodzamani.weebly.com");
                Console.WriteLine("Instagram: @kodzamani.tk");
                Console.WriteLine("-------------------------------------");
                string dosya_yolu = @"Profiller.ini";
                if (File.Exists("Profiller.ini") == true)
                {
                    Console.WriteLine("-------------Profilleriniz-------------");
                    FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                    StreamReader sw = new StreamReader(fs);
                    string yazi = sw.ReadLine();
                    while (yazi != null)
                    {
                        profiller.Add(yazi);
                        Console.WriteLine(yazi);
                        yazi = sw.ReadLine();
                    }
                    sw.Close();
                    fs.Close();
                    Console.WriteLine("----------------------------------------");
                }
                Console.Write("Eklemek istediğinzi profil adedi :");
                int profiladet = Convert.ToInt32(Console.ReadLine());
                for (int i=1;i<=profiladet;i++)
                {
                    Console.Write(i + ". Profil linki :");
                    string link = Console.ReadLine();
                    if (profiller.Contains(link)==false)
                    profiller.Add(link);
                }
                Console.WriteLine("Profiller başarıyla eklendi.");

                FileStream fs2 = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);
                StreamWriter sw2 = new StreamWriter(fs2);
                for (int i=0;i<profiller.Count;i++)
                    sw2.WriteLine(profiller[i]);
                sw2.Flush();
                sw2.Close();
                fs2.Close();

                goto basadon;
            }
            else
                goto basadon;
        }
    }
}
