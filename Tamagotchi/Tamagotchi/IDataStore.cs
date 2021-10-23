using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    public interface IDataStore<T>
    {
        //CRUD opderation Create Read Update Delete
        Task<bool> CreateItem(T item);
        Task<T> ReadItem();
        Task<bool> UpdateItem(T item);
        Task<bool> DeleteItem(T item);

        Task<bool> GoToPlayground(T item);
        Task<bool> LeavePlayground(T item);

    }
}
