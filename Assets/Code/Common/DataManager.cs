namespace MagariProject.Common
{
    public class DataManager : PersistentSingleton<DataManager>
    {
        private float _boardSize = 10;
        private float _musicValue = 1;
        private float _effectsValue = 1;
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

        public float EffectsValue
        {
            get { return _effectsValue; }
            set { _effectsValue = value; }
        }

        public string WinnerName
        {
            get { return _winnerName; }
            set { _winnerName = value; }
        }
    }
}