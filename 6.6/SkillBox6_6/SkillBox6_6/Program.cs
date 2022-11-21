using System;
using System.IO;
using System.Text;

namespace SkillBox6_6
{
    class Program
    {
        static StringBuilder employeesInfoText;
        static StringBuilder employeesInfoTextToOutput;
        static string currentEmployeesInfoText;
        static string employeesInfoPath;

        static void Main(string[] args)
        {
            string thisProgramName = "Program.cs";
            string thisProgramPath = Path.GetFullPath(thisProgramName);

            employeesInfoPath = (thisProgramPath.Remove(thisProgramPath.LastIndexOf(@"\")) + @"\EmployeesInfo.txt");
            
            if (!File.Exists(employeesInfoPath))
            {
                File.Create(employeesInfoPath);
            }

            ChoiceOfActions();
        }

        /// <summary>
        /// Выбирает действия в зависимости от ввода
        /// </summary>
        static void ChoiceOfActions()
        {
            Console.WriteLine("Для вывода всей информации о сотрудниках на экран введите: 1." +
                              "\nДля заполнения и сохранения данных нового сотрудника введите: 2.");
            string inputValue = Console.ReadLine();
            if (inputValue == "1")
            {
                ReadEmployeesInfoText();
                GetEmployeesInfoTextToOutput();
                if (employeesInfoTextToOutput.Length == 0)
                {
                    Console.WriteLine("Файл пуст");
                }
                else
                {
                    Console.WriteLine(employeesInfoTextToOutput);
                }
                WaitThenContinue();
            }
            else if (inputValue == "2")
            {
                EmployeesInfoDataInput();
                WaitThenContinue();
            }
            else
            {
                Console.WriteLine("Введены неверные данные, повторите ввод.");
                WaitThenContinue();
            }
        }

        /// <summary>
        /// Считывает файл, хранящий информацию о сотрудниках
        /// </summary>
        static void ReadEmployeesInfoText()
        {
            employeesInfoText = new StringBuilder(File.ReadAllText(employeesInfoPath));
        }

        /// <summary>
        /// Преобрезует считанный текст из файла, хранящего информацию о сотрудниках, для вывода на экран (удаляет все "#")
        /// </summary>
        static void GetEmployeesInfoTextToOutput()
        {
            employeesInfoTextToOutput = employeesInfoText;
            employeesInfoTextToOutput.Replace($"#", " ");
        }

        /// <summary>
        /// Выбирает действия перед вводом данных с клавиатуры
        /// </summary>
        static void EmployeesInfoDataInput()
        {
            ReadEmployeesInfoText();
            if (employeesInfoText.Length == 0)
            {
                currentEmployeesInfoText = "1#" + DateTime.Now.ToString();
                DataInput();
            }
            else
            {
                string[] linesCount = File.ReadAllLines(employeesInfoPath);
                currentEmployeesInfoText = (linesCount.Length + 1).ToString() + "#" + DateTime.Now.ToString();
                DataInput();
            }
        }

        /// <summary>
        /// Организует описание данных для ввода, общий ввод данных с клавиатуры, запись данных в файл
        /// </summary>
        static void DataInput()
        {
            currentEmployeesInfoText += DataInputHelper("Введите Ф.И.О:");
            currentEmployeesInfoText += DataInputHelper("Введите возраст:");
            currentEmployeesInfoText += DataInputHelper("Введите рост:");
            currentEmployeesInfoText += DataInputHelper("Введите дату рождения:");
            currentEmployeesInfoText += DataInputHelper("Введите место рождения:") + "\n";
            File.AppendAllText(employeesInfoPath, currentEmployeesInfoText);
        }

        /// <summary>
        /// Выводит на экран сообщение подсказки при вводе, и считывает введенную информацию о сотруднике
        /// </summary>
        /// <param name="message"> Сообщение-подсказка для ввода </param>
        /// <returns> Сначала символ "#", потом считанную информацию о сотруднике</returns>
        static string DataInputHelper(string message)
        {
            Console.WriteLine(message);
            string infoToRenurn = "#" + Console.ReadLine();
            return infoToRenurn;
        }

        /// <summary>
        /// Ждет нажатие любой клавиши, после чего запускает выбор действий
        /// </summary>
        static void WaitThenContinue()
        {
            Console.WriteLine("Для подолжения нажмите любую клавишу");
            Console.ReadKey();
            ChoiceOfActions();
        }
    }
}
