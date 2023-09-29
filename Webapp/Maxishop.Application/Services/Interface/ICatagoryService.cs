using Maxishop.Application.DTO.Catagory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.Services.Interface
{
    public interface ICatagoryService
    {

        Task<CatagoryDto> GetByIdAsync(int id);
        Task<IEnumerable<CatagoryDto>> GetAllAsync();

        Task<CatagoryDto> CreateAsync(CreateCatagoryDto createCatagoryDto);

        Task UpdateAsync(UpdateCatagoryDto updateCatagoryDto);

        Task DeleteAsync(int id);
    }
}
