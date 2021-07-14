using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGameSaves
{
  public static class Cipher
  {
    public static string Decrypt(string text, byte key)
    {
      var data = Convert.FromBase64String(text);
      for (int i = 0; i < data.Length; i++)
      {
        data[i] = (byte)(data[i] ^ key);
      }
      return Encoding.UTF8.GetString(data);
    }

    public static string Encrypt(string text, byte key)
    {
      var data = Encoding.UTF8.GetBytes(text);
      for (int i = 0; i < data.Length; i++)
      {
        data[i] = (byte)(data[i] ^ key);
      }

      return Convert.ToBase64String(data);
    }
  }
}
