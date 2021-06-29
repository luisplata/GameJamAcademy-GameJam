public interface IMusic
{
    void StartMusic(string music);
    void Stop();
    void StartMusicForLayers(int totalLayers);
    void MusicForLayers(int totalLayers);
    void StopMusicForLayers();
}