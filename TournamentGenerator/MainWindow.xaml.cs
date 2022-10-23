using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TournamentGenerator.Helper;
using TournamentGenerator.Models;

namespace TournamentGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Participant> participants = new List<Participant>();
        Dictionary<string, ListBox> poulesDictionary = new Dictionary<string, ListBox>();
        int _numberOfPoules = 0;

        public MainWindow()
        {
            InitializeComponent();
            GetData();
            SetComponents();
        }

        private void GetData()
        {
            participants = FileOperations.GetParticipants();
        }

        private void SetComponents()
        {
            lbParticipants.ItemsSource = participants;
        }

        private void btnGeneratePoules_Click(object sender, RoutedEventArgs e)
        {
            //First without animations
            int numberOfPoules = 0;
            if (int.TryParse(tbPoulesAmount.Text, out numberOfPoules))
            {
                if (numberOfPoules <= 12)
                {
                    _numberOfPoules = numberOfPoules;
                    Reset();
                    CreatePouleControls(numberOfPoules);
                    GeneratePoules(numberOfPoules);
                }
                else
                {
                    MessageBox.Show("You can only create a maximum of 12 poules!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number!");
            }
        }

        private void CreatePouleControls(int numberOfPoules)
        {
            for (int i = 1; i <= numberOfPoules; i++)
            {
                ListBox lb = new ListBox();
                lb.Width = 150;
                lb.Height = 300;
                lb.Name = $"lb{i}";


                switch (i)
                {
                    case 1:
                        poulesDictionary.Add("A", lb);
                        break;
                    case 2:
                        poulesDictionary.Add("B", lb);
                        break;
                    case 3:
                        poulesDictionary.Add("C", lb);
                        break;
                    case 4:
                        poulesDictionary.Add("D", lb);
                        break;
                    case 5:
                        poulesDictionary.Add("E", lb);
                        break;
                    case 6:
                        poulesDictionary.Add("F", lb);
                        break;
                    case 7:
                        poulesDictionary.Add("G", lb);
                        break;
                    case 8:
                        poulesDictionary.Add("H", lb);
                        break;
                    case 9:
                        poulesDictionary.Add("I", lb);
                        break;
                    case 10:
                        poulesDictionary.Add("J", lb);
                        break;
                    case 11:
                        poulesDictionary.Add("K", lb);
                        break;
                    case 12:
                        poulesDictionary.Add("L", lb);
                        break;
                    default:
                        break;
                }
            }

            int counter = 0;
            // Create stackpanel with label and listbox and add it to 'stackPoules'
            foreach (var poule in poulesDictionary)
            {
                counter++;
                Label lbl = new Label();
                lbl.Content = poule.Key;

                StackPanel pnl = new StackPanel();
                pnl.Orientation = Orientation.Vertical;

                pnl.Children.Add(lbl);
                pnl.Children.Add(poule.Value);
                pnl.Margin = new Thickness(10);

                if (counter <= 6)
                {
                    stackPoules1.Children.Add(pnl);
                }
                else
                {
                    stackPoules2.Children.Add(pnl);
                }
            }
        }

        private async void GeneratePoules(int numberOfPoules)
        {
            participants.Shuffle();
            int pouleCounter = 0;
            foreach (var participant in participants)
            {
                //delay
                //await Task.Delay(2000);

                //move over the poules
                if (pouleCounter == numberOfPoules)
                {
                    pouleCounter = 0;
                }

                poulesDictionary.ElementAt(pouleCounter).Value.Items.Add(participant);

                pouleCounter++;

            }
            ExcelHelper.CreateExcel(poulesDictionary);
        }

        private void Reset()
        {
            poulesDictionary = new Dictionary<string, ListBox>();
            stackPoules1.Children.Clear();
            stackPoules2.Children.Clear();
        }
    }
}
