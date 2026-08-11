using System;
using System.Collections.Generic;
using System.Text;

namespace GuardiaoCincoS.Servicos
{
    public static class UtilData
    {
        public static DateTime ObterSegundaFeira(DateTime data)
        {
            int diferenca = (7 + (data.DayOfWeek - DayOfWeek.Monday)) % 7;
            return data.AddDays(-diferenca).Date;
        }
    }
}
