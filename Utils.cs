using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MP3Player
{
    internal class Utils
    {
        //Cria uma variavel para indicar a pasta de musicas no ambiente//
        public static string DiretorioMusicasWin = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
    }
}
