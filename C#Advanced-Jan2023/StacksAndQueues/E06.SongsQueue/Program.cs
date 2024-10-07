namespace E06.SongsQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            //read initial songs and add them in a queue
            string[] songs = Console.ReadLine()
                .Split(", ");

            Queue<string> playlist = new Queue<string>(songs);

            //execute playlist, while there are still songs in the queue
            while (playlist.Count != 0)
            {
                //read the command
                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    //get the name of the song to add in the playlist
                    StringBuilder newSong = new StringBuilder();

                    for (int i = 1; i < command.Length - 1; i++)
                    {
                        newSong.Append(command[i]);
                        newSong.Append(" ");                       
                    }

                    //add the last word without space  after it
                    newSong.Append(command[command.Length - 1]);

                    string songName = newSong.ToString();

                    //check if the song is in the queue, if not add it
                    bool exists = false;

                    foreach (var song in playlist)
                    {
                        if (songName == song)
                        {
                            Console.WriteLine($"{songName} is already contained!");
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        playlist.Enqueue(songName);
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
