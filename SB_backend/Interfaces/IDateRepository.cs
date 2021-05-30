using SB_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB_backend.Interfaces
{
    interface IDateRepository
    {
        List<Date> getDates();
        Date getDate(string Init_Date,string End_Date);

        Date AddDate(Date date);

        bool RemoveDate(Date date);

        Date UpdateDate(Date date);
    }
}
