using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Prombox.Service.Utilities
{
    public class DiretorioService
    {

        public static string GetCaminhoCampanha()
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("StaticFiles", "Campanha"));

            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            return caminho;
        }
        public static string GetCaminhoCampanha(int campanhaId)
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("StaticFiles", "Campanha", campanhaId.ToString()));

            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            return caminho;
        }
        public static string GetCaminhoAvatar()
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("StaticFiles", "Avatar"));

            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            return caminho;
        }

        public static string GetCaminhoTemporario()
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("StaticFiles", "Temp"));

            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            return caminho;
        }


    }
}
