using System;

namespace CollectionsLab
{
    internal class Money
    {
        private uint _rubles;
        private byte _kopeks;

        public uint Rubles
        {
            get
            {
                return _rubles;
            }
            set
            {
                _rubles = value;
            }
        }


        public byte Kopeks
        {
            get
            {
                return _kopeks;
            }
            set
            {

                if (value >= 100)
                {

                    uint extraRubles = (uint)(value / 100);

                    byte newKopeks = (byte)(value % 100);

                    _rubles = _rubles + extraRubles;
                    _kopeks = newKopeks;
                }
                else
                {
                    _kopeks = value;
                }
            }
        }
        //Без параметров
        public Money()
        {
            _rubles = 0;
            _kopeks = 0;
        }

        //С параметрами
        public Money(uint rubles, byte kopeks)
        {
            _rubles = rubles;

            Kopeks = kopeks;
        }

        private ulong ToTotalKopeks()
        {
            ulong rublesInKopeks = (ulong)_rubles * 100;
            ulong result = rublesInKopeks + _kopeks;
            return result;
        }


        private void FromTotalKopeks(ulong totalKopeks)
        {
            _rubles = (uint)(totalKopeks / 100);
            _kopeks = (byte)(totalKopeks % 100);
        }


        public override string ToString()
        {
            string r = _rubles.ToString();
            string k = _kopeks.ToString();

            return r + " рублей и " + k + " копеек";
        }

        public static Money operator ++(Money value)
        {
            ulong totalKopeks = value.ToTotalKopeks();
            totalKopeks = totalKopeks + 1;

            Money result = new Money();
            result.FromTotalKopeks(totalKopeks);

            return result;
        }


        public static Money operator --(Money value)
        {
            ulong totalKopeks = value.ToTotalKopeks();

            if (totalKopeks == 0)
            {
                return new Money(0, 0);
            }

            totalKopeks = totalKopeks - 1;

            Money result = new Money();
            result.FromTotalKopeks(totalKopeks);

            return result;
        }

        //Явное приведение к uint
        public static explicit operator uint(Money value)
        {
            uint result = value.Rubles;

            return result;
        }

        //Неявное приведение к double
        public static implicit operator double(Money value)
        {

            ulong onlyKopeks = (ulong)value.Kopeks;


            double result = (double)onlyKopeks / 100.0;

            return result;
        }


        public static Money operator +(Money money, uint amount)
        {
            ulong totalKopeks = money.ToTotalKopeks();

            ulong delta = (ulong)amount * 100;

            totalKopeks = totalKopeks + delta;

            Money result = new Money();
            result.FromTotalKopeks(totalKopeks);

            return result;
        }


        public static Money operator +(uint amount, Money money)
        {

            Money result = money + amount;

            return result;
        }

        public static Money operator +(Money left, Money right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            ulong leftTotal = left.ToTotalKopeks();
            ulong rightTotal = right.ToTotalKopeks();

            ulong sum = leftTotal + rightTotal;

            Money result = new Money();
            result.FromTotalKopeks(sum);

            return result;
        }

        public static Money operator -(Money money, uint amount)
        {
            ulong totalKopeks = money.ToTotalKopeks();
            ulong delta = (ulong)amount * 100;

            if (delta >= totalKopeks)
            {
                return new Money(0, 0);
            }

            totalKopeks = totalKopeks - delta;

            Money result = new Money();
            result.FromTotalKopeks(totalKopeks);

            return result;
        }

        public static Money operator -(uint amount, Money money)
        {
            ulong left = (ulong)amount * 100;
            ulong right = money.ToTotalKopeks();

            if (right >= left)
            {
                return new Money(0, 0);
            }

            ulong totalKopeks = left - right;

            Money result = new Money();
            result.FromTotalKopeks(totalKopeks);

            return result;
        }

        public static Money operator -(Money left, Money right)
        {
            ulong leftTotal = left.ToTotalKopeks();
            ulong rightTotal = right.ToTotalKopeks();

            if (rightTotal >= leftTotal)
            {
                return new Money(0, 0);
            }

            ulong totalKopeks = leftTotal - rightTotal;

            Money result = new Money();
            result.FromTotalKopeks(totalKopeks);

            return result;
        }
    }
}
