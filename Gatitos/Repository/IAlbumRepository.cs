using Gatitos.Models;

namespace Gatitos.Repository;

public interface IAlbumRepository
{
    public Album? UpdateAlbum(Album album);
    public void DeleteAlbum(int id);
    public Album FindAlbum(int id);
    public List<Album> ListAlbum();
}