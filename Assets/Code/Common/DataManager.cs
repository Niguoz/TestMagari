namespace MagariProject.Common
{
    public class DataManager : PersistentSingleton<DataManager>
    {
        private float _boardSize = 10;
        private float _musicValue;
        private string _winnerName;

        public float BoardSize
        {
            get { return _boardSize; }
            set { _boardSize = value; }
        }

        public float MusicValue
        {
            get { return _musicValue; }
            set { _musicValue = value; }
        }

        public string WinnerName
        {
            get { return _winnerName; }
            set { _winnerName = value; }
        }
    }
}