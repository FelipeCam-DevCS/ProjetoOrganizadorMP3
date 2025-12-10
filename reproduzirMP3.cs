using NAudio;
using NAudio.CoreAudioApi;
using NAudio.Wave;
namespace MP3Player;
internal class reproduzirMP3
{

        public static AudioFileReader audioFileReader;
        public  static WaveOutEvent saidaSomdispositivo;

   public static  void ReproduzirMP3(string LocalAudio)
    {
        saidaSomdispositivo = new WaveOutEvent();
       audioFileReader = new AudioFileReader(LocalAudio);
        saidaSomdispositivo.Init(audioFileReader);
        saidaSomdispositivo.Play(); 
        Console.WriteLine("Tocando: " + LocalAudio);
    }
public static void LimpaPlayer()
{
    if (saidaSomdispositivo != null)
    {
        saidaSomdispositivo.Stop();
    }
    if (saidaSomdispositivo != null)
    {
        audioFileReader.Dispose();
        audioFileReader = null;
    }
    if (saidaSomdispositivo != null)
    {
        saidaSomdispositivo.Dispose();
        saidaSomdispositivo = null;
    }
}
}