using System;

namespace MusicArray
{
    class Program
    {
        enum MusicGenre
        {
            Rock,
            Pop,
            HipHop,
            Jazz,
            Electronic
        }

        struct Music
        {
            private string Title;
            private string Artist;
            private string Album;
            private TimeSpan Length;
            private MusicGenre Genre;

            public void SetTitle(string title)
            {
                Title = title;
            }

            public void SetArtist(string artist)
            {
                Artist = artist;
            }

            public void SetAlbum(string album)
            {
                Album = album;
            }

            public void SetLength(TimeSpan length)
            {
                Length = length;
            }

            public void SetGenre(MusicGenre genre)
            {
                Genre = genre;
            }

            public string Display()
            {
                return $"Title: {Title}\nArtist: {Artist}\nAlbum: {Album}\nLength: {Length}\nGenre: {Genre}";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many songs would you like to enter?");
            int size;
            try
            {
                size = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Music[] collection = new Music[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"\nEnter information for song {i + 1}:");
                    collection[i] = new Music();

                    Console.Write("Title: ");
                    collection[i].SetTitle(Console.ReadLine());

                    Console.Write("Artist: ");
                    collection[i].SetArtist(Console.ReadLine());

                    Console.Write("Album: ");
                    collection[i].SetAlbum(Console.ReadLine());

                    Console.Write("Length (in format hh:mm:ss): ");
                    string lengthInput = Console.ReadLine();
                    collection[i].SetLength(TimeSpan.Parse(lengthInput));

                    Console.WriteLine("Select Genre:");
                    Console.WriteLine("R - Rock\nP - Pop\nH - HipHop\nJ - Jazz\nE - Electronic");
                    char g = char.Parse(Console.ReadLine());
                    switch (g)
                    {
                        case 'R':
                            collection[i].SetGenre(MusicGenre.Rock);
                            break;
                        case 'P':
                            collection[i].SetGenre(MusicGenre.Pop);
                            break;
                        case 'H':
                            collection[i].SetGenre(MusicGenre.HipHop);
                            break;
                        case 'J':
                            collection[i].SetGenre(MusicGenre.Jazz);
                            break;
                        case 'E':
                            collection[i].SetGenre(MusicGenre.Electronic);
                            break;
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\nMusic Collection:");
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"{collection[i].Display()}");
                }
            }
        }
    }
}
