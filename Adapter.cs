using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDesignPatterns
{
    internal class Adapter
    {
    }

    // IMediaPlayer — the client-facing interface (core player).
    interface IMediaPlayer
    {
        void Play(string fileName);
    }

    // Mp3Player — a basic media player (supports only mp3).
    internal class Mp3Player : IMediaPlayer
    {
        public void Play(string fileName)
        {
            Console.WriteLine($"Your mp3 file is {fileName} playing..");
        }
    }


    // IAdvancedMediaPlayer — for advanced formats like mp4.
    interface IAdvancedMediaPlayer
    {
        void PlayMp4(string fileName);
    }

    // Mp4Player — an implementation of IAdvancedMediaPlayer.
    internal class Mp4Player : IAdvancedMediaPlayer
    {
        public void PlayMp4(string fileName)
        {
            Console.WriteLine($"Your mp4 file is {fileName} playing..");
        }
    }

    // Core application (support mp3 and mp4 (new format) song format)
    internal class MediaPlayer : IMediaPlayer
    {
        private readonly IMediaPlayer _mediaPlayer;

        public MediaPlayer(MediaType mediaType,string fileName)
        {
            _mediaPlayer = mediaType switch
            {
                MediaType.Mp3 => new Mp3Player(),
                MediaType.Mp4 => new MediaAdapter(MediaType.Mp4),
                _ => throw new FormatException()
            };
        }
        public void Play(string fileName)
        {
            _mediaPlayer.Play(fileName);
        }
    }

    // Adapter between sample media and advance one
    internal class MediaAdapter : IMediaPlayer
    {
        private readonly IAdvancedMediaPlayer _advancedMediaPlayer;

        public MediaAdapter(MediaType mediaType)
        {
            if (mediaType == MediaType.Mp4)
            {
                _advancedMediaPlayer = new Mp4Player();
            }
            else
            {
                throw new FormatException();
            }
        }
        public void Play(string fileName)
        {
            _advancedMediaPlayer.PlayMp4(fileName);
        }
    }

    internal enum MediaType{Mp3,Mp4}


}
