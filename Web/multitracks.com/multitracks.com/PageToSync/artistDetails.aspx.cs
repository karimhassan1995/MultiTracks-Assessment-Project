using DataAccess;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls;


public partial class artistDetails : MultitracksPage
{

    MultiTracksDBEntities1 db = new MultiTracksDBEntities1();

    public List<Song> songs;
    public List<Album> albums;
    public Artist artist;
    protected void Page_Load(object sender, EventArgs e)
    {
        /* I used procedures here */
        var Artists = db.Artists.SqlQuery("GetArtistDetails").ToList();
        var Songs = db.Songs.SqlQuery("GetSongDetails").ToList();
        var Albums = db.Albums.SqlQuery("GetAlbumDetails").ToList();
        String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        string[] words = strPathAndQuery.Split('/');
        int id = 0;
        try
        {
            id = int.Parse(words[words.Length - 1]);
        }
        catch (Exception) { }
        Artist TheArtist = null;
        artist = TheArtist;

        List<Song> listOfSongs = new List<Song>();
        songs = listOfSongs;
        List<Album> listOfAlbums = new List<Album>();
        albums = listOfAlbums;



        for (int i = 0; i < Artists.Count(); i++)
        {

            if (Artists[i].artistID == id)
            {
                artist = Artists[i];
                for (int j = 0; j < Songs.Count(); j++)
                {
                    if (Songs[j].artistID == artist.artistID)
                    {
                        songs.Add(Songs[j]);
                    }
                }
                for (int r = 0; r < Albums.Count(); r++)
                {
                    if (Albums[r].artistID == artist.artistID)
                    {
                        albums.Add(Albums[r]);
                    }
                }
                break;
            }
        }

        /* I know that the idea of multi-nested for-loops is not a good practice but I have problem with
        with FirstOrDefault due to some nuget installation overlap happened when I tru to install some nuggets on the project
        so the code in the next line is not working :
         var artist = db.Artists.FirstOrDefault(a => a.artistID ==id);*/



        //Background hero image url
        Image1.ImageUrl = artist.heroURL;
        //Private umage url
        Image2.ImageUrl = artist.imageURL;
        //The name of the artist
        label1.Text = artist.title;
        label3.Text = artist.title;
        //The biography of the artist
        label2.Text = artist.biography;


    }


}