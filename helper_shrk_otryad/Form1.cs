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

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("����!\n" +
                "��� ��������� ��� �������� ������������ ������� ���, � ������ ������ '������'. ��� ��� ������!\n" +
                "\n" +
                "1. ��� ������ �������� ������ ����� (�� ��������� ������ ������!).\n" +
                "2. ��������� �� ������ '������� ����' � ��������� ���� ������� *.txt.\n" +
                "� ���� ����� �� �������������� ��������� ��� ������ ������, � ������ ������� �������, ������, ������, �������� ������� � ����. " +
                "��� �� ������� �����, ��������.\n" +
                "3. ����� ����� ������ '������ �������'. ��������� ���������� ���� ������ � ������� ������ ���, ��� �������, ������� " +
                "� ������, ��� ��������� ��� ���������. ����� �������� � ����������� ������ �����.\n" +
                "\n" +
                "� ����� ���� ��������� �������, �������� �������, ������. � ������ - ������, ����.\n" +
                "\n" +
                "����������� ��������� �������, �� �������� �� ���������� ������ ��������� ������, ������ ��� ��������� �� ������ �� ������!\n" +
                "\n" +
                "���� ������ ������� ��������� ��� ������� ����, ���������� � ���� ���-�� [1532143].\n",
                "�������! ������ �� �����!");
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "���������� ������ ��������� ��� ���-�� [1532143].\n" +
                "��� �������� ���� ����������� ���������� ChatGPT.\n" +
                "\n" +
                "������ 1.0",
                "� ���������! ���� � ������!");
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
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

            // ������������� ������ ��� ����� ������
            openFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";

            // ���������� ������ �������� ����� � ������� ����������
            DialogResult result = openFileDialog.ShowDialog();

            // ���������, ��� �� ���� ������ � ������ ������ "��"
            if (result == DialogResult.OK)
            {
                // �������� ������ ���� � ���������� �����
                filePath = openFileDialog.FileName;

                // ������� ������ ���� � ����� (�������)
                //MessageBox.Show("��������� ����: " + filePath);

                toolStripStatusLabelFilePath.Text = filePath;
            }
        }

        private void buttonPodchet_Click(object sender, EventArgs e)
        {
            // �������� �� ����� �����
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
            // ���� �� ��� ������ ����
            else if (filePath == null)
            {
                MessageBox.Show("�����, �� �� ������ ����!", "300 ������ ��� � ���!");
            }
            // ���� ���� �����-�� ����� ������� ��� �����������
            else
            {
                MessageBox.Show("�����, �� ���� ��� ���� � ��������? ����� ��� �� �����!", "������� ���� ����!");
            }
        }

        public bool ProverkaNaOtryad(string[] reportLines, bool dolphin, bool flyingfish, bool whale, string line)
        {
            bool continuePodchet;
            if (line.StartsWith("���������") && (dolphin == false))
            {
                continuePodchet = false;
            }
            else if ((line.StartsWith("���� ���������� ��������� ������") || line.StartsWith("���� ���������� ���")) && (flyingfish == false))
            {
                continuePodchet = false;
            }
            else if ((line.StartsWith("����� � ���������� ������") || line.StartsWith("����� � ������������ �������") ||
                line.StartsWith("����� � ���������� ������/������������ �������")) && (whale == false))
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
                    if (line.StartsWith("���������:"))
                    {
                        Match collectorMatch = Regex.Match(line, @"\[(\d+)\]");
                        if (collectorMatch.Success)
                        {
                            string collectorId = collectorMatch.Groups[1].Value;
                            navigators.TryGetValue(collectorId, out int count);
                            navigators[collectorId] = count + 1;
                        }
                    }
                    else if ((line.StartsWith("���������:") || line.StartsWith("��������(�):") || line.StartsWith("��������:")))
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
                    MessageBox.Show("�����, � ���� ��������� ���� ������ �� ������� ������!", "��������� �����!");
                    break;
                }
            }

            // ����� �����������
            textBox1.Text += "����� ��������� - ������� �������\r\n";
            foreach (KeyValuePair<string, int> entry in navigators)
            {
                textBox1.Text += $"����������� {entry.Key} {entry.Value}\r\n";
            }

            foreach (KeyValuePair<string, int> entry in participants)
            {
                textBox1.Text += $"���������� {entry.Key} {entry.Value}\r\n";
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
                    if (line.StartsWith("����� � ���������� ��������� �������:"))
                    {
                        isPatrolReport = true;
                        isGameReport = false;
                    }
                    else if (line.StartsWith("����� � ���������� ���:"))
                    {
                        isPatrolReport = false;
                        isGameReport = true;
                    }

                    if (isPatrolReport)
                    {
                        if (line.StartsWith("����������:"))
                        {
                            Match patrolCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (patrolCollectorMatch.Success)
                            {
                                string patrolCollectorId = patrolCollectorMatch.Groups[1].Value;
                                patrolCollectors.TryGetValue(patrolCollectorId, out int count);
                                patrolCollectors[patrolCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("�������") || line.StartsWith("�������") || line.StartsWith("�������(��)"))
                        {
                            MatchCollection patrolCollectorMatches = Regex.Matches(line, @"\[(\d+)\]");
                            foreach (Match match in patrolCollectorMatches)
                            {
                                string patrolCollectorId = match.Groups[1].Value;
                                patrolLeaders.TryGetValue(patrolCollectorId, out int count);
                                patrolLeaders[patrolCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("���������:"))
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

                                patrolParticipants[participantId].TryGetValue("�������", out int count);
                                patrolParticipants[participantId]["�������"] = count + 1;
                            }
                        }
                    }
                    else if (isGameReport)
                    {
                        if (line.StartsWith("�������:"))
                        {
                            Match gameCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (gameCollectorMatch.Success)
                            {
                                string gameCollectorId = gameCollectorMatch.Groups[1].Value;
                                gameCollectors.TryGetValue(gameCollectorId, out int count);
                                gameCollectors[gameCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("���������:"))
                        {
                            Match gameCoHostMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (gameCoHostMatch.Success)
                            {
                                string gameCoHostId = gameCoHostMatch.Groups[1].Value;
                                gameCollectors.TryGetValue(gameCoHostId, out int count);
                                gameCollectors[gameCoHostId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("���������:"))
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

                                gameParticipants[participantId].TryGetValue("�������", out int count);
                                gameParticipants[participantId]["�������"] = count + participantCount;
                            }
                        }
                    }
                }
                //else if (!ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line)) ;
                //{
                //    MessageBox.Show("�����, � ���� ��������� ���� ������ �� ������� ������!", "��������� �����!");
                //    break;
                //}

            }

            // ����� �����������
            textBox1.Text += "�������� �������\r\n";

            foreach (KeyValuePair<string, int> patrolCollector in patrolCollectors)
            {
                textBox1.Text += $"������� [{patrolCollector.Key}] {patrolCollector.Value}\r\n";
            }

            foreach (KeyValuePair<string, int> patrolLeader in patrolLeaders)
            {
                textBox1.Text += $"��� {patrolLeader.Key} {patrolLeader.Value}\r\n";
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> participant in patrolParticipants)
            {
                textBox1.Text += $"���������� {participant.Key} ";
                foreach (KeyValuePair<string, int> count in participant.Value)
                {
                    textBox1.Text += $"{count.Value}\r\n";
                }
            }

            textBox2.Text += "����\r\n";
            foreach (KeyValuePair<string, int> gameCollector in gameCollectors)
            {
                textBox2.Text += $"��� [{gameCollector.Key}] {gameCollector.Value}\r\n";
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
                    if (line.StartsWith("����� � ���������� ������:"))
                    {
                        isLectureReport = true;
                        isTaleReport = false;
                    }
                    else if (line.StartsWith("����� � ������������ �������:"))
                    {
                        isLectureReport = false;
                        isTaleReport = true;
                    }

                    if (isLectureReport)
                    {
                        if (line.StartsWith("�������:"))
                        {
                            Match lectureCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (lectureCollectorMatch.Success)
                            {
                                string lectureCollectorId = lectureCollectorMatch.Groups[1].Value;
                                lectureCollectors.TryGetValue(lectureCollectorId, out int count);
                                lectureCollectors[lectureCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("���������:"))
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
                                    lectureParticipants[participantId]["������"] = 0;
                                    lectureParticipants[participantId]["�������������� �������"] = 0;
                                }

                                lectureParticipants[participantId]["������"]++;

                                if (participantCount == 35)
                                {
                                    lectureParticipants[participantId]["�������������� �������"] += 15;
                                }

                            }
                        }
                    }
                    else if (isTaleReport)
                    {
                        if (line.StartsWith("�������:"))
                        {
                            Match taleCollectorMatch = Regex.Match(line, @"\[(\d+)\]");
                            if (taleCollectorMatch.Success)
                            {
                                string taleCollectorId = taleCollectorMatch.Groups[1].Value;
                                taleCollectors.TryGetValue(taleCollectorId, out int count);
                                taleCollectors[taleCollectorId] = count + 1;
                            }
                        }
                        else if (line.StartsWith("���������:"))
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

                                lectureParticipants[participantId]["������"] += participantCount;

                                taleParticipants[participantId].TryGetValue("�������", out int count);
                                taleParticipants[participantId]["�������"] = count + participantCount;
                            }
                        }
                    }
                }
                //else if (!ProverkaNaOtryad(reportLines, radioButtonDolphin.Checked, radioButtonFlyingfish.Checked, radioButtonWhale.Checked, line)) ;
                //{
                //    MessageBox.Show("�����, � ���� ��������� ���� ������ �� ������� ������!", "��������� �����!");
                //    break;
                //}
            }

            // ����� ����������� ������
            textBox1.Text += "����� ����� - ������\r\n";
            foreach (KeyValuePair<string, int> entry in lectureCollectors)
            {
                textBox1.Text += $"�������� {entry.Key} {entry.Value}\r\n";
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> entry in lectureParticipants)
            {
                textBox1.Text += $"{entry.Key} {entry.Value["������"]} {entry.Value["�������������� �������"]}\r\n";
            }


            // ����� ����������� ������
            textBox2.Text += "����� ����� - ������\r\n";
            foreach (KeyValuePair<string, int> entry in taleCollectors)
            {
                textBox2.Text += $"�������� {entry.Key} {entry.Value}\r\n";
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