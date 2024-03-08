using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace helper_shrk_otryad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(230, panel1.BackColor);
            panel2.BackColor = Color.FromArgb(230, panel1.BackColor);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ахой!\n" +
                "Это программа для подсчета деятельности отрядов ШРК, в данном случае 'рыбных'. Тут все просто!\n" +
                "\n" +
                "1. Для начала выберите нужный отряд (НЕ ЗАБЫВАЙТЕ МЕНЯТЬ ФЛАЖОК!).\n" +
                "2. Нажимаете на кнопку 'Выбрать файл' и выбираете файл формата *.txt.\n" +
                "В этом файле вы предварительно копируете все отчеты отряда, а именно морские вылазки, лекции, сказки, лагерные патрули и игры. " +
                "Что не указано здесь, убираете.\n" +
                "3. Далее жмете кнопку 'Начать подсчет'. Программа подсчитает ваши отчеты и выведет список тех, кто собирал, посещал " +
                "и прочее, что допустимо для обработки. Будет написано в специальном окошке сбоку.\n" +
                "\n" +
                "В левом окне выводятся вылазки, лагерные патрули, лекции. В правом - сказки, игры.\n" +
                "\n" +
                "Обязательно проверьте вручную, не упустили ли отписавшие отчеты некоторые данные, потому что программа не укажет на ошибки!\n" +
                "\n" +
                "Если формат отчетов изменится или найдете баги, обратитесь к Мику Ман-Ди [1532143].\n",
                "Справка! Встать на якорь!");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Разработал данную программу Мик Ман-Ди [1532143].\n" +
                "При создании кода пользовался нейросетью ChatGPT.\n" +
                "\n" +
                "Версия 1.0",
                "О программе! Гром и молния!");
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process process = new())
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = "https://github.com/BananaCat72/helper_shrk_otryad";
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string filePath;

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Устанавливаем фильтр для типов файлов
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            // Показываем диалог открытия файла и ожидаем результата
            DialogResult result = openFileDialog.ShowDialog();

            // Проверяем, был ли файл выбран и нажата кнопка "ОК"
            if (result == DialogResult.OK)
            {
                // Получаем полный путь к выбранному файлу
                filePath = openFileDialog.FileName;

                // Выводим полный путь к файлу (отладка)
                //MessageBox.Show("Выбранный файл: " + filePath);

                toolStripStatusLabelFilePath.Text = filePath;
            }
        }

        private void buttonPodchet_Click(object sender, EventArgs e)
        {
            // проверка на выбор файла
            if (filePath != null && File.Exists(filePath))
            {
                textBox1.Clear();
                textBox2.Clear();
                string[] reportLines = File.ReadAllLines(filePath);
                if (radioButtonDolphin.Checked)
                {
                    Dolphin(filePath, reportLines);
                }
                else
                if (radioButtonFlyingfish.Checked)
                {
                    Flyingfish(filePath, reportLines);
                }
                else
                if (radioButtonWhale.Checked)
                {
                    Whale(filePath, reportLines);
                }
            }
            // если не был выбран файл
            else if (filePath == null)
            {
                MessageBox.Show("Пират, ты не выбрал файл!", "300 якорей мне в зад!");
            }
            // если файл каким-то чудом удалили или переместили
            else
            {
                MessageBox.Show("Пират, ты куда дел файл с отчетами? Верни его на место!", "Разрази тебя гром!");
            }
        }

        public bool ProverkaNaOtryad(string[] reportLines, bool dolphin, bool flyingfish, bool whale, string line)
        {
            bool continuePodchet;
            if (line.StartsWith("Навигатор") && (dolphin == false))
            {
                continuePodchet = false;
            }
            else if ((line.StartsWith("Дата проведения лагерного дозора") || line.StartsWith("Дата проведения игр")) && (flyingfish == false))
            {
                continuePodchet = false;
            }
            else if ((line.StartsWith("Отчёт о проведённой лекции") || line.StartsWith("Отчёт о рассказанных сказках") ||
                line.StartsWith("Отчёт о проведённой лекции/рассказанных сказках")) && (whale == false))
            {
                continuePodchet = false;
            }
            else continuePodchet = true;
            return continuePodchet;
        }

        public void Dolphin(string filePath, string[] reportLines)
        {
            Dictionary<string, int> navigators = new Dictionary<string, int>();
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string navigatorId = string.Empty;

            foreach (string line in reportLines)
            {
                if (ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line))
                {
                    if (line.StartsWith("Навигатор:"))
                    {
                        Match collectorMatch = Regex.Match(line, @"\[(\d+)\]");
                        if (collectorMatch.Success)
                        {
                            string collectorId = collectorMatch.Groups[1].Value;
                            navigators.TryGetValue(collectorId, out int count);
                            navigators[collectorId] = count + 1;
                        }
                    }
                    else if ((line.StartsWith("Участники:") || line.StartsWith("Участник(и):") || line.StartsWith("Участник:")))
                    {
                        MatchCollection participantMatches = Regex.Matches(line, @"\[(\d+)\]");
                        foreach (Match match in participantMatches)
                        {
                            string participantId = match.Groups[1].Value;
                            if (participantId != navigatorId)
                            {
                                participants.TryGetValue(participantId, out int count);
                                participants[participantId] = count + 1;
                            }
                        }
                    }
                }
                else if (!ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line))
                {
                    MessageBox.Show("Пират, в этом документе есть отчеты из другого отряда!", "Кальмарьи кишки!");
                    break;
                }
            }

            // Вывод результатов
            textBox1.Text += "ОТРЯД ДЕЛЬФИНОВ - МОРСКИЕ ВЫЛАЗКИ\r\n";
            foreach (KeyValuePair<string, int> entry in navigators)
            {
                textBox1.Text += $"навигаторил {entry.Key} {entry.Value}\r\n";
            }

            foreach (KeyValuePair<string, int> entry in participants)
            {
                textBox1.Text += $"участвовал {entry.Key} {entry.Value}\r\n";
            }

        }

        public void Flyingfish(string filePath, string[] reportLines)
        {
            Dictionary<string, int> patrolCollectors = new Dictionary<string, int>();
            Dictionary<string, int> patrolLeaders = new Dictionary<string, int>();
            Dictionary<string, int> gameCollectors = new Dictionary<string, int>();
            Dictionary<string, int> gameCoHosts = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> patrolParticipants = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> gameParticipants = new Dictionary<string, Dictionary<string, int>>();

            bool isPatrolReport = false;
            bool isGameReport = false;

            foreach (string line in reportLines)
            {
                if (ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line))
                {
                    if (line.StartsWith("Отчёт о проведении лагерного патруля:"))
                    {
                        isPatrolReport = true;
                        isGameReport = false;
                    }
                    else if (line.StartsWith("Отчёт о проведении игр:"))
                    {
                        isPatrolReport = false;
                        isGameReport = true;
                    }

                    if (isPatrolReport)
                    {
                        if (line.StartsWith("Собирающий:"))
                        {
                            Match patrolCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (patrolCollectorMatch.Success)
                            {
                                string patrolCollectorId = patrolCollectorMatch.Groups[1].Value;
                                patrolCollectors.TryGetValue(patrolCollectorId, out int count);
                                patrolCollectors[patrolCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("Ведущий") || line.StartsWith("Ведущие") || line.StartsWith("Ведущий(ие)"))
                        {
                            MatchCollection patrolCollectorMatches = Regex.Matches(line, @"\[(\d+)\]");
                            foreach (Match match in patrolCollectorMatches)
                            {
                                string patrolCollectorId = match.Groups[1].Value;
                                patrolLeaders.TryGetValue(patrolCollectorId, out int count);
                                patrolLeaders[patrolCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("Участники:"))
                        {
                            MatchCollection participantMatches = Regex.Matches(line, @"(.+?)\s\[(\d+)\]");
                            foreach (Match match in participantMatches)
                            {
                                string participantName = match.Groups[1].Value;
                                string participantId = match.Groups[2].Value;

                                if (!patrolParticipants.ContainsKey(participantId))
                                {
                                    patrolParticipants[participantId] = new Dictionary<string, int>();
                                }

                                patrolParticipants[participantId].TryGetValue("монетки", out int count);
                                patrolParticipants[participantId]["монетки"] = count + 1;
                            }
                        }
                    }
                    else if (isGameReport)
                    {
                        if (line.StartsWith("Ведущий:"))
                        {
                            Match gameCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (gameCollectorMatch.Success)
                            {
                                string gameCollectorId = gameCollectorMatch.Groups[1].Value;
                                gameCollectors.TryGetValue(gameCollectorId, out int count);
                                gameCollectors[gameCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("Соведущий:"))
                        {
                            Match gameCoHostMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (gameCoHostMatch.Success)
                            {
                                string gameCoHostId = gameCoHostMatch.Groups[1].Value;
                                gameCollectors.TryGetValue(gameCoHostId, out int count);
                                gameCollectors[gameCoHostId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("Участники:"))
                        {
                            MatchCollection participantMatches = Regex.Matches(line, @"(.+?)\s\[(\d+)\]\s\(\+([\d\w\s]+)\)");
                            foreach (Match match in participantMatches)
                            {
                                string participantName = match.Groups[1].Value;
                                string participantId = match.Groups[2].Value;
                                string participantCountString = match.Groups[3].Value;

                                int participantCount = GetParticipantCount(participantCountString);

                                if (!gameParticipants.ContainsKey(participantId))
                                {
                                    gameParticipants[participantId] = new Dictionary<string, int>();
                                }

                                gameParticipants[participantId].TryGetValue("монеток", out int count);
                                gameParticipants[participantId]["монеток"] = count + participantCount;
                            }
                        }
                    }
                }
                //else if (!ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line)) ;
                //{
                //    MessageBox.Show("Пират, в этом документе есть отчеты из другого отряда!", "Кальмарьи кишки!");
                //    break;
                //}

            }

            // Вывод результатов
            textBox1.Text += "ЛАГЕРНЫЕ ПАТРУЛИ\r\n";

            foreach (KeyValuePair<string, int> patrolCollector in patrolCollectors)
            {
                textBox1.Text += $"Собирал [{patrolCollector.Key}] {patrolCollector.Value}\r\n";
            }

            foreach (KeyValuePair<string, int> patrolLeader in patrolLeaders)
            {
                textBox1.Text += $"Вел {patrolLeader.Key} {patrolLeader.Value}\r\n";
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> participant in patrolParticipants)
            {
                textBox1.Text += $"Участвовал {participant.Key} ";
                foreach (KeyValuePair<string, int> count in participant.Value)
                {
                    textBox1.Text += $"{count.Value}\r\n";
                }
            }

            textBox2.Text += "ИГРЫ\r\n";
            foreach (KeyValuePair<string, int> gameCollector in gameCollectors)
            {
                textBox2.Text += $"Вел [{gameCollector.Key}] {gameCollector.Value}\r\n";
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> participant in gameParticipants)
            {
                textBox2.Text += $"{participant.Key} ";
                foreach (KeyValuePair<string, int> count in participant.Value)
                {
                    textBox2.Text += $"{count.Value} {count.Key}\r\n";
                }
            }
        }


        public void Whale(string filePath, string[] reportLines)
        {
            Dictionary<string, int> lectureCollectors = new Dictionary<string, int>();
            Dictionary<string, int> taleCollectors = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> lectureParticipants = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> taleParticipants = new Dictionary<string, Dictionary<string, int>>();

            bool isLectureReport = false;
            bool isTaleReport = false;

            foreach (string line in reportLines)
            {
                if (ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line))
                {
                    if (line.StartsWith("Отчёт о проведённой лекции:"))
                    {
                        isLectureReport = true;
                        isTaleReport = false;
                    }
                    else if (line.StartsWith("Отчёт о рассказанных сказках:"))
                    {
                        isLectureReport = false;
                        isTaleReport = true;
                    }

                    if (isLectureReport)
                    {
                        if (line.StartsWith("Ведущий:"))
                        {
                            Match lectureCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (lectureCollectorMatch.Success)
                            {
                                string lectureCollectorId = lectureCollectorMatch.Groups[1].Value;
                                lectureCollectors.TryGetValue(lectureCollectorId, out int count);
                                lectureCollectors[lectureCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("Участники:"))
                        {
                            MatchCollection participantMatches = Regex.Matches(line, @"(.+?)\s\[(\d+)\]\s\(\+([\d\w\s]+)\)");
                            foreach (Match match in participantMatches)
                            {
                                string participantName = match.Groups[1].Value;
                                string participantId = match.Groups[2].Value;
                                string participantCountString = match.Groups[3].Value;

                                int participantCount = GetParticipantCount(participantCountString);

                                if (!lectureParticipants.ContainsKey(participantId))
                                {
                                    lectureParticipants[participantId] = new Dictionary<string, int>();
                                }

                                lectureParticipants[participantId].TryGetValue("монетки", out int count);
                                lectureParticipants[participantId]["монетки"] = count + participantCount;
                            }
                        }
                    }
                    else if (isTaleReport)
                    {
                        if (line.StartsWith("Ведущий:"))
                        {
                            Match taleCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (taleCollectorMatch.Success)
                            {
                                string taleCollectorId = taleCollectorMatch.Groups[1].Value;
                                taleCollectors.TryGetValue(taleCollectorId, out int count);
                                taleCollectors[taleCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("Участники:"))
                        {
                            MatchCollection participantMatches = Regex.Matches(line, @"(.+?)\s\[(\d+)\]\s\(\+([\d\w\s]+)\)");
                            foreach (Match match in participantMatches)
                            {
                                string participantName = match.Groups[1].Value;
                                string participantId = match.Groups[2].Value;
                                string participantCountString = match.Groups[3].Value;

                                int participantCount = GetParticipantCount(participantCountString);

                                if (!taleParticipants.ContainsKey(participantId))
                                {
                                    taleParticipants[participantId] = new Dictionary<string, int>();
                                }

                                taleParticipants[participantId].TryGetValue("монетки", out int count);
                                taleParticipants[participantId]["монетки"] = count + participantCount;
                            }
                        }
                    }
                }
                //else if (!ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line)) ;
                //{
                //    MessageBox.Show("Пират, в этом документе есть отчеты из другого отряда!", "Кальмарьи кишки!");
                //    break;
                //}
            }

            // Вывод результатов
            textBox1.Text += "ОТРЯД КИТОВ - ЛЕКЦИИ\r\n";
            foreach (KeyValuePair<string, int> entry in lectureCollectors)
            {
                textBox1.Text += $"проводил {entry.Key} {entry.Value}\r\n";
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> entry in lectureParticipants)
            {
                textBox1.Text += $"{entry.Key} ";
                foreach (KeyValuePair<string, int> countEntry in entry.Value)
                {
                    textBox1.Text += $"{countEntry.Value} {countEntry.Key}\r\n";
                }
            }

            textBox2.Text += "ОТРЯД КИТОВ - СКАЗКИ\r\n";
            foreach (KeyValuePair<string, int> entry in taleCollectors)
            {
                textBox2.Text += $"проводил {entry.Key} {entry.Value}\r\n";
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> entry in taleParticipants)
            {
                textBox2.Text += $"{entry.Key} ";
                foreach (KeyValuePair<string, int> countEntry in entry.Value)
                {
                    textBox2.Text += $"{countEntry.Value} {countEntry.Key}\r\n";
                }
            }






        }

        static int GetParticipantCount(string participantCountString)
        {
            int participantCount = 0;
            MatchCollection countMatches = Regex.Matches(participantCountString, @"\d+");
            foreach (Match match in countMatches)
            {
                participantCount += int.Parse(match.Value);
            }
            return participantCount;
        }

    }
}