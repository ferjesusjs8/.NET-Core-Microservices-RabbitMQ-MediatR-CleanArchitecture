using MicroRabbit.Presentation.MVC.Models.DTO;
using System.Threading.Tasks;

namespace MicroRabbit.Presentation.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transferDTO);
    }
}
