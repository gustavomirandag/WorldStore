using System;
using System.Collections.Generic;
using System.Text;

namespace WorldStore.ProductMicroservice.Domain.AggregatesModel.ProductAggregate
{
    //Value Object
    public struct Category : IComparable<Category>
    {
        private string name;
        public string Name 
        {
            get 
            {
                return name;
            }
            set 
            { 
                if (value.Length < 3 || Char.IsLower(value[0]))
                    throw new ArgumentOutOfRangeException("Category needs to have at least three characters and start with an uppercase letter.");
                name = value;
            }
        }

        public Category(string name)
        {
            if (name.Length < 3 || Char.IsLower(name[0]))
                throw new ArgumentOutOfRangeException("Category needs to have at least three characters and start with an uppercase letter.");
            this.name = name;
        }

        public static Category Parse(string category)
        {
            return new Category(category);
        }

        public static implicit operator String(Category category)
        {
            return category.Name;
        }


        public static implicit operator Category(string category)
        {
            return new Category(category);
        }

        public static bool operator ==(Category currency1, Category currency2)
        {
            if (currency1.Name == currency2.Name)
                return true;
            return false;
        }

        public static bool operator !=(Category currency1, Category currency2)
        {
            if (currency1.Name != currency2.Name)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Category other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
