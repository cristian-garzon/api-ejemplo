using Gatitos.Context;
using Gatitos.Models;

namespace Gatitos.Repository;

public class AlbumRepository : IAlbumRepository
{
    
    private readonly IGatitoContext _gatitoContext;
    public AlbumRepository(IGatitoContext gatitoContext)
    {
        _gatitoContext = gatitoContext;
    }
    
    public Album UpdateAlbum(Album album)
    {
        Album albumUpdate = _gatitoContext.Albums.Update(album).Entity;
        _gatitoContext.SaveChanges();
        return albumUpdate;
    }

    public void DeleteAlbum(int id)
    {
        Album album = FindAlbum(id);
        _gatitoContext.Albums.Remove(album);
        _gatitoContext.SaveChanges();
    }

    public Album FindAlbum(int id)
    {
        Album album = _gatitoContext.Albums.Find(id);
        album.Galerias = _gatitoContext.Galerias.Select(m => m).ToList();
        return album;
    }

    public List<Album> ListAlbum()
    {
        List<Album> albums = _gatitoContext.Albums.Select(m => m).ToList();
        foreach (var album in albums)
        {
            album.Galerias = _gatitoContext.Galerias.Select(g => g).Where(g => g.AlbumId == album.AlbumId).ToList();
        }

        return albums;
    }
    
}