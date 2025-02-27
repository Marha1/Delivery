using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Primitives
{
    public class Generate
    {
        public string GeneratePassport()
        {
            // Используем класс Random для генерации пароля
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray()); // Генерируем пароль длиной 8 символов
        }

        public string TransliterateToLatin(string input)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in input)
            {
                switch (c)
                {
                    case 'А': sb.Append('A'); break;
                    case 'Б': sb.Append('B'); break;
                    case 'В': sb.Append('V'); break;
                    case 'Г': sb.Append('G'); break;
                    case 'Д': sb.Append('D'); break;
                    case 'Е': sb.Append('E'); break;
                    case 'Ё': sb.Append('Y'); break;
                    case 'Ж': sb.Append('Z'); break;
                    case 'З': sb.Append('Z'); break;
                    case 'И': sb.Append('I'); break;
                    case 'Й': sb.Append('Y'); break;
                    case 'К': sb.Append('K'); break;
                    case 'Л': sb.Append('L'); break;
                    case 'М': sb.Append('M'); break;
                    case 'Н': sb.Append('N'); break;
                    case 'О': sb.Append('O'); break;
                    case 'П': sb.Append('P'); break;
                    case 'Р': sb.Append('R'); break;
                    case 'С': sb.Append('S'); break;
                    case 'Т': sb.Append('T'); break;
                    case 'У': sb.Append('U'); break;
                    case 'Ф': sb.Append('F'); break;
                    case 'Х': sb.Append('H'); break;
                    case 'Ц': sb.Append("TS"); break;
                    case 'Ч': sb.Append("CH"); break;
                    case 'Ш': sb.Append("SH"); break;
                    case 'Щ': sb.Append("SCH"); break;
                    case 'Ы': sb.Append('Y'); break;
                    case 'Э': sb.Append('E'); break;
                    case 'Ю': sb.Append("YU"); break;
                    case 'Я': sb.Append("YA"); break;
                    case 'а': sb.Append('a'); break;
                    case 'б': sb.Append('b'); break;
                    case 'в': sb.Append('v'); break;
                    case 'г': sb.Append('g'); break;
                    case 'д': sb.Append('d'); break;
                    case 'е': sb.Append('e'); break;
                    case 'ё': sb.Append("yo"); break;
                    case 'ж': sb.Append("zh"); break;
                    case 'з': sb.Append('z'); break;
                    case 'и': sb.Append('i'); break;
                    case 'й': sb.Append('y'); break;
                    case 'к': sb.Append('k'); break;
                    case 'л': sb.Append('l'); break;
                    case 'м': sb.Append('m'); break;
                    case 'н': sb.Append('n'); break;
                    case 'о': sb.Append('o'); break;
                    case 'п': sb.Append('p'); break;
                    case 'р': sb.Append('r'); break;
                    case 'с': sb.Append('s'); break;
                    case 'т': sb.Append('t'); break;
                    case 'у': sb.Append('u'); break;
                    case 'ф': sb.Append('f'); break;
                    case 'х': sb.Append("kh"); break;
                    case 'ц': sb.Append("ts"); break;
                    case 'ч': sb.Append("ch"); break;
                    case 'ш': sb.Append("sh"); break;
                    case 'щ': sb.Append("sch"); break;
                    case 'ы': sb.Append('y'); break;
                    case 'э': sb.Append('e'); break;
                    case 'ю': sb.Append("yu"); break;
                    case 'я': sb.Append("ya"); break;
                    default: sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
    }
}
