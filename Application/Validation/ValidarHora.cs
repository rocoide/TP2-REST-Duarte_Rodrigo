namespace Application.Validation
{
    public static class ValidarHora
    {
        public static bool validar(string Hora)
        {
            string[] Partes = Hora.Split(":");
            if (Partes.Length != 2)
            {
                return false;
            }
            int Horas;
            int Minutos;
            if (int.TryParse(Partes[0], out Horas) && int.TryParse(Partes[1], out Minutos))
            {
                if (Horas <= 0 && Horas >= 23 && Minutos <= 0 && Minutos >= 59)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
