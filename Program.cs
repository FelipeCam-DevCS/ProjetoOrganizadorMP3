using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace MP3Player
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Organizador de musicas MP3");
            Console.WriteLine("O diretorio de musicas na sua maquina esta localizado em: " + Utils.DiretorioMusicasWin + "");

          AudioSelect();

                while(true)
                {
           int  EscolhaOutroAudio  = EscolhaNumerica(2,"Escolha 1 para escolher um audio e 2 para pause/play");
            if (EscolhaOutroAudio == 0)
                {
                    AudioSelect();
              }
                else
                {
                    if (reproduzirMP3.saidaSomdispositivo.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                    {
                        reproduzirMP3.saidaSomdispositivo.Pause();
                    }
                   else if (reproduzirMP3.saidaSomdispositivo.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                    {
                        reproduzirMP3.saidaSomdispositivo.Play();
                    }
                }
            }
                }
       
        
        static void AudioSelect()
        {
            reproduzirMP3.LimpaPlayer();
              var diretorios = new List<string>(Directory.GetDirectories(Utils.DiretorioMusicasWin));
              
              if (diretorios.Count == 0)
                {
                    Console.WriteLine("Não foi encontrado nenhum diretorio");
                }
                 else
                {
            for (int i = 0; i < diretorios.Count; i++)
            {
                Console.WriteLine(Convert.ToString(i + 1 + diretorios[i]));

            }
                int EscolhaDiretorio = EscolhaNumerica(diretorios.Count,"Escolha o diretorio");      
                var audios = new List<string> (Directory.GetFiles(diretorios[EscolhaDiretorio],"*.mp3"));

                
                if (audios.Count == 0)
                {
             Console.WriteLine("Nenhum audio encontrado");       
                }
                else
                {
                    
                for (int i = 0; i < audios.Count; i++)
                {                
            Console.WriteLine(Convert.ToString(i +1 + audios[i]));
                }

                }       
                int EscolhaAudio = EscolhaNumerica(audios.Count,"Escolha o audio");
                try
                {
                 reproduzirMP3.ReproduzirMP3(audios[EscolhaAudio]);
                    
                }
                catch
                {
                    Console.WriteLine("Ocorreu um erro ao reproduzir o audio ");
                }
                 
        }
        }
        public static int EscolhaNumerica(int NumMaxOp,string TextContexto) { 

            while(true) 
            {
                try  
                {
                    Console.WriteLine(TextContexto);
                    Console.WriteLine($"Escolha um numero entre 1 até {NumMaxOp}");
                    int EscNum = (Convert.ToInt32(Console.ReadLine()));
                    if (1 <= EscNum && NumMaxOp >= EscNum)
                    {
                    return (EscNum-1); 
                    }
                    else
                    {
                        Console.WriteLine("Escolha invalida");
                    }
                }
                catch
                {
                    Console.WriteLine("Escolha invalida");  
                }       
            }
        }   
    }
}