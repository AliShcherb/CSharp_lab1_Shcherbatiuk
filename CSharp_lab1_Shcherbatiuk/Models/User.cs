using System;

namespace CSharp_lab1_Shcherbatiuk.Models
{
    internal class User
    {
        private DateTime _dateOfBirth;
        private string _age;
        private string _astrologicalZodiac;
        private string _chinaZodiac;

        #region Properties

        public DateTime BirthDate
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        public string Age
        {
            get => _age;
            set => _age = value;
        }

        public string WesternZodiac
        {
            get => _astrologicalZodiac;
            set => _astrologicalZodiac = value;
        }

        public string ChineseZodiac
        {
            get => _chinaZodiac;
            set => _chinaZodiac = value;
        }
        #endregion
    }
}