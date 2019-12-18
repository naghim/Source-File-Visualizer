using CsvHelper.Configuration.Attributes;

namespace SourceFileVizualizer.Model
{
    public class CSVFile
    {
        [Index(0)]
        public string non_empty_lines { get; set; }
        [Index(1)]
        public string average_line_length { get; set; }
        [Index(2)]
        public string line_length_deviation { get; set; }
        [Index(3)]
        public string words { get; set; }
        [Index(4)]
        public string unique_words { get; set; }
        [Index(5)]
        public string chars { get; set; }
        [Index(6)]
        public string tabulators { get; set; }
        [Index(7)]
        public string spaces { get; set; }
        [Index(8)]
        public string tab_indents { get; set; }
        [Index(9)]
        public string whitespace_to_character_ratio { get; set; }
        [Index(10)]
        public string comments { get; set; }
        [Index(11)]
        public string comment_readability { get; set; }
        [Index(12)]
        public string one_line_to_all_comments { get; set; }
        [Index(13)]
        public string multi_line_to_all_comments { get; set; }
        [Index(14)]
        public string inline_to_all_comments { get; set; }
        [Index(15)]
        public string using_stl_libraries { get; set; }
        [Index(16)]
        public string all_keywords { get; set; }
        [Index(17)]
        public string if_keywords { get; set; }
        [Index(18)]
        public string else_keywords { get; set; }
        [Index(19)]
        public string for_keywords { get; set; }
        [Index(20)]
        public string while_keywords { get; set; }
        [Index(21)]
        public string switch_keywords { get; set; }
        [Index(22)]
        public string do_keywords { get; set; }
        [Index(23)]
        public string functions { get; set; }
        [Index(24)]
        public string function_name_readability { get; set; }
        [Index(25)]
        public string function_average_length { get; set; }
        [Index(26)]
        public string function_length_deviation { get; set; }
        [Index(27)]
        public string function_block_braces { get; set; }
        [Index(28)]
        public string nesting_depth { get; set; }
        [Index(29)]
        public string average_parameter_count { get; set; }
        [Index(30)]
        public string parameter_count_deviation { get; set; }
        [Index(31)]
        public string commands { get; set; }
        [Index(32)]
        public string average_commands_per_line { get; set; }
        [Index(33)]
        public string ternary_operations { get; set; }
        [Index(34)]
        public string negation_operator { get; set; }
        [Index(35)]
        public string uses_united_declarations { get; set; }
        [Index(36)]
        public string uses_range_based_for { get; set; }
        [Index(37)]
        public string author { get; set; }
        public string space_indents { get; set; }
    }
}
