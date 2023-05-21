using Memorer.Src.MessagesClasses;
using System.Windows.Forms;

namespace Memorer.Src
{
    internal class DataGridViewHandler
    {
        readonly DataGridView _grid;
        readonly Messages _messages;
        public DataGridViewHandler(DataGridView grid, Messages messages)
        {
            _grid = grid;
            _messages = messages;
            Update();
        }

        public void Update()
        {
            _grid.Rows.Clear();
            _grid.Columns.Clear();
            _grid.Columns.Add("dateTime", "Дата и время");
            _grid.Columns.Add("message", "Сообщение");
            _grid.Columns.Add("delete", "Del");
            foreach (var message in _messages)
            {
                _grid.Rows.Add(message.DateTime, message.Content, "X");
                _grid.Rows[^1].HeaderCell.Value = _grid.Rows.Count.ToString();
            }
            foreach (DataGridViewColumn column in _grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void HandleCellClick(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != _grid.Columns.Count - 1)
            {
                return;
            }
            _messages.Remove(_messages[e.RowIndex]);
            Update();
            Program.iOLogic.PutStringsToFile(_messages, IOLogic.Files.Messages);
        }
    }
}
