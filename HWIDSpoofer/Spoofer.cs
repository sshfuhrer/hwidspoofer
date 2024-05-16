using System;
using System.Text;
using Microsoft.Win32;

namespace HWIDSpoofer
{
    class Spoofer
    {
        // Класс для подмены Hardware ID (HWID) в реестре
        public static class HWID
        {
            public static Regedit regeditOBJ = new Regedit(@"SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001");
            public static readonly string Key = "HwProfileGuid";

            // Получение текущего значения HWID из реестра
            public static string GetValue()
            {
                return regeditOBJ.Read(Key);
            }

            // Установка нового значения HWID в реестре
            public static bool SetValue(object value)
            {
                return regeditOBJ.Write(Key, value);
            }

            public static StringBuilder Log = new StringBuilder();

            // Метод для подмены HWID
            public static bool Spoof()
            {
                Log.Clear();
                string oldValue = GetValue();
                try
                {
                    bool result = SetValue("{" + Guid.NewGuid().ToString() + "}");
                    if (result)
                    {
                        Log.Append("  [SPOOFER] Изменен HWID с " + oldValue + " на " + GetValue());
                    }
                    else
                    {
                        Log.AppendLine("  [SPOOFER] Ошибка доступа к реестру... Возможно, запустите от имени администратора");
                    }
                    return result;
                }
                catch (UnauthorizedAccessException)
                {
                    Log.AppendLine("  [SPOOFER] Отказано в доступе к реестру. Убедитесь, что запущено от имени администратора.");
                    return false;
                }
            }
        }

        // Класс для подмены GUID в реестре
        public static class PCGuid
        {
            public static Regedit regeditOBJ = new Regedit(@"SOFTWARE\Microsoft\Cryptography");
            public static readonly string Key = "MachineGuid";

            // Получение текущего значения GUID из реестра
            public static string GetValue()
            {
                return regeditOBJ.Read(Key);
            }

            // Установка нового значения GUID в реестре
            public static bool SetValue(object value)
            {
                return regeditOBJ.Write(Key, value);
            }

            public static StringBuilder Log = new StringBuilder();

            // Метод для подмены GUID
            public static bool Spoof()
            {
                Log.Clear();
                string oldValue = GetValue();
                try
                {
                    bool result = SetValue(Guid.NewGuid().ToString());
                    if (result)
                    {
                        Log.Append("  [SPOOFER] Изменен GUID с " + oldValue + " на " + GetValue());
                    }
                    else
                    {
                        Log.AppendLine("  [SPOOFER] Ошибка доступа к реестру... Возможно, запустите от имени администратора");
                    }
                    return result;
                }
                catch (UnauthorizedAccessException)
                {
                    Log.AppendLine("  [SPOOFER] Отказано в доступе к реестру. Убедитесь, что запущено от имени администратора.");
                    return false;
                }
            }
        }

        // Класс для подмены имени компьютера в реестре
        public static class PCName
        {
            public static Regedit regeditOBJ = new Regedit(@"SYSTEM\CurrentControlSet\Control\ComputerName\ActiveComputerName");
            public static readonly string Key = "ComputerName";

            // Получение текущего значения имени компьютера из реестра
            public static string GetValue()
            {
                return regeditOBJ.Read(Key);
            }

            // Установка нового значения имени компьютера в реестре
            public static bool SetValue(object value)
            {
                return regeditOBJ.Write(Key, value);
            }

            public static StringBuilder Log = new StringBuilder();

            // Метод для подмены имени компьютера
            public static bool Spoof()
            {
                Log.Clear();
                string oldValue = GetValue();
                try
                {
                    bool result = SetValue("DESKTOP-" + Utilities.GenerateString(15));
                    if (result)
                    {
                        Log.Append("  [SPOOFER] Изменено имя компьютера с " + oldValue + " на " + GetValue());
                    }
                    else
                    {
                        Log.AppendLine("  [SPOOFER] Ошибка доступа к реестру... Возможно, запустите от имени администратора");
                    }
                    return result;
                }
                catch (UnauthorizedAccessException)
                {
                    Log.AppendLine("  [SPOOFER] Отказано в доступе к реестру. Убедитесь, что запущено от имени администратора.");
                    return false;
                }
            }
        }

        // Класс для подмены идентификатора продукта в реестре
        public static class ProductId
        {
            public static Regedit regeditOBJ = new Regedit(@"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
            public static readonly string Key = "ProductID";

            // Получение текущего значения идентификатора продукта из реестра
            public static string GetValue()
            {
                return regeditOBJ.Read(Key);
            }

            // Установка нового значения идентификатора продукта в реестре
            public static bool SetValue(object value)
            {
                return regeditOBJ.Write(Key, value);
            }

            public static StringBuilder Log = new StringBuilder();

            // Метод для подмены идентификатора продукта
            public static bool Spoof()
            {
                Log.Clear();
                string oldValue = GetValue();
                try
                {
                    bool result = SetValue(Utilities.GenerateString(5) + "-" + Utilities.GenerateString(5) + "-" + Utilities.GenerateString(5) + "-" + Utilities.GenerateString(5));
                    if (result)
                    {
                        Log.AppendLine("  [SPOOFER] Изменен идентификатор продукта с " + oldValue + " на " + GetValue());
                    }
                    else
                    {
                        Log.AppendLine("  [SPOOFER] Ошибка доступа к реестру... Возможно, запустите от имени администратора");
                    }
                    return result;
                }
                catch (UnauthorizedAccessException)
                {
                    Log.AppendLine("  [SPOOFER] Отказано в доступе к реестру. Убедитесь, что запущено от имени администратора.");
                    return false;
                }
            }
        }

        // Класс для работы с реестром
        public class Regedit
        {
            private string regeditPath = string.Empty;

            public Regedit(string regeditPath)
            {
                this.regeditPath = regeditPath;
            }

            // Метод для чтения значения из реестра
            public string Read(string keyName)
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regeditPath))
                    {
                        return key?.GetValue(keyName)?.ToString();
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка доступа к реестру: {ex.Message}");
                    return null;
                }
            }

            // Метод для записи значения в реестр
            public bool Write(string keyName, object value)
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regeditPath, true))
                    {
                        key?.SetValue(keyName, value);
                        return key != null;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка записи в реестр: {ex.Message}");
                    return false;
                }
            }
        }

        // Класс с утилитами
        public static class Utilities
        {
            private static Random rand = new Random();
            public const string Alphabet = "ABCDEF0123456789";

            // Генерация случайной строки заданной длины
            public static string GenerateString(int size)
            {
                char[] array = new char[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = Alphabet[rand.Next(Alphabet.Length)];
                }
                return new string(array);
            }
        }
    }
}
