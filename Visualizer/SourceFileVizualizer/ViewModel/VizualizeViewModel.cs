namespace SourceFileVizualizer.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using CsvHelper;
    using LiveCharts;
    using LiveCharts.Helpers;
    using LiveCharts.Wpf;
    using SourceFileVizualizer.Model;
    using SourceFileVizualizer.MVVM;

    public class VizualizeViewModel : ViewModelBase
    {
        private string fileName;
        private SeriesCollection seriesCollection;
        public static VizualizeViewModel Instance;
        private List<string> listOfElements;
        private string selectedItem;

        public string SelectedItem
        {
            get { return this.selectedItem; }
            set
            {
                if (value != this.selectedItem)
                {
                    this.selectedItem = value;
                    this.readSelectedItemData(this.selectedItem);
                    this.RaisePropertyChanged();
                }
            }
        }

        public List<string> ListOfElements
        {
            get => this.listOfElements;
            set { this.listOfElements = value; this.RaisePropertyChanged(); }
        }

        public VizualizeViewModel()
        {
            VizualizeViewModel.Instance = this;
            this.ListOfElements = new List<string>();
            this.SeriesCollection = new SeriesCollection();
        }

        public string filePath;

        public void loadData()
        {
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(this.filePath, ".csv"));
            string[] lines2 = Regex.Split(lines[0], ",");
            foreach (string item in lines2)
            {
                if (item == "author") break;
                this.ListOfElements.Add(item);
            }

            this.SelectedItem = "average_line_length";
        }

        public string FileName
        {
            get => this.fileName;
            set { this.fileName = value; this.RaisePropertyChanged(); }
        }

        public SeriesCollection SeriesCollection
        {
            get => this.seriesCollection;
            set { this.seriesCollection = value; this.RaisePropertyChanged(); }
        }

        private void readSelectedItemData(string selectedItem)
        {
            this.SeriesCollection = new SeriesCollection();
            using (var reader = new StreamReader(this.filePath))
            using (var csv = new CsvReader(reader))
            {
                var record = new CSVFile();
                var records = csv.EnumerateRecords(record);
                List<double> elemek = new List<double>();

                foreach (var r in records)
                {
                    if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 0)))
                    {
                        elemek.Add(Convert.ToDouble(r.non_empty_lines));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 1)))
                    {
                        elemek.Add(Convert.ToDouble(r.average_line_length));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 2)))
                    {
                        elemek.Add(Convert.ToDouble(r.line_length_deviation));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 3)))
                    {
                        elemek.Add(Convert.ToDouble(r.words));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 4)))
                    {
                        elemek.Add(Convert.ToDouble(r.unique_words));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 5)))
                    {
                        elemek.Add(Convert.ToDouble(r.chars));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 6)))
                    {
                        elemek.Add(Convert.ToDouble(r.tabulators));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 7)))
                    {
                        elemek.Add(Convert.ToDouble(r.spaces));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 8)))
                    {
                        elemek.Add(Convert.ToDouble(r.tab_indents));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 9)))
                    {
                        elemek.Add(Convert.ToDouble(r.space_indents));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 10)))
                    {
                        elemek.Add(Convert.ToDouble(r.whitespace_to_character_ratio));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 11)))
                    {
                        elemek.Add(Convert.ToDouble(r.comments));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 12)))
                    {
                        elemek.Add(Convert.ToDouble(r.comment_readability));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 13)))
                    {
                        elemek.Add(Convert.ToDouble(r.one_line_to_all_comments));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 14)))
                    {
                        elemek.Add(Convert.ToDouble(r.multi_line_to_all_comments));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 15)))
                    {
                        elemek.Add(Convert.ToDouble(r.inline_to_all_comments));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 16)))
                    {
                        elemek.Add(Convert.ToDouble(r.using_stl_libraries));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 17)))
                    {
                        elemek.Add(Convert.ToDouble(r.all_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 18)))
                    {
                        elemek.Add(Convert.ToDouble(r.if_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 19)))
                    {
                        elemek.Add(Convert.ToDouble(r.else_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 20)))
                    {
                        elemek.Add(Convert.ToDouble(r.for_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 21)))
                    {
                        elemek.Add(Convert.ToDouble(r.while_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 22)))
                    {
                        elemek.Add(Convert.ToDouble(r.switch_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 23)))
                    {
                        elemek.Add(Convert.ToDouble(r.do_keywords));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 24)))
                    {
                        elemek.Add(Convert.ToDouble(r.functions));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 25)))
                    {
                        elemek.Add(Convert.ToDouble(r.function_name_readability));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 26)))
                    {
                        elemek.Add(Convert.ToDouble(r.function_average_length));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 27)))
                    {
                        elemek.Add(Convert.ToDouble(r.function_length_deviation));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 28)))
                    {
                        elemek.Add(Convert.ToDouble(r.function_block_braces));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 29)))
                    {
                        elemek.Add(Convert.ToDouble(r.nesting_depth));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 30)))
                    {
                        elemek.Add(Convert.ToDouble(r.average_parameter_count));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 31)))
                    {
                        elemek.Add(Convert.ToDouble(r.parameter_count_deviation));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 32)))
                    {
                        elemek.Add(Convert.ToDouble(r.commands));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 33)))
                    {
                        elemek.Add(Convert.ToDouble(r.average_commands_per_line));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 34)))
                    {
                        elemek.Add(Convert.ToDouble(r.ternary_operations));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 35)))
                    {
                        elemek.Add(Convert.ToDouble(r.negation_operator));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 36)))
                    {
                        elemek.Add(Convert.ToDouble(r.uses_united_declarations));
                    }
                    else if (selectedItem.Equals(Enum.GetName(typeof(ECSVFile), 37)))
                    {
                        elemek.Add(Convert.ToDouble(r.uses_range_based_for));
                    }
                }

                LineSeries Values = new LineSeries
                {
                    Values = elemek.AsChartValues()
                };
                this.SeriesCollection.Add(Values);
            }
        }
    }
}
