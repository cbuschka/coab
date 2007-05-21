using System;

namespace Classes
{
	/// <summary>
	/// Summary description for Item.
	/// </summary>
    public class Item : IListBase
	{
		public string name; // 0x00
		public Item next; // 0x2a;
		public byte type; // 0x2e; /* 11 - 14 = scroll */
        public byte field_2EArray(int index)
        {
            switch (index)
            {
                case 1: return (byte)field_2F;
                case 2: return (byte)field_30;
                case 3: return (byte)field_31;
                default: throw new NotSupportedException();
            }
        }
		public sbyte field_2F;
		public sbyte field_30;
		public byte field_31;

        /// <summary>
        /// 0x32
        /// </summary>
		public sbyte exp_value; // 0x32
		public byte field_33;
		public byte field_34; 
		public byte field_35;
		public byte field_36; // 0x36
		public short weight; // 0x37
		public byte count;   // 0x39 
		public short _value; // 0x3A // "seams like value is in electrum, as value is doubled.";
		public Affects affect_1; // ox3C
		public Affects affect_2; // 0x3D
		public Affects affect_3; // 0x3E

        public Affects getAffect(int i)
        {
            switch (i)
            {
                case 1:
                    return affect_1;
                case 2:
                    return affect_2;
                case 3:
                    return affect_3;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
        public void setAffect(int i, Affects value )
        {
            switch (i)
            {
                case 1:
                    affect_1 = value;
                    break;
                case 2:
                    affect_2 = value;
                    break;
                case 3:
                    affect_3 = value;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public const int StructSize = 0x3F;

        public string String()
        {
            return name;
        }

        public IListBase Next()
        {
            return next;
        }

        public byte Field29()
        {
            //TODO workout if the 30th char is non-zero...
            return 0;
        }

		public Item()
		{
			Clear();
		}

        public Item(byte[] data, int offset)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            name = Sys.ArrayToString(data, offset, 0x2a);

            next = null;
            type = data[offset+0x2e];
            field_2F = (sbyte)data[offset + 0x2f];
            field_30 = (sbyte)data[offset + 0x30];
            field_31 = (byte)data[offset + 0x31];
            exp_value = (sbyte)data[offset + 0x32];
            field_33 = data[offset+0x33];
            field_34 = data[offset+0x34];
            field_35 = data[offset+0x35];
            field_36 = data[offset+0x36];

            weight = Sys.ArrayToShort(data, offset + 0x37);
            count = data[offset+0x39];
            _value = Sys.ArrayToShort(data, offset + 0x3a);
            affect_1 = (Affects)data[offset+0x3C];
            affect_2 = (Affects)data[offset+0x3D];
            affect_3 = (Affects)data[offset+0x3E];
        }

        public Item ShallowClone()
		{
			Item i = (Item) this.MemberwiseClone();
			return i;
		}

		public void Clear()
		{
			name = string.Empty;
			next = null;

			type = 0; 
			field_2F = 0;
			field_30 = 0;
			field_31 = 0;
			exp_value = 0;
			field_33 = 0;
			field_34 = 0; 
			field_35 = 0;
			field_36 = 0;
			weight = 0;
			count = 0;
			_value = 0;
			affect_1 = 0;
			affect_2 = 0;
			affect_3 = 0;
		}

        public byte[] ToByteArray()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
