namespace MyFirstWebApi.Models.DTO
{
    public interface IToDataTransferObject<E>
    {
        E ToEntity();
    }
}
