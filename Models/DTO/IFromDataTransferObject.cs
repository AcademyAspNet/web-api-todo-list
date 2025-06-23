namespace MyFirstWebApi.Models.DTO
{
    public interface IFromDataTransferObject<D>
    {
        D ToDataTransferObject();
    }
}
